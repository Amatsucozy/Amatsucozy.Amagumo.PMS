using System.Security.Claims;
using Amatsucozy.Amagumo.System.API;
using Amatsucozy.Amagumo.System.API.Authorization;
using Amatsucozy.Amagumo.System.Infrastructure;
using Amatsucozy.Amagumo.System.Infrastructure.DI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        nameof(ScopesEnum.User),
        policyBuilder =>
        {
            policyBuilder.Requirements.Add(new HasScopeRequirement(jwtBearerOptions.Authority!, ScopesEnum.User));
        });

    options.AddPolicy(
        nameof(ScopesEnum.Admin),
        policyBuilder =>
        {
            policyBuilder.Requirements.Add(new HasScopeRequirement(jwtBearerOptions.Authority!, ScopesEnum.Admin));
        });
});
builder.Services.AddScoped<UserTokenProvider>();
builder.Services.AddScoped<IAuthorizationHandler, HasScopeHandler>();

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
builder.Services.AddHttpContextAccessor();

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
