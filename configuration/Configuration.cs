using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.configuration
{
    public static class Configuration
    {

        public static string ConnectionString { get; set; }


        static Configuration()
        {
            ConnectionString = @"Server=LAPTOP-01HRT8HI\SQLEXPRESS;Database=ShopDb;Integrated Security=true;TrustServerCertificate=True";
        }
    }
}
