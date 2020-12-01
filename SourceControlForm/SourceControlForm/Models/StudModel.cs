using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SourceControlForm.Models
{
    public class Student
    {
        [RegularExpression(@"^[A-Za-z0-9]+", ErrorMessage = "It Should not contain any special character.")]
        [Required (ErrorMessage ="Id is Required!")] 
        public string StudentID { get; set; }

        [Required (ErrorMessage = "Name is Required!")]
        [StringLength(20, ErrorMessage ="Maximum Length Should be 20.")]
        public string Name { get; set; }
        
        [Required (ErrorMessage = "Age is Required!")]
        [Range(0, 120, ErrorMessage = "Enter Valid Age")]
        [SourceControlForm.Custom_Validation.AgeValidation(18)]
        public int Age { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Enter Valid Email Address")]
        [Required (ErrorMessage = "Email is Required!")]
        public string Email { get; set; }

        
        [RegularExpression(@"[0-9]{10}" , ErrorMessage ="Enter Valid Phone Number")]
        [Required(ErrorMessage = "Phone Number is Required!")]
        public string PhoneNumber { get; set; }
        
        [Range(0,10,ErrorMessage ="Enter Between 0.0 To 10.0")]
        [Required(ErrorMessage = "CGPA is Required!")]
        public decimal? CGPA { get; set; }
       
    }
}