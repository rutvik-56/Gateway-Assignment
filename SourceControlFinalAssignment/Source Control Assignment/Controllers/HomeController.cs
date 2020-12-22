using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using System.Web;
using System.Web.Mvc;
using Source_Control_Assignment.Models;

namespace Source_Control_Assignment.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public static log4net.ILog Log {get; set;}

        ILog log = log4net.LogManager.GetLogger(typeof(HomeController));
        public ActionResult Index()
        {
            log.Debug("Inside index debug");
            string id = Session["userId"].ToString();
            var model = StudentsDetail(int.Parse(id));
            return View(model);
        }

        public StudentsModel StudentsDetail(int id)
        {
            using (var context = new StudentsDBEntities())
            {
                var result = context.Students
                    .Where(x =>x.Id == id)
                    .Select(x => new StudentsModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Username = x.Username,
                        Mail = x.Email,
                        Phone = x.Phone,
                        Age = x.Age,
                        Image = x.Image
                    }).FirstOrDefault();
                return result;
            }
        }
    }
}