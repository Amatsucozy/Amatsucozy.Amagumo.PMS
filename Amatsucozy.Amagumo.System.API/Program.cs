using Amatsucozy.Amagumo.System.API;
using Amatsucozy.Amagumo.System.Infrastructure;
using Amatsucozy.Amagumo.System.Infrastructure.DI;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString(nameof(ConnectionStrings.Default));

builder.Services.AddInfrastructure(connectionString);

builder.Services.Configure<JwtBearerOptions>(builder.Configuration.GetSection(nameof(JwtBearerOptions)));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        var configuration = builder.Configuration.GetSection(nameof(JwtBearerOptions)).Get<JwtBearerOptions>();

        if (configuration is null)
        {
            throw new InvalidOperationException("JwtBearerOptions not found.");
        }

        options.Authority = configuration.Authority;
        options.Audience = configuration.Audience;
        options.RequireHttpsMetadata = configuration.RequireHttpsMetadata;
    });

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