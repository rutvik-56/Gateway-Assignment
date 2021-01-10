using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using ApiModels.Users;
using System.Web.Mvc;
using System.Web.Security;

namespace Pre_Joining_Assignment.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Login()
        {

            return View();
        }

        public ActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel data)
        {
            if (ModelState.IsValid)
            {
                using (var request = new HttpClient())
                {
                    request.BaseAddress = new Uri("http://localhost:50593");
                    int result = -1;

                    try
                    {
                        result = request.PostAsync("/api/Authentication/Login", data,
                                           new JsonMediaTypeFormatter())
                                .Result
                                .Content
                                .ReadAsAsync<int>()
                                .Result;
                    }
                    catch (Exception e)
                    {
                        // error
                        //return 11;
                    }

                    if (result>0)
                    {
                        FormsAuthentication.SetAuthCookie(result.ToString(), false);
                        // sucess
                        return RedirectToAction("Add","Product");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Email and Passsword");
                        return View();
                    }
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult SignUp(UserModel data)
        {
            if(ModelState.IsValid)
            {
                using(var request=new HttpClient())
                {
                    request.BaseAddress = new Uri("http://localhost:50593");
                    bool result = false;

                    try
                    {
                        result = request.PostAsync("/api/Authentication/SignUp", data,
                                           new JsonMediaTypeFormatter())
                                .Result
                                .Content
                                .ReadAsAsync<bool>()
                                .Result;
                    }
                    catch (Exception e)
                    {
                        // error
                        //return 11;
                    }


                    if (result)
                    {
                        // sucess
                        return View();
                    }
                    else
                    {
                        return View("Login");
                    }
                }
            }
            return View();
        }
    }
}