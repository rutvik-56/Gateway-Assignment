using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.BAL.Repository.Interface
{
    public interface ICustomerAuth
    {
        bool checkEmail(string str);
        void AddUser(Booking.BE.model.Customer customer);
        int validateUser(BE.model.Customer customer);

        
    }
}
