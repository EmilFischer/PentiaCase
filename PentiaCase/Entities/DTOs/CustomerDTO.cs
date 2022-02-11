namespace PentiaCase.Entities.DTOs
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public uint Age { get; set; }
        public AddressDTO Address { get; set; }
        public DateTime Created { get; set; }
    }
}
