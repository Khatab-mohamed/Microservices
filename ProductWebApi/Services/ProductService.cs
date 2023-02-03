using ProductWebApi.Data;
using ProductWebApi.Entities;
using System.Threading.Tasks;

namespace ProductWebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _context;
        public ProductService(ProductDbContext productDbContext)
        {
            _context = productDbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }
        public async Task<Product?> GetById(int id)
        {
           
           var productFromDb = await _context.Products.FindAsync(id);
            if (productFromDb == null)
                return null;
            return productFromDb;
        }

        public async Task Create(Product product)
        {
            if (product.ProductId == null)
            {
                return;
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Product product)
        {
            var productFromRepo = await _context.Products.FindAsync(product.ProductId);
            if (productFromRepo != null)
            {
                _context.Products.Update(product);
                _ = await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

    }
}
