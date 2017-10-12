using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Implementations.EF.DataContext;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult Index()
        {
            var connectionString = "server=.;database=ProductCatalog;integrated security=sspi";
            var repository = new EFRepository(new ProductCatalogContext(connectionString));
            var products = repository.GetProducts();
            return View(products);
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


        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //Project course = unitOfWork.GetProject(id.Value);

            //if (course.IsUsed)
            //{
            //    var projects = unitOfWork.GetProjectsByCustomer(null);
            //    return View("Index", projects);
            //}

            //if (course == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(course);
            return View();
        }
    }
}