using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Booking.DAL.Repository.Interface;
using Booking.DAL.Repository.Class;

namespace Booking.BAL
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IUserRepository,UserRepository>();
            // e.g. container.RegisterType<ITestService, TestService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}