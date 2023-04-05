using System.ComponentModel.DataAnnotations;

namespace LibraryCommon.Validations.CustomValidationAttributes
{
    public class AuthorIdIsNonZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (int)value != 0;
        }
    }
}
