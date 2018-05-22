using Adventure.Repository;
using Adventure.Repository.Entity;
using Adventure.Repository.Interfaces;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace AdventureWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

             // Register entities/context.
            container.RegisterType<IObjectContextAdapter, adventureDevEntities>(new PerThreadLifetimeManager());

            // Register Unit of work.
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            // e.g. container.RegisterType<ITestService, TestService>();
            // Register all repositories.
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}