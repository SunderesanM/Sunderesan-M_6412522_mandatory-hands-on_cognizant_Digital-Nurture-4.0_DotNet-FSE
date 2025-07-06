using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailInventory.Models;

namespace RetailInventory.Repositories
{
    interface ICategoryRepository
    {
        List<Category> GetAll();
        Category Get(int id);
        void Add(Category category);
    }
}
