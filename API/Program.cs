using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // Creating a new instance of WebApplicationBuilder

// Add services to the container.

builder.Services.AddControllers(); // Adding controller services to handle HTTP requests
builder.Services.AddDbContext<DataContext>(opt =>
{
    // Configuring the DataContext service using Entity Framework Core to connect to a SQLite database
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();
var app = builder.Build(); // Building the WebApplication using the configured services

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
app.MapControllers(); // Mapping the controllers to handle incoming requests

app.Run(); // Running the application
