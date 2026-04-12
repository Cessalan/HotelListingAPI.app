using HotelLising.Api.Data;
using HotelLising.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("HotelListingSQLConnection");
// add context to the services so it can be used in DI using the options to connect to the MSSQL server
builder.Services.AddDbContext<HotelListingDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IHotelServices, HotelServices>();
builder.Services.AddScoped<ICountriesServices, CountriesServices>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
