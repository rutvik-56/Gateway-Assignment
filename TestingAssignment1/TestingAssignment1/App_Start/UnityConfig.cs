using System.Web.Http;
using TestingAssignment1.Repository.Interface;
using TestingAssignment1.Repository.Class;
using Unity;
using Unity.WebApi;

namespace TestingAssignment1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IPassengerManager, PassengerManager>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}