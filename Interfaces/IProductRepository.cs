using HW11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Interfaces
{
    public interface IProductRepository
    {

        public void Add(Product product);
        public IEnumerable<Product> GetAll();
        public Product GetById(int id);
        public void Update(Product product);
        public void Delete(int id);
    }

}

