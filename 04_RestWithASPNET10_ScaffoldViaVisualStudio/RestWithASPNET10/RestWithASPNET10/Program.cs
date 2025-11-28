using RestWithASPNET10.Configurations;
using RestWithASPNET10.Services;
using RestWithASPNET10.Services.PersonServicesImpl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddSerilogLogging();
builder.Services.AddControllers();

builder.Services.AddDatabaseConfiguraion(builder.Configuration);
builder.Services.AddScoped<IPersonService, PersonServicesImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
