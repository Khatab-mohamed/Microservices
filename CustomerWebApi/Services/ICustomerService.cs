using CustomerWebApi.Entities;

namespace CustomerWebApi.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        Task<Customer?> GetCustomer(Guid id);
        Task Create(Customer customer);
        Task Update(Customer customer);
        Task Delete(Customer customer);
    }
}
