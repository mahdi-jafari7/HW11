using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11
{
    public static class Queries
    {

        public static string InsertProduct = "INSERT INTO Products (Name, Price, CategoryId) VALUES (@Name, @Price, @CategoryId)";
        public static string SelectAllProducts = @"
        SELECT p.Id, p.Name, p.Price, p.CategoryId, c.Name AS CategoryName 
        FROM Products p 
        INNER JOIN Categories c ON p.CategoryId = c.Id";
        public static string SelectProductById = @"
        SELECT p.Id, p.Name, p.Price, p.CategoryId, c.Name AS CategoryName 
        FROM Products p 
        INNER JOIN Categories c ON p.CategoryId = c.Id
        WHERE p.Id = @Id";
        public static string UpdateProduct = "UPDATE Products SET Name = @Name, Price = @Price, CategoryId = @CategoryId WHERE Id = @Id";
        public static string DeleteProduct = "DELETE FROM Products WHERE Id = @Id";
        public static string SelectAllCategories = "SELECT * FROM Categories";
        public static string CategoryIDToCategoryName = "SELECT Name FROM Categories WHERE Id = @Id";

    }
}
