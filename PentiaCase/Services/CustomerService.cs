using Microsoft.EntityFrameworkCore;
using PentiaCase.Entities.Database;
using PentiaCase.Entities.DTOs;
using static PentiaCase.Helpers.SeedDB;

namespace PentiaCase.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DbContextOptions<CaseDbContext> options;
        public CustomerService(DbContextOptions<CaseDbContext> options)
        {
            this.options = options;
            using var context = new CaseDbContext(options);
            SeedDatabase(context);
        }

        public async Task<List<CustomerDTO>> GetCustomersWithNameAsync(string name)
        {
            using var context = new CaseDbContext(options);
            var customers = await context.Customers
                .Where(c => c.Name.ToLower() == name.ToLower())
                .Select(c => new CustomerDTO
                {
                    Name = c.Name,
                    Surname = c.Surname,
                    Age = c.Age,
                    Created = c.Created,
                    Address = new AddressDTO
                    {
                        HouseNumber = c.Address.HouseNumber,
                        Street = c.Address.Street,
                        Town = c.Address.Town,
                        ZipCode = c.Address.ZipCode,
                        Country = c.Address.Country
                    }
                })
                .ToListAsync();

            return customers;
        }

        public async Task<List<CustomerDTO>> GetCustomersFromSalesPersonNameAsync(string name)
        {
            using var context = new CaseDbContext(options);
            var customers = await context.CarSales
                .Where(s => s.SalesPerson.Name.ToLower() == name.ToLower())
                .Select(s => new CustomerDTO
                {
                    Name = s.CarPurchase.Customer.Name,
                    Surname = s.CarPurchase.Customer.Surname,
                    Age = s.CarPurchase.Customer.Age,
                    Created = s.CarPurchase.Customer.Created,
                    Address = new AddressDTO
                    {
                        HouseNumber = s.CarPurchase.Customer.Address.HouseNumber,
                        Street = s.CarPurchase.Customer.Address.Street,
                        Town = s.CarPurchase.Customer.Address.Town,
                        ZipCode = s.CarPurchase.Customer.Address.ZipCode,
                        Country = s.CarPurchase.Customer.Address.Country
                    }
                })
                .ToListAsync();

            return customers;
        }
    }
}
