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

 
        public ActionResult Update(int pid)
        {
            using (var request = new HttpClient())
            {
                request.BaseAddress = new Uri("http://localhost:50593");
                ProductModel result = null;

                try
                {

                    result = request.PostAsync("/api/Product/Single", pid,
                                       new JsonMediaTypeFormatter())
                            .Result
                            .Content
                            .ReadAsAsync<ProductModel>()
                            .Result;
                    return View(result);
                }
                catch (Exception e)
                {
                    // error
                    //return 11;
                }

                
            }
            return View();
        }

        [HttpPost]
        public ActionResult Update(ProductModel prod)
        {
            if(ModelState.IsValid)
            {
                using (var request = new HttpClient())
                {
                    request.BaseAddress = new Uri("http://localhost:50593");
                    bool result = false;

                    try
                    {

                        result = request.PostAsync("/api/Product/Update", prod,
                                           new JsonMediaTypeFormatter())
                                .Result
                                .Content
                                .ReadAsAsync<bool>()
                                .Result;
                        return RedirectToAction("Details");
                    }
                    catch (Exception e)
                    {
                        // error
                        //return 11;
                    }
                }


            }
            return RedirectToAction("Details");
        }

        public ActionResult Delete(int pid)
        {
            using (var request = new HttpClient())
            {
                request.BaseAddress = new Uri("http://localhost:50593");
                bool result = false;

                try
                {
              
                    result = request.PostAsync("/api/Product/Delete", pid,
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
                    return RedirectToAction("Details");
                }
                else
                {
                    // Error
                    return RedirectToAction("Details");
                }
            }
            
        }

        public ActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Detail()
        {
            List<ProductModel> response = null;
            using (var request = new HttpClient())
            {
                request.BaseAddress = new Uri("http://localhost:50593");
               
                try
                {
                    int id = int.Parse(User.Identity.Name);
                     response = request.PostAsync("/api/Product/Details", id,
                                       new JsonMediaTypeFormatter())
                            .Result
                            .Content
                            .ReadAsAsync<List<ProductModel>>()
                            .Result;

                    for(int i =0;i<response.Count;i++)
                    {
                        response[i].encode = Convert.ToBase64String(response[i].small_img, 0, response[i].small_img.Length);
                    }
                    
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