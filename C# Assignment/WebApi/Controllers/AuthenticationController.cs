using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiModels.Users;


namespace WebApi.Controllers
{
    public class AuthenticationController : ApiController
    {
        [HttpPost]
        public int Login([FromBody]UserModel value)
        {
            var email = value.email;
            var password = value.password;

            using (var context = new ProductManagementEntities())
            {

                if (context.Users.Any(user => user.email == email && user.password == password))
                {
                    return context.Users.Where(user => user.email == email && user.password == password).FirstOrDefault().uid;
                }
                else
                {
                    return -1;
                }
            }
        }

        [HttpPost]
        public bool SignUp([FromBody]UserModel value)
        {
            var email = value.email;
            var password = value.password;
            using (var context = new ProductManagementEntities())
            {
                if (context.Users.Any(user => user.email == email))
                {
                    return false;
                }

                Users tmp = new Users { email = email, password = password };
                context.Users.Add(tmp);
                context.SaveChanges();
                return true;

            }
        }

    }
}
