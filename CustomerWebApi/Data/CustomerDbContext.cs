using CustomerWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerWebApi.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> dbContextOptions)
            : base(dbContextOptions)
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
        // Entities

        public DbSet<Customer> Customers { get; set; }
    }
}
