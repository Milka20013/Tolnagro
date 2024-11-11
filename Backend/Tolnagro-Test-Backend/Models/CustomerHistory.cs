using System.Text.Json;

namespace Tolnagro_Test_Backend.Models
{
    public class CustomerHistory : RootModel
    {
        public string CustomerId { get; set; }
        public string CustomerData { get; set; }
        public DateTime CheckedDate { get; set; }

        public CustomerHistory(Customer customer)
        {
            CustomerId = customer.Id!;
            CustomerData = JsonSerializer.Serialize(customer);
            CheckedDate = DateTime.Now;
        }
    }
}
