using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVC_CS.Models;
using MVC_CS.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Connection String
var cString = builder.Configuration.GetConnectionString("Default");

using (SqlConnection connection = new SqlConnection(cString))
{
    try
    {
        connection.Open();
        connection.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Environment.Exit(1);
    }
}
// services.AddTransient<IProductService, ProductService>();

// Add services to the container.
services.AddControllersWithViews();
services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(cString)
);
services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
