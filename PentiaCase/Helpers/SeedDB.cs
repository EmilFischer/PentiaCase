using PentiaCase.Entities.Database;

namespace PentiaCase.Helpers
{
    public static class SeedDB
    {
        public static void SeedDatabase(CaseDbContext context)
        {
            AddCustomers(context);
            AddSalesPeople(context);
            AddCars(context);
            AddCarPurchases(context);
            context.SaveChanges();
        }

        private static void AddCustomers(CaseDbContext context)
        {
            var names = new[] { "Emil", "Niels", "Hanne", "Emil" };
            var surnames = new[] { "Hansen", "Jensen", "Mikkelsen", "Frederiksen" };
            var ages = new[] { 32u, 53u, 22u, 41u };
            var houseNumbers = new[] { 144, 1, 432, 21};
            var streets = new[] { "vej", "gade", "vej", "boulevard" };
            var towns = new[] { "Copenhagen", "Oslo", "Paris", "Amsterdam" };
            var zipCodes = new[] { "2200", "j123", "4h3h", "3331" };
            var countries = new[] { "Danmark", "Norge", "Frankrig", "Holland" };

            for (var i = 0; i < 4; i++)
            {
                var customer = new Customer
                {
                    Name = names[i],
                    Surname = surnames[i],
                    Age = ages[i],
                    Created = DateTime.Now,
                    Address = new Address
                    {
                        HouseNumber = houseNumbers[i],
                        Street = streets[i],
                        Town = towns[i],
                        ZipCode = zipCodes[i],
                        Country = countries[i]
                    }
                };
                context.Add(customer);
            }
        }

        private static void AddSalesPeople(CaseDbContext context)
        {
            var names = new[] { "Kasper", "Gitte" };
            var jobTitles = new[] { "Regional Manager", "Assistant to the Regional Manager" };
            var salaries = new[] { new decimal(48212.3), new decimal(43555.9) };
            var houseNumbers = new[] { 144, 1 };
            var streets = new[] { "vej", "gade" };
            var towns = new[] { "Copenhagen", "Oslo" };
            var zipCodes = new[] { "2200", "j123" };
            var countries = new[] { "Danmark", "Norge" };

            for (int i = 0; i < 2; ++i)
            {
                var salesPerson = new SalesPerson
                {
                    Name = names[i],
                    JobTitle = jobTitles[i],
                    Salary = salaries[i],
                    Address = new Address
                    {
                        HouseNumber = houseNumbers[i],
                        Street = streets[i],
                        Town = towns[i],
                        ZipCode = zipCodes[i],
                        Country = countries[i]
                    }
                };
                context.Add(salesPerson);
            }
        }

        private static void AddCars(CaseDbContext context)
        {
            var models = new[] { "Prius", "Civic" };
            var colors = new[] { 3, 5 };
            for (int i = 0; i < 2; ++i)
            {
                var car = new Car
                {
                    Make = i,
                    Model = models[i],
                    Color = colors[i]
                };
                context.Add(car);
            }

            for (var i = 0; i < 5; i++)
            {
                var extra = new Extra { ExtraEnum = i };
                context.Add(extra);
            }

            for (int i = 0; i < 2; ++i)
            {
                var e1 = new CarExtra { CarId = i+1, ExtraId = i+1 };
                var e2 = new CarExtra { CarId = i+1, ExtraId = i+2 };
                context.Add(e1);
                context.Add(e2);
            }
        }

        private static void AddCarPurchases(CaseDbContext context)
        {
            var ids = new[] { 1, 1, 2, 2 };
            var prices = new[] { new decimal(30000), new decimal(21981), new decimal(20000), new decimal(55000) };
            
            for (int i = 0; i < 4; i++)
            {
                var purchase = new CarPurchase
                {
                    CustomerId = i+1,
                    CarId = ids[i],
                    OrderDate = DateTime.Now,
                    PricePaid = prices[i]
                };
                context.Add(purchase);

                var sale = new CarSales
                {
                    CarPurchaseId = i+1,
                    SalesPersonId = ids[i]
                };
                context.Add(sale);
            }
        }
    }
}
