using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace Source_Control_Assignment
{
    public class CustomValidations: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string pattern = "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$";
            if (value != null)
            {
                Match m = Regex.Match((string)value, pattern, RegexOptions.IgnoreCase);
                if (m.Success)
                {
                    return ValidationResult.Success;
                }
            }

            ErrorMessage = ErrorMessage ?? "Password Must contains Minimum eight characters, at least one letter, one number and one special character";
            return new ValidationResult(ErrorMessage);


        }
    }
}