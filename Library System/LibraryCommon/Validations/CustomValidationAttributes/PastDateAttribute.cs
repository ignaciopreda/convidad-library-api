using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryCommon.Validations.CustomValidationAttributes
{
    public class PastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;

            if (DateTime.TryParse(value.ToString(), out dateTime))
                return dateTime < DateTime.Now;

            return false;
        }
    }
}
