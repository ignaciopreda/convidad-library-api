namespace LibraryCommon.Validations.ValidationMessages
{
    public class ValidationMessages
    {
        public const string RequiredField = "The {0} field is required.";
        public const string StringLength = "The {0} field must be a string with a maximum length of {1}.";
        public const string DataType = "The {0} field must be a valid date.";
        public const string DateInPast = "You cannot select a date that is later than today.";
        public const string NonZero = "This field cannot be zero.";
    }
}
