using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Data;
using Data.Implementations.EF.DataContext;

namespace WebApp.App_Start
{
    public static class IocConfigurator
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterType<ProductCatalogContext>().As<IProductCatalogContext>().WithParameter("conString", connectionString.ConnectionString);
            //builder.RegisterType<EFRepository>().As<IRepository>();
            builder.RegisterType<MemoryRepository>().As<IRepository>().SingleInstance();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}