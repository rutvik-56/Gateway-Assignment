using System.Web.Mvc;
using Unity;
using Booking.BAL;
using Booking.BAL.Repository.Interface;
using Booking.BAL.Repository.Class;
using Unity.Mvc5;

namespace Booking.User
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ICustomerAuth, CustomerAuth>();
            container.RegisterType<IIndexActivity, IndexActivity>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.AddNewExtension<UnityHelper>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}