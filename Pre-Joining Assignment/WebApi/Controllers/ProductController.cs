using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ApiModels.Products;

namespace WebApi.Controllers
{
    public class ProductController : ApiController
    {
      
        [HttpPost]
        public bool Add([FromBody]ProductModel prod)
        {
            Products p = new Products()
            {
                uid = prod.uid,
                name = prod.name,
                category = prod.category,
                price = prod.price,
                quantity = prod.quantity,
                short_desc = prod.short_desc,
                long_desc = prod.long_desc,
                small_img = prod.small_img,
                large_img = prod.large_img
            };

            using(var context = new ProductManagementEntities())
            {
                context.Products.Add(p);
                context.SaveChanges();
                return true;
            }

        }

        [HttpPost]
        public bool Update([FromBody]ProductModel prod)
        {
            using (var context = new ProductManagementEntities())
            {
                Products p = new Products()
                {
                    pid = prod.pid,
                    uid = prod.uid,
                    name = prod.name,
                    category = prod.category,
                    price = prod.price,
                    quantity = prod.quantity,
                    short_desc = prod.short_desc,
                    long_desc = prod.long_desc,
                    small_img = prod.small_img,
                    large_img = prod.large_img

                };
                context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        [HttpPost]
        public bool Delete([FromBody]int prod)
        {
            using (var context = new ProductManagementEntities())
            {
                Products p = context.Products.Where(x => x.pid == prod).FirstOrDefault();
                context.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            
        }

        [HttpPost]
        public List<ProductModel> Details([FromBody]int id)
        {
            using (var context = new ProductManagementEntities())
            {
                List<Products> l = context.Products.Where(t => t.uid == id).ToList();

                List<ProductModel> ans = new List<ProductModel>();

                foreach(var i in l)
                {
                    ans.Add(new ProductModel()
                    {
                        pid = i.pid,
                        name = i.name,
                        category = i.category,
                        price = i.price,
                        short_desc = i.short_desc,
                        small_img = i.small_img,
                        quantity = i.quantity
                    });
                }

                return ans;
            }
        }


    }
}