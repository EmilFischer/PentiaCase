using Microsoft.EntityFrameworkCore;

namespace PentiaCase.Entities.Database
{
    public class CaseDbContext : DbContext
    {
        public CaseDbContext(DbContextOptions<CaseDbContext> options) : base(options)
        { }

        public DbSet<CarPurchase> CarPurchases { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesPerson> SalesPeople { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<CarExtra> CarExtras { get; set; }
        public DbSet<CarSales> CarSales { get; set; }
    }
}
