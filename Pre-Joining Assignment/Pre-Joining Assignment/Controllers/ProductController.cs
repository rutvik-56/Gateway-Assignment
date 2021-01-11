using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using ApiModels.Products;

namespace Pre_Joining_Assignment.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductModel prod, HttpPostedFileBase smallimg, HttpPostedFileBase largeimg)
        {
            if (ModelState.IsValid)
            {
                using (var request = new HttpClient())
                {
                    request.BaseAddress = new Uri("http://localhost:50593");
                    bool result = false;

                    try
                    {
                        prod.uid = int.Parse(User.Identity.Name);

                        prod.small_img  = ConvertToBytes(smallimg);
                        prod.large_img = ConvertToBytes(largeimg);

                        result = request.PostAsync("/api/Product/Add", prod,
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
                        return View();
                    }
                    else
                    {
                        // Error
                        return View();
                    }
                }
            }

            return View();
        }


        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Details()
        {
            List<ProductModel> response = null;
            using (var request = new HttpClient())
            {
                request.BaseAddress = new Uri("http://localhost:50593");
                bool result = false;
                
                try
                {
                    int id = int.Parse(User.Identity.Name);
                     response = request.PostAsync("/api/Product/Details", id,
                                       new JsonMediaTypeFormatter())
                            .Result
                            .Content
                            .ReadAsAsync<List<ProductModel>>()
                            .Result;
                    ViewBag.Prod = response;
                }
                catch (Exception e)
                {
                    // error
                    //return 11;
                }
            }
            return Json(new { data = response }, JsonRequestBehavior.AllowGet);
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}