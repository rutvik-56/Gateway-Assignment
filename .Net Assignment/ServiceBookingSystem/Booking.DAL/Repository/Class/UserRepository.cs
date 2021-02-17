
using System;
using System.Diagnostics;
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

        public bool AddAddress(BE.model.Address address)
        {
            try
            {
                var city = context.City.Where(x => x.name == address.city).FirstOrDefault();
                var state = context.State.Where(x => x.name == address.state).FirstOrDefault();

                if (city == null)
                {
                    context.City.Add(new City()
                    {
                        name = address.city
                    });
                    context.SaveChanges();
                    city = context.City.Where(x => x.name == address.city).FirstOrDefault();
                }

                if (state == null)
                {
                    context.State.Add(new State()
                    {
                        name = address.state
                    });
                    context.SaveChanges();
                    state = context.State.Where(x => x.name == address.state).FirstOrDefault();
                }

                Address add = new Address()
                {
                    city_id = city.city_id,
                    mix_id = address.mix_id,
                    state_id = state.state_id,
                    address1 = address.address1,
                    role = address.role,
                    zipcode = address.zipcode,
                    
                };
                context.Address.Add(add);
                context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

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
