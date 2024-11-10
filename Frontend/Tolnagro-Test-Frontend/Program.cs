using MudBlazor.Services;
using Tolnagro_Test_Backend.API;
using Tolnagro_Test_Frontend.APIGeneration;
using Tolnagro_Test_Frontend.Components;
using Tolnagro_Test_Frontend.Services;
namespace Tolnagro_Test_Frontend
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var backendURL = builder.Configuration["BackendURL"] ?? throw new Exception("BackendURL not found!");

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var httpClient = new HttpClient() { BaseAddress = new Uri(backendURL) };
            var generatedAPI = new GeneratedAPI(backendURL, httpClient);
            builder.Services.AddScoped(sp => generatedAPI);
            builder.Services.AddSingleton<CustomerService>();

            builder.Services.AddMudServices();


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            if (!app.Environment.IsProduction())
            {
                await APICodeGenerator.Generate(httpClient);
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
