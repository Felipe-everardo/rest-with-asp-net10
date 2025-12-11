using RestWithASPNET10.Configurations;
using RestWithASPNET10.Repositories;
using RestWithASPNET10.Repositories.Impl;
using RestWithASPNET10.Services;
using RestWithASPNET10.Services.PersonServicesImpl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddSerilogLogging();

builder.Services.AddControllers();

builder.Services.AddDatabaseConfiguraion(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);

builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
