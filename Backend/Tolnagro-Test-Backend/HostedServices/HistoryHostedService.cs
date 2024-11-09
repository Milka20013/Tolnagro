using Tolnagro_Test_Backend.Models;
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
                await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken);

                using var scope = _serviceProvider.CreateScope();

                var customerRepository = scope.ServiceProvider.GetRequiredService<ICustomerRepository>();
                await CheckHistory(customerRepository);
                await Console.Out.WriteLineAsync("Did something");


            }
        }

        private async Task CheckHistory(ICustomerRepository customerRepository)
        {
            customers = await customerRepository.GetAllCustomers();
        }
    }
}
