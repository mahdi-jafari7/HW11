using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Entities
{
    public class Order
    {
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
