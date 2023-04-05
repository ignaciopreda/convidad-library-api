using LibraryCommon.Validations.CustomValidationAttributes;
using LibraryCommon.Validations.ValidationMessages;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryDomain.Dtos.Requests
{
    public class CreateBookForAuthorDto
    {
        [Required(ErrorMessage = ValidationMessages.RequiredField)]
        [StringLength(20, ErrorMessage = ValidationMessages.StringLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredField)]
        [StringLength(20, ErrorMessage = ValidationMessages.StringLength)]
        public string Isbn { get; set; }

        [PastDate(ErrorMessage = ValidationMessages.DateInPast)]
        public DateTime PublicationDate { get; set; }
    }
}
