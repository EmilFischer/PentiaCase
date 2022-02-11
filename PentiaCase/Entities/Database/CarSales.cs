namespace PentiaCase.Entities.Database
{
    public class CarSales
    {
        public int Id { get; set; }
        public int CarPurchaseId { get; set; }
        public CarPurchase CarPurchase { get; set; }
        public int SalesPersonId { get; set; }
        public SalesPerson SalesPerson { get; set; }
    }
}
