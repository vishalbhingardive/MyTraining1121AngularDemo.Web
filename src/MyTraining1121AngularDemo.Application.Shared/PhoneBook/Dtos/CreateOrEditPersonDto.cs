using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyTraining1121AngularDemo.PhoneBook.Dtos
{
    public class CreateOrEditPersonDto : EntityDto<int?>
    {

        [Required]
        [StringLength(PersonConsts.MaxFirstNameLength, MinimumLength = PersonConsts.MinFirstNameLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(PersonConsts.MaxLastNameLength, MinimumLength = PersonConsts.MinLastNameLength)]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [StringLength(PersonConsts.MaxEmailLength, MinimumLength = PersonConsts.MinEmailLength)]
        public string Email { get; set; }

    }
}