using Dapper;
using HW11.Entities;
using HW11.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Repostitories
{

    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Product product)
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                dbConnection.Execute(Queries.InsertProduct, product);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Product>(Queries.SelectAllProducts);
            }
        }

        public Product GetById(int id)
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.QuerySingleOrDefault<Product>(Queries.SelectProductById, new { Id = id });
            }
        }

        public void Update(Product product)
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                dbConnection.Execute(Queries.UpdateProduct, product);
            }
        }

        public void Delete(int id)
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                dbConnection.Execute(Queries.DeleteProduct, new { Id = id });
            }
        }
    }

}
