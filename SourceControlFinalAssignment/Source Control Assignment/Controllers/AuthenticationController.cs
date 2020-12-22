using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using System.Web.Mvc;
using Source_Control_Assignment.Models;
using System.Web.Security;
using System.IO;

namespace Source_Control_Assignment.Controllers
{

    public class AuthenticationController : Controller
    {

        public static log4net.ILog Log { get; set; }

        ILog log = log4net.LogManager.GetLogger(typeof(AuthenticationController));

        // GET: Auth
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(StudentsModel model)
        { 
            log.Debug("Attemp to signIn");
            using (var context = new StudentsDBEntities())
            {
                bool isvalid = context.Students.Any(x => x.Username == model.Username && x.Password == model.Password);

                if (isvalid)
                {
                    log.Debug("Added Correct Credential");
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    Session["userId"] = context.Students.Where(x => x.Username == model.Username).FirstOrDefault().Id;
                    log.Debug("Redirect to Home Page");
                    return RedirectToAction("Index", "Home");
                }
      
                log.Error("Added Wrong Credential");
      
                ModelState.AddModelError("", "Invalid Username and Passsword");
                return View();
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(StudentsModel model, HttpPostedFileBase imgfile)
        {
            log.Debug("Attemp to signUp");
            if (ModelState.IsValid)
            {
                int id = CreatenewUser(model, imgfile);
                if (id > 0)
                {
                    ModelState.Clear();
                    log.Debug("Redirect to Home Page");
                    return RedirectToAction("SignIn");
                }
            }
            log.Error("Validation Error");
            return View("SignUp");
        }


        public int CreatenewUser(StudentsModel model, HttpPostedFileBase imgfile)
        {
            log.Debug("Creating new Student");
            using (var context = new StudentsDBEntities())
            {
                string path = "Temporary";

                Student Student = new Student()
                {
                    Name = model.Name,
                    Username = model.Username,
                    Email = model.Mail,
                    Password = model.Password,
                    Phone = model.Phone.ToString(),
                    Age = model.Age.ToString(),
                    Image = path

                };
                context.Students.Add(Student);

                context.SaveChanges();
                log.Debug("Saved new Student on Database");
                return Student.Id;
            }
        }

    }
}