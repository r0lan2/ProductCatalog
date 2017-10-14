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
using System.Web.Mvc;
namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private const string connectionString = "server=.;database=ProductCatalog;integrated security=sspi";
        private EFRepository repository = new EFRepository(new ProductCatalogContext(connectionString));
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

        public void PopulateCategories(object selectedCategory = null)
        {
            var categories = repository.GetCategories();
            ViewBag.CategoryList = new SelectList(categories, "CategoryId", "Name", selectedCategory);
        }


        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Project proj = unitOfWork.GetProjectAndAreas(id.Value);
            //if (proj == null)
            //{
            //    return HttpNotFound();
            //}
            //PopulateCustomersDropDownList(proj.CustomerId);
            //PopulateProjectAdministratorsDropDownList(proj.ProjectManagerId);
            //return View(proj);
            return View();
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