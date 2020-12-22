using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Source_Control_Assignment.Models
{
    public class StudentsModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Username { get; set; }
        
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
        
        
        [CustomValidations]
        public string Password { get; set; }
        
        [Required]
        [RegularExpression(@"[0-9]{10}")]
        public string Phone { get; set; }

        [Required]
        [Range(10, 100)]
        public string Age { get; set; }


        [FileExtensions(Extensions = "jpg,jpeg,png,gif", ErrorMessage = "Please Upload valid File!")]
        public string Image { get; set; }
    }
}