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
        public static void ConfigureDependencyInjection(RepositoryType type)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            if (type == RepositoryType.EntityFramework)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"];
                builder.RegisterType<ProductCatalogContext>().As<IProductCatalogContext>().WithParameter("conString", connectionString.ConnectionString);
                builder.RegisterType<EFRepository>().As<IRepository>();
            }
            else
            {
                builder.RegisterType<MemoryRepository>().As<IRepository>().SingleInstance();
            }

            IContainer container = builder.Build();
          
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


        /// <summary>
        /// Autofac documentation recommend create a delegate in order to change the implementation in a safe way.
        /// I would like to change this in the future. 
        /// </summary>
        /// <param name="type"></param>
        public static void UpdateRepositorySelection(RepositoryType type)
        {
           
            ConfigureDependencyInjection(type);
        }

        public enum RepositoryType
        {
            EntityFramework,
            Memory
        }
    }


   
}