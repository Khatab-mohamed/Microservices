

using CustomerWebApi.Data;
using CustomerWebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddControllers();

/* Database Context Dependency Injection */

var connectionString = "Server=Localhost;Database=CustomerDb;Trusted_Connection=True";
builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(connectionString));
/* ===================================== */

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.MapControllers();

app.Run();