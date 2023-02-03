using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Entities;
using ProductWebApi.Services;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService= productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();
            await _productService.Create(product);
            return Ok();

        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();
            await _productService.Update(product);
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var customer = await _productService.GetById(id);
            if (customer == null)
                return NotFound();
            await _productService.Delete(customer);
            return Ok();
        }
    }
}
