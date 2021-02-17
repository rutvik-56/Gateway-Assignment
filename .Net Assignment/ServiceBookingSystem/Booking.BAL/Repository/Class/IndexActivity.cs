using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.BAL.Repository.Interface;
using Booking.DAL.Repository.Interface;

namespace Booking.BAL.Repository.Class
{
    public class IndexActivity : IIndexActivity
    {
        private readonly IUserRepository _userRepository;

        public IndexActivity(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public bool AddAddress(Booking.BE.model.Address address)
        {
            return _userRepository.AddAddress(address);
        }
    }
}
