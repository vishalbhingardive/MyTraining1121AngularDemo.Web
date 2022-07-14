using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTraining1121AngularDemo.PhoneBook.Dtos
{
    public class CreatePersonInput
    {
        [Required]
        [MaxLength(PersonsConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PersonsConsts.MaxSurnameLength)]
        public string Surname { get; set; }
        [EmailAddress]
        [MaxLength(PersonsConsts.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}
