using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Booking.BE.model;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using Booking.BAL.Repository.Interface;
using System.Web.Security;

namespace Booking.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerAuth _customerAuth;
        public HomeController(ICustomerAuth customerAuth)
        {
            _customerAuth = customerAuth;
        }

        [Authorize]
        public string index()
        {
            return "hello";
        }


        [HttpPost]
        public ActionResult Login([Bind(Include = "email, password")]Customer customer)
        {
            if(ModelState.IsValidField("email") && ModelState.IsValidField("password"))
            {
                customer.password = ComputeSha256Hash(customer.password);
                int result = _customerAuth.validateUser(customer);
                if (result>0)
                {
                    FormsAuthentication.SetAuthCookie(result.ToString(), false);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("password", "Wrong Credential.");
                }
            }
            
            return View();
        }

        public ViewResult Login()
        {
            return View();
        }

        public ViewResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.password = ComputeSha256Hash(customer.password);
                if(!_customerAuth.checkEmail(customer.email))
                {
                    _customerAuth.AddUser(customer);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("email","Email is already Registered.");
                }
            }
            return View();
        }

        private static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}