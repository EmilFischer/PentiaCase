using Microsoft.AspNetCore.Mvc;
using PentiaCase.Entities.DTOs;
using PentiaCase.Helpers;
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

        [HttpGet("CustomersByName")]
        public async Task<IActionResult> GetCustomersByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            var customers = await customerService.GetCustomersWithNameAsync(name);

            if (customers.Count == 0)
                return NoContent();

            return Ok(customers);
        }

        [HttpGet("CustomersLivingOnStreet")]
        public async Task<IActionResult> GetCustomersLivingOnStreetAsync(string street)
        {
            if (string.IsNullOrEmpty(street))
                return BadRequest();

            var customers = await customerService.GetCustomersLivingOnStreetAsync(street);

            if (customers.Count == 0)
                return NoContent();

            return Ok(customers);
        }

        [HttpGet("CustomersByCarMake")]
        public async Task<IActionResult> GetCustomersByCarMakeAsync(int carMake)
        {
            if (carMake < 0 || carMake > Enum.GetValues(typeof(CarMakeEnum)).Length)
                return BadRequest();

            var customers = await customerService.GetCustomersByCarMakeAsync(carMake);

            if (customers.Count == 0)
                return NoContent();

            return Ok(customers);
        }

        [HttpGet("CustomersByCarModel")]
        public async Task<IActionResult> GetCustomersByCarModelAsync(string carModel)
        {
            if (string.IsNullOrEmpty(carModel))
                return BadRequest();

            var customers = await customerService.GetCustomersByCarModelAsync(carModel);

            if (customers.Count == 0)
                return NoContent();

            return Ok(customers);
        }

        [HttpGet("CustomersBySalesPerson")]
        public async Task<IActionResult> GetCustomersBySalesPersonAsync(string salesPersonName)
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
