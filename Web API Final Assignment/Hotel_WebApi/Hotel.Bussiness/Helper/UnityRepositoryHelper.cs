using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;
using Hotel.DB.Repository;
using Hotel.DB.Files;

namespace HMS.BAL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
    {
        Container.RegisterType<IHotelFiles, HotelFiles>();
    }
 
 }
}
