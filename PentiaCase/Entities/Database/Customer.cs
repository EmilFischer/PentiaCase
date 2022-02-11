namespace PentiaCase.Entities.Database
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public uint Age { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public DateTime Created { get; set; }
    }
}
