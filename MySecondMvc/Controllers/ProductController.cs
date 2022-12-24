﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySecondMvc.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySecondMvc.Controllers
{
    public class ProductController : Controller
    {
        /// <summary>
        ///  Product Repo //
        /// </summary>
        private readonly IProductRepository repo;


        // Passing in an Instance of IProductRep //
        // Setting This.repo to the value of repo //
        public ProductController(IProductRepository repo)
        {
            this.repo = repo;

        }

        public IActionResult Index()
        {
            var products = repo.GetAllProducts();
          

            return View(products);
        }

        public IActionResult ViewProduct (int id)
        {
            var product = repo.GetProduct(id);

            return View(product);
        }

        public IActionResult UpdateProduct (int id)
        {
            Product prod = repo.GetProduct(id);

            if(prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }
        public IActionResult UpdateProductToDataBase (Product product)
        {
            repo.updateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        public IActionResult InsertProduct()
        {
            var prod = repo.AssignCategory();

            return View(prod);
        }

        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(Product product)
        {
            repo.DeleteProduct(product);

            return RedirectToAction("Index");

        }

    }
}
