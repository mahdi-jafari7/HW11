using Dapper;
using HW11.Entities;
using HW11.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Repostitories
{
    public class CategoryRepository : ICategoryRepository
    {


        private readonly string _connectionString;

        public CategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Category> GetAll()
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Category>(Queries.SelectAllCategories);
            }
        }

        public Category GetByID(int id)
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.QuerySingleOrDefault<Category>(Queries.CategoryIDToCategoryName, new { Id = id });
            }
        }
    }
}
