using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestWeatherApi.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RestWeatherApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestWeatherApiContext")));

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
