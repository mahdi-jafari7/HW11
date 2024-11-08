using HW11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Interfaces
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAll();

    }
}
