


using Microsoft.EntityFrameworkCore;
using ProductWebApi.Data;
using ProductWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IProductService,ProductService>();
builder.Services.AddControllers();


/* Database Context Dependency Injection */
var serverName = "localhost";
string dbName = "dms_product";
string dbPassword = "P@ssw0rd";

var connectionString = $"Server={serverName};port=3306;database={dbName};user=root;password={dbPassword}";

builder.Services.AddDbContext<ProductDbContext>(o => o.UseMySQL(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.MapControllers();

app.Run();