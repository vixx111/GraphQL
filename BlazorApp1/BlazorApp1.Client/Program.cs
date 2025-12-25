using GraphQLClient.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Регистрация GraphQL клиента
builder.Services.AddScoped<GraphQLService>();

// Настройка HttpClient для обращения к серверу
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("https://localhost:5001/") // Адрес вашего сервера
    });

await builder.Build().RunAsync();