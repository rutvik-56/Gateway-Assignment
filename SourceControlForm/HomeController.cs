using SourceControlForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SourceControlForm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student std)
        {
            if (ModelState.IsValid)
            {
                ViewBag.SuccessMsg = "<script> alert('Form Submitted SuccessFully')</script>";
                ModelState.Clear();
            }
            return View();
        }
    }
}
