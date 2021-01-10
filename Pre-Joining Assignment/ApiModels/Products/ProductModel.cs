using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels.Products
{
    public class ProductModel
    {
        public int pid { get; set; }
        public int uid { get; set; }

        [Required]
        [DisplayName("Name")]
        public string name { get; set; }

        [Required]
        [DisplayName("Category")]
        public string category { get; set; }

        [Required]
        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public decimal price { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int quantity { get; set; }

        [Required]
        [DisplayName("Short Description")]
        public string short_desc { get; set; }

        [DisplayName("Long Description")]
        [DataType(DataType.MultilineText)]
        public string long_desc { get; set; }

        [DisplayName("Small Image")]
        public byte[] small_img { get; set; }

        
        [DisplayName("Large Image")]
        public byte[] large_img { get; set; }

        public virtual Users.UserModel Users { get; set; }
    }
}
