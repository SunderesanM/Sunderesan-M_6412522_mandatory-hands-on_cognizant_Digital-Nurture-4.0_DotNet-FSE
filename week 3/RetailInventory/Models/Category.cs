using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailInventory.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Category ID: {Id}, Name: {Name}";
        }
        public List<Product> Products { get; set; } // Navigation property for Products
    }
}
