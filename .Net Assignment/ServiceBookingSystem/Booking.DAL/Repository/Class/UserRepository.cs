
using System.Linq;
using Booking.DAL.Context;
using Booking.DAL.Repository.Interface;

namespace Booking.DAL.Repository.Class
{
    public class UserRepository : IUserRepository
    {
        private readonly ServiceBookingSystemEntities context=new ServiceBookingSystemEntities();

        public UserRepository()
        {
            context = new ServiceBookingSystemEntities();
        }

        public void AddUser(Booking.BE.model.Customer customer)
        {

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Booking.BE.model.Customer, Customer>();
            });
            var mapper = config.CreateMapper();
            Customer cust = mapper.Map<Customer>(customer);
            context.Customer.Add(mapper.Map<Customer>(customer));
            context.SaveChanges();
        }

        public bool checkEmail(string str)
        {

            return context.Customer.Any(customer => customer.email == str) ? true : false;
           
        }

        public int validateUser(BE.model.Customer customer)
        {
            var fetch = context.Customer.FirstOrDefault(tmp => tmp.email == customer.email && tmp.password == customer.password);

            return (fetch != null && fetch.customer_id > 0) ? fetch.customer_id : -1;
            
        }       
    }
}
