using LibraryCommon.Validations.CustomValidationAttributes;
using LibraryCommon.Validations.ValidationMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryDomain.Dtos.Requests
{
    public class CreateAuthorDto
    {
        [Required(ErrorMessage = ValidationMessages.RequiredField)]
        [StringLength(100, ErrorMessage = ValidationMessages.StringLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredField)]
        [StringLength(50, ErrorMessage = ValidationMessages.StringLength)]
        public string Nationality { get; set; }

        [PastDate(ErrorMessage = ValidationMessages.DateInPast)]
        public DateTime BirthDate { get; set; }

        public IEnumerable<CreateBookForAuthorDto> Books { get; set; }
    }
}
