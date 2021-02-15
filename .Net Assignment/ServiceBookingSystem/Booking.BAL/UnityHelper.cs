using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Booking.DAL.Repository.Interface;
using Booking.DAL.Repository.Class;
using Unity.Extension;

namespace Booking.BAL
{
    public class UnityHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUserRepository, UserRepository>();
        }
    }
}
