using RetailInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailInventory.Repositories
{
    interface IProductRepository
    {
        List<Product> GetAll();
        Product Get(int id);    
        void Add(Product product);
    }
}
