using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailInventory.Repositories;
using RetailInventory.Models;

namespace RetailInventory.Services
{
    class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void GetAll()
        {
            var products = _productRepository.GetAll();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
        public void GetById(int id)
        {
            var product = _productRepository.Get(id);
            Console.WriteLine(product);
        }
        public void Add()
        {
            Console.WriteLine("Enter new product name: ");
            string? name = Console.ReadLine(); 
            Console.WriteLine("Enter product price: ");
            decimal price = decimal.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Enter category ID: ");
            int categoryId = int.Parse(Console.ReadLine() ?? "0");
            var product = new Product
            {
                Name = name ?? "Default Product",
                Price = price,
                CategoryId = categoryId
            };
            _productRepository.Add(product);
        }
        public void ShowFirstExpensive()
        {
            const decimal threshold = 5000m;
            //existing sync GetAll() and LINQ FirstOrDefault
            var expensive = _productRepository
                               .GetAll()
                               .FirstOrDefault(p => p.Price > threshold);

            Console.WriteLine(
              expensive is not null
                ? $"Expensive: {expensive.Name}"
                : $"No products over ₹{threshold} found."
            );
        }
    }
}
