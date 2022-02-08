namespace PentiaCase.Entities.Database
{
    public class Address
    {
        public int Id { get; set; }
        public int HouseNumber { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
