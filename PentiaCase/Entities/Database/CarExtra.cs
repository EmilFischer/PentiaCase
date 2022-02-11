namespace PentiaCase.Entities.Database
{
    public class CarExtra
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int ExtraId { get; set; }
        public Extra Extra { get; set; }
    }
}
