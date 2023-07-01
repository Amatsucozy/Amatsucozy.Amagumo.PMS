using System.Security.Claims;
using Amatsucozy.Amagumo.Users.API;
using Amatsucozy.Amagumo.Users.API.DI;
using Amatsucozy.Amagumo.Users.Infrastructure;
using Amatsucozy.Amagumo.Users.Infrastructure.DI;
using Amatsucozy.PMS.Shared.API.Authorization;
using Amatsucozy.PMS.Shared.API.Authorization.Handlers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString(nameof(ConnectionStrings.Default));
var jwtBearerOptions = builder.Configuration.GetSection(nameof(JwtBearerOptions)).Get<JwtBearerOptions>();

builder.Services.AddInfrastructure(connectionString);

builder.Services.Configure<JwtBearerOptions>(builder.Configuration.GetSection(nameof(JwtBearerOptions)));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        if (jwtBearerOptions is null)
        {
            throw new InvalidOperationException("JwtBearerOptions not found.");
        }

        options.Authority = jwtBearerOptions.Authority;
        options.Audience = jwtBearerOptions.Audience;
        options.RequireHttpsMetadata = jwtBearerOptions.RequireHttpsMetadata;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = ClaimTypes.NameIdentifier
        };
    });
builder.Services.AddAuthorization(options =>
{
    if (jwtBearerOptions is null)
    {
        throw new InvalidOperationException("JwtBearerOptions not found.");
    }

    options.AddPolicy(
        nameof(ScopesFlags.User),
        policyBuilder =>
        {
            policyBuilder.Requirements.Add(new HasScopeRequirement(jwtBearerOptions.Authority!, ScopesFlags.User));
        });

    options.AddPolicy(
        nameof(ScopesFlags.Admin),
        policyBuilder =>
        {
            policyBuilder.Requirements.Add(new HasScopeRequirement(jwtBearerOptions.Authority!, ScopesFlags.Admin));
        });
});
builder.Services.AddAuthorizationHandler();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Default", policyBuilder =>
    {
        policyBuilder.WithOrigins("https://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString(nameof(ConnectionStrings.Redis));
    options.InstanceName = nameof(ConnectionStrings.Redis);
});

builder.Services.AddApiDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("Default");

app.Services.DbStart();

app.Run();
