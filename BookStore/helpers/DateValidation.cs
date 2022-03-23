using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.helpers
{
    public class DateValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           if(Convert.ToDateTime(value)<=DateTime.Now)
            {
                return ValidationResult.Success;
            }else
            {
                return new ValidationResult("Date Should be Less Than Current Date");
            }
        }
    }
}
