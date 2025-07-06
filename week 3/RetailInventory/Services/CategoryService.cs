using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailInventory.Repositories;
using RetailInventory.Models;

namespace RetailInventory.Services
{
    class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void GetAll()
        {
            var categories = _categoryRepository.GetAll();
            foreach (var category in categories)
            {
                Console.WriteLine(category);
            }
        }
        public void GetById(int id)
        {
            var category = _categoryRepository.Get(id);
            Console.WriteLine(category);
        }
        public void Add()
        {
            Console.WriteLine("Enter new category name: ");
            string? name = Console.ReadLine(); 
            var category = new Category
            {
                Name = name ?? "Default Category"
            };
            _categoryRepository.Add(category);
        }
    }
}
