using CustomerWebApi.Entities;
using CustomerWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customersService;
        public CustomersController(ICustomerService customersService)
        {
            _customersService = customersService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return Ok(_customersService.GetCustomers());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Customer>> GetCustomer(Guid id)
        {
            var customer = await _customersService.GetCustomer(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();
            await _customersService.Create(customer);
            return Ok();

        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();
            await _customersService.Update(customer);
            return Ok();

        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(Guid id)
        {
            var customer = await _customersService.GetCustomer(id);
            if (customer == null)
                return NotFound();
            await _customersService.Delete(customer);
            return Ok();
        }
    }
}
