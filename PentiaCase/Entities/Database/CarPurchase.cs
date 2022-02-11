namespace PentiaCase.Entities.Database
{
    public class CarPurchase
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal PricePaid { get; set; }
    }
}
