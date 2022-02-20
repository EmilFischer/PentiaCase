using PentiaCase.Entities.DTOs;

namespace PentiaCase.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetCustomersFromSalesPersonNameAsync(string name);
        Task<List<CustomerDTO>> GetCustomersWithNameAsync(string name);
        Task<List<CustomerDTO>> GetCustomersByCarMakeAsync(int carMake);
        Task<List<CustomerDTO>> GetCustomersByCarModelAsync(string model);
        Task<List<CustomerDTO>> GetCustomersLivingOnStreetAsync(string street);
    }
}