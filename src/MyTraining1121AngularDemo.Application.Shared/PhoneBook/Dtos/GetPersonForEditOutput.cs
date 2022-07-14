using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyTraining1121AngularDemo.PhoneBook.Dtos
{
    public class GetPersonForEditOutputs
    {
        public CreateOrEditPersonDto Person { get; set; }

    }
}