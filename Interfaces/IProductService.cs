using HW11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Interfaces
{
    public interface IProductService
    {

        public void AddProduct(string name, decimal price, int categoryId);
        public IEnumerable<Product> GetAllProducts();
        public Product GetProductById(int id);
        public void UpdateProduct(int id, string name, decimal price, int categoryId);
        public void DeleteProduct(int id);
        public IEnumerable<Category> GetCategories();

    }
}
