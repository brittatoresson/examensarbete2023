﻿using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Examensarbete.Client;
using MudBlazor.Services;
using Examensarbete.Client.Services.ExerciseService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
//Hot reload

//builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<Examensarbete.Client.Services.ExerciseService.ExerciseService>();
await builder.Build().RunAsync();
