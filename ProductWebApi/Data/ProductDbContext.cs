using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProductWebApi.Entities;

namespace ProductWebApi.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> dbContextOptions) : base(dbContextOptions)
        {
			try
			{

                // use this creator if DB doesn't exist || DB has not tables .
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null) databaseCreator.Create();
                if (!databaseCreator.HasTables()) databaseCreator.CreateTables();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
}
