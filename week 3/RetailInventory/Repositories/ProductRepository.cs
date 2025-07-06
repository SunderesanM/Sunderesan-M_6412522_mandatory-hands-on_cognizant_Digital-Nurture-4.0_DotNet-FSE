using RetailInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailInventory.Data;

namespace RetailInventory.Repositories
{
    class ProductRepository:IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }
        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
