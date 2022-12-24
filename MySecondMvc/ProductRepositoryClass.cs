using System;
using System.Data;
using Dapper; 
using MySecondMvc.Models;

namespace MySecondMvc
    //connection methods to QUERY TO AND FROM DATABASE this class is responsible for the products
    //if we wanted one for the employees or the categories or the sales w ewolud have to create
    //a class and 
{
    public class ProductRepositoryClass : IProductRepository
    {
        private readonly IDbConnection _conn;// connection to db

        // Injecting The ProductRepoClass with the conn to the DB  //
        public ProductRepositoryClass(IDbConnection conn)//constructor of the class
        {
            _conn = conn;
        }

        public Product AssignCategory()
        {
            var categoryList = GetCategories();

            var product = new Product();

            product.Categories = categoryList;

            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("Select * From Products; ");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT*FROM categories;");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * from PRODUCTS WHERE PRODUCTID = @id",
                new { id = id });
        }

        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME,PRICE,CATEGORYID) VALUES(@name,@price,@categoryID);",
                new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
        }

        public void updateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE productid = @id",
                new { name = product.Name, price = product.Price, id = product.ProductID });
        }

        public void DeleteProduct(Product product)
        {
            _conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;",
                          new { id = product.ProductID });
            _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;",
                          new { id = product.ProductID });
            _conn.Execute("DELETE FROM Products WHERE ProductID = @id;",
                          new { id = product.ProductID });

        }
    }
}

