using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Examensarbete.Client;
using MudBlazor.Services;
using Examensarbete.Client.Services.ExerciseService;
using Blazored.SessionStorage;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
//Serssion storage
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredSessionStorageAsSingleton();

builder.Services.AddScoped<ExerciseService>();
await builder.Build().RunAsync();

