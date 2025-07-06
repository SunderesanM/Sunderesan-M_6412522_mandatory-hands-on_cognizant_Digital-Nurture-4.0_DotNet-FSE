using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailInventory.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) 
        {
            _context = context;
        }
        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }
        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
