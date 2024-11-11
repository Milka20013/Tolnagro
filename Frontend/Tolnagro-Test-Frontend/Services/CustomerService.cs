using Tolnagro_Test_Backend.API;

namespace Tolnagro_Test_Frontend.Services
{
    public class CustomerService
    {
        public event Action<Customer> OnCustomerAdded;
        public event Action<Customer> OnCustomerChanged;
        public void CallOnCustomerAdded(Customer customer)
        {
            OnCustomerAdded?.Invoke(customer);
        }
        public void CallOnCustomerChanged(Customer customer)
        {
            OnCustomerChanged?.Invoke(customer);
        }
    }
}
