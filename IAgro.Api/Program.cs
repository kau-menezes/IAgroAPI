using System.Text.Json.Serialization;
using IAgro.API.Extensions;
using IAgro.Application;
using IAgro.Application.Config;
using IAgro.Persistence;
using IAgro.Persistence.Context;
using Microsoft.EntityFrameworkCore;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence();
builder.Services.ConfigureApplication();

builder.Services.ConfigureCorsPolicy();

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options
        .JsonSerializerOptions
        .Converters
        .Add(new JsonStringEnumConverter())
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<IAgroContext>()
    ?? throw new InvalidOperationException("Failed to resolve AlmoxContext from service provider.");

dataContext.Database.EnsureCreated();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UserErrorHandler();
app.MapControllers();
app.Run();