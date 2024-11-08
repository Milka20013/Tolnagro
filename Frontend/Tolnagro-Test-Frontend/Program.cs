using Tolnagro_Test_Frontend.APIGeneration;
using Tolnagro_Test_Frontend.Components;

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

            // Set up HttpClient and register ApiClient
            var httpClient = new HttpClient() { BaseAddress = new Uri(backendURL) };


            builder.Services.AddScoped(sp => httpClient);


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
