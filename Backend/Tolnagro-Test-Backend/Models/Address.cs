namespace Tolnagro_Test_Backend.Models
{
    public class Address
    {
        public AddressType AddressType { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
    }
}
