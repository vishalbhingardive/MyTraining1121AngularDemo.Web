using System;
using Abp.Application.Services.Dto;

namespace MyTraining1121AngularDemo.PhoneBook.Dtos
{
    public class PersonDto1 : EntityDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

    }
}