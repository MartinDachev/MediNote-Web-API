using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ServiceLayer.ValidationAttributes
{
    public class NINAttribute : ValidationAttribute
    {
        private static string regex = @"^[0-9]{10}$";
        private string defaultErrorMessage = "NIN must be exactly 10 characters, numeric only";

        public NINAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string NINValue = (string) value;
            if (value == null || Regex.IsMatch(NINValue, regex))
            {
                return ValidationResult.Success;
            }

            if (ErrorMessage == null)
            {
                return new ValidationResult(defaultErrorMessage);
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}