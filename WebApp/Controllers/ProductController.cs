using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Implementations.EF.DataContext;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Data.Dto;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
       private IRepository repository;
        public ProductController(IRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            var products = repository.GetProducts();
            return View(products);
        }



        public ActionResult Create()
        {
            PopulateCategories();
            return View();
        }


       
        [HttpPost]
        public ActionResult Create(ProductDTO prod)
        {
            return StoreProduct(prod);
        }

        private ActionResult StoreProduct(ProductDTO prod)
        {
            try
            {
                repository.StoreProduct(prod);
                return RedirectToAction("Index");
            }
            catch (Exception ex )
            {
                ModelState.AddModelError("", ex.Message);
                PopulateCategories();
                return View();
            }
        }


        [HttpPost]
        public ActionResult Edit(ProductDTO prod)
        {
            return StoreProduct(prod);
        }

        public void PopulateCategories(object selectedCategory = null)
        {
            var categories = repository.GetCategories();
            ViewBag.CategoryList = new SelectList(categories, "CategoryId", "Name", selectedCategory);
        }


        public ActionResult Edit(int id)
        {
            var product = repository.GetProduct(id);
            PopulateCategories(id);
            return View(product);
        }


        public ActionResult Delete(int id)
        {
            var product = repository.GetProduct(id);
           return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}