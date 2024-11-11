using Tolnagro_Test_Backend.Models;
using Tolnagro_Test_Backend.Repositories.CustomerHistoryRepository;
using Tolnagro_Test_Backend.Repositories.CustomerRepository;

namespace Tolnagro_Test_Backend.HostedServices
{
    public class HistoryHostedService : BackgroundService
    {
        private IServiceProvider _serviceProvider;
        private List<Customer> customers = new();
        private int secondsBetweenTasks;
        public HistoryHostedService(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            secondsBetweenTasks = configuration.GetValue<int>("SecondsBetweenHistoryChecks");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(secondsBetweenTasks), stoppingToken);

                using var scope = _serviceProvider.CreateScope();

                var customerRepository = scope.ServiceProvider.GetRequiredService<ICustomerRepository>();
                var historyRepository = scope.ServiceProvider.GetRequiredService<ICustomerHistoryRepository>();

                int historyCount = await CheckHistory(customerRepository, historyRepository);
                await Console.Out.WriteLineAsync($"History was created for {historyCount} customers");


            }
        }

        private async Task<int> CheckHistory(ICustomerRepository customerRepository, ICustomerHistoryRepository historyRepository)
        {
            customers = await customerRepository.GetAllCustomersToHistoryCheck();
            if (customers == null || customers.Count == 0)
            {
                return 0;
            }
            for (int i = 0; i < customers.Count; i++)
            {
                customers[i].IsHistoryChecked = true;
                await historyRepository.CreateHistory(new(customers[i]));
                await customerRepository.UpdateCustomer(customers[i]);
            }
            return customers.Count;
        }
    }
}
