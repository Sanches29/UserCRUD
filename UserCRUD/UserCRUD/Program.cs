#region Configure Services
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserCRUD.Configurations;
using UserCRUD.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

var appSettings = builder.Configuration.Get<AppSettingsModel>()!;

builder.Services.AddCors(c => c.AddPolicy("AllowAll", builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

builder.Services.AddHttpContextAccessor();
builder.Services.AddLocalization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDatabaseConfiguration(appSettings);
builder.Services.AddMediatRConfiguration();
builder.Services.DependencyInjection();
builder.AddApiVersionConfiguration();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

#endregion

#region Configure Pipelines
app.UseCors("AllowAll");
app.UseSwaggerConfiguration();
app.UseHttpsRedirection();
app.UseLocalizationConfiguration();

app.MapControllers();

app.Run();
#endregion