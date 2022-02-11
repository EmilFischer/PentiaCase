namespace PentiaCase.Entities.Database
{
    public class SalesPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public int AdressId { get; set; }
        public Address Address { get; set; }
        public decimal Salary { get; set; }
    }
}
