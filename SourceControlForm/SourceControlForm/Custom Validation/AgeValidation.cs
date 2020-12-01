using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SourceControlForm.Custom_Validation
{
    public class AgeValidation : ValidationAttribute
    {
        private int _minAge;
        public AgeValidation(int value)
        {
            _minAge = value;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value is int)
                {
                    int minimumage = (int)value;
                    if (minimumage < _minAge)
                    {
                        return new ValidationResult("Minimum age must be " + _minAge);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}