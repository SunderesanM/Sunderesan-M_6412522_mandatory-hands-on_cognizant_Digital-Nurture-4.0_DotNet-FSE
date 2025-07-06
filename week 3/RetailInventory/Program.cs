using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using RetailInventory.Data;
using Microsoft.EntityFrameworkCore;
using RetailInventory.Repositories;
using RetailInventory.Services;
using RetailInventory.Models;

//ORM stands for Object-Relational Mapping, a programming technique for converting data between incompatible type systems in object-oriented programming languages.
//Entity Framework Core is an ORM that allows developers to work with databases using .NET objects, eliminating the need for most of the data access code that developers usually need to write.
internal class Program
{
    private static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((config) =>
        {
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        })
        .ConfigureServices((context, services) =>
        {
            var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ProductService>();
            services.AddScoped<CategoryService>();
        })
        .Build();
        using var scope = host.Services.CreateScope();
        var categoryService = scope.ServiceProvider.GetRequiredService<CategoryService>();
        var productService = scope.ServiceProvider.GetRequiredService<ProductService>();

        //categoryService.Add();
        //categoryService.GetAll();
        //categoryService.GetById(1);

        productService.Add();
        productService.GetAll();
        Console.WriteLine("Retrieve product with id 1");
        productService.GetById(1);
        Console.WriteLine("Retrieve expensive products");
        productService.ShowFirstExpensive();
    }
}