using Examensarbete.Server.Interface;
using Examensarbete.Server.Data;
using Examensarbete.Server.Models;
//using Examensarbete.Server.Services;
using Examensarbete.Server.Controllers;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Examensarbete.Shared.Model;
using System.Diagnostics.Metrics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//Ta bort???
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration["ConnectionString:DefaultConnection"]));
builder.Services.AddDbContext<DatabaseContextNy>
(options =>
options.UseSqlServer(builder.Configuration["ConnectionString:DefaultConnection"]));
//Ta bort??
//builder.Services.AddTransient<INyManager, NyManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
