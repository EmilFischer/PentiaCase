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

        public async Task<List<CustomerDTO>> GetCustomersLivingOnStreetAsync(string street)
        {
            using var context = new CaseDbContext(options);
            var customers = await context.Customers
                .Where(c => c.Address.Street.ToLower() == street.ToLower())
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

        public async Task<List<CustomerDTO>> GetCustomersByCarMakeAsync(int carMake)
        {
            using var context = new CaseDbContext(options);
            var customers = await context.CarPurchases
                .Where(c => c.Car.Make == carMake)
                .Select(c => c.Customer)
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

        public async Task<List<CustomerDTO>> GetCustomersByCarModelAsync(string model)
        {
            using var context = new CaseDbContext(options);
            var customers = await context.CarPurchases
                .Where(c => c.Car.Model.ToLower() == model.ToLower())
                .Select(c => c.Customer)
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
                .Select(s => s.CarPurchase.Customer)
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
    }
}
