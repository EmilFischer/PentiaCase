using Microsoft.AspNetCore.Mvc;
using PentiaCase.Entities.DTOs;
using PentiaCase.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PentiaCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet("name")]
        public async Task<IActionResult> GetCustomerByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            var customers = await customerService.GetCustomersWithNameAsync(name);

            if (customers.Count == 0)
                return NoContent();

            return Ok(customers);
        }

        [HttpGet("salesPersonName")]
        public async Task<IActionResult> GetCustomerBySalesPersonAsync(string salesPersonName)
        {
            if (string.IsNullOrEmpty(salesPersonName))
                return BadRequest();

            var customers = await customerService.GetCustomersFromSalesPersonNameAsync(salesPersonName);

            if (customers.Count == 0)
                return NoContent();

            return Ok(customers);
        }
    }
}
