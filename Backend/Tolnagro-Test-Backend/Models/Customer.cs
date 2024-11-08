namespace Tolnagro_Test_Backend.Models
{
    public class Customer : RootModel
    {
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
