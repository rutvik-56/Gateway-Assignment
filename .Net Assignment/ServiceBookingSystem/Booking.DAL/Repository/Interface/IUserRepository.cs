using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.DAL.Context;

namespace Booking.DAL.Repository.Interface
{
    public interface IUserRepository
    {
        bool checkEmail(string str);
        void AddUser(Booking.BE.model.Customer customer);

        int validateUser(Booking.BE.model.Customer customer);
        
    }
}
