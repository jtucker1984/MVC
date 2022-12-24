using System;
using MySecondMvc.Models;
using System.Collections.Generic;

namespace MySecondMvc
{
	public interface IProductRepository
	{
		public IEnumerable<Product> GetAllProducts();


		public Product GetProduct(int id);

		public void updateProduct(Product product);

		public void InsertProduct(Product productToInsert);

		public IEnumerable<Category> GetCategories();

		public Product AssignCategory();

		public void DeleteProduct(Product product);

		
	}
}

