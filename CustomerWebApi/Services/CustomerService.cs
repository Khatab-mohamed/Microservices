using CustomerWebApi.Data;
using CustomerWebApi.Entities;

namespace CustomerWebApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerDbContext _context;
        public CustomerService(CustomerDbContext context)
        {
            _context = context;

        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        public async Task<Customer?> GetCustomer(Guid id)
        {
            var customerFromDb = await _context.Customers.FindAsync(id);
            if (customerFromDb == null) return null;

            return customerFromDb;

        }

        public async Task Create(Customer customer)
        {
            if (customer.Id == null)
            {
                return;
            }
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Customer customer)
        {
            var customerFromDb = await _context.Customers.FindAsync(customer.Id);
            if (customerFromDb != null)
            {
                _context.Customers.Update(customer);
                _ = await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
