using PentiaCase.Entities.DTOs;

namespace PentiaCase.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetCustomersFromSalesPersonNameAsync(string name);
        Task<List<CustomerDTO>> GetCustomersWithNameAsync(string name);
    }
}