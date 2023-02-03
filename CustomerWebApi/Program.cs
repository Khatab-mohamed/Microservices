using CustomerWebApi.Data;
using CustomerWebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddControllers();

/* Database Context Dependency Injection */
var serverName = Environment.GetEnvironmentVariable("DB_HOST");
var dataBaseName = Environment.GetEnvironmentVariable("DB_NAME");
var userPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

var connectionString = $"Data Source={serverName};Initial Catalog={dataBaseName};User ID=sa;Password={userPassword}";
builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(connectionString));
/* ===================================== */

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.MapControllers();

app.Run();