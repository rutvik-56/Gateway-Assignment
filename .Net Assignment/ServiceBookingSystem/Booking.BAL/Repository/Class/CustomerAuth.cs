using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.BAL.Repository.Interface;
using Booking.BE.model;
using Booking.DAL.Repository.Interface;
namespace Booking.BAL.Repository.Class
{
    public class CustomerAuth : ICustomerAuth
    {
        private readonly IUserRepository _userRepository;
        public CustomerAuth(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(Customer customer)
        {
            _userRepository.AddUser(customer);
        }

        public bool checkEmail(string str)
        {
            return _userRepository.checkEmail(str);
        }

        public int validateUser(BE.model.Customer customer)
        {
            return _userRepository.validateUser(customer);
        }
    }
}
