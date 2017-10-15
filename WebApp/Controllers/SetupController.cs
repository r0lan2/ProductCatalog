using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using WebApp.App_Start;

namespace WebApp.Controllers
{
    public class RepositoryOption
    {
        public string Name { get; set; }
    }

    public class SetupDTO
    {
        public string Repository { get; set; }
    }

    public class SetupController : Controller
    {
        private IRepository repository;

        public SetupController(IRepository repo)
        {
            repository = repo;
        }


        public ActionResult Index()
        {

            var availableRepositories = GetOptions();
            var currentRepository = GetCurrentRepository();
            ViewBag.Repositories = new SelectList(availableRepositories, "Name", "Name", currentRepository);
            return View();
        }

        [HttpPost]
        public ActionResult SetStoreContainer(SetupDTO setupData)
        {

            IocConfigurator.UpdateRepositorySelection(setupData.Repository == "EntityFramework" ? IocConfigurator.RepositoryType.EntityFramework : IocConfigurator.RepositoryType.Memory);
            var availableRepositories = GetOptions();
            var currentRepository = GetCurrentRepository();
            ViewBag.Repositories = new SelectList(availableRepositories, "Name", "Name", currentRepository);
            return RedirectToAction("Index", "Product");
        }

        public string GetCurrentRepository()
        {
            return repository is EFRepository ? "EntityFramework" : "Memory";
        }

        public List<RepositoryOption> GetOptions()
        {
            var options = new List<RepositoryOption>
            {
                new RepositoryOption() {Name = "EntityFramework"},
                new RepositoryOption() {Name = "Memory"}
            };
            return options;
        }

    }
}