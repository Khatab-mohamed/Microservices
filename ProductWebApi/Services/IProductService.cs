using ProductWebApi.Entities;

namespace ProductWebApi.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Task<Product> GetById(int id);
        Task Update(Product product);
        Task Create(Product product);
        Task Delete(Product product);
    }
}
