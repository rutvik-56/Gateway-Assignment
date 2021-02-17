using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.BAL.Repository.Interface
{
    public interface IIndexActivity
    {
        bool AddAddress(Booking.BE.model.Address address);
    }
}
