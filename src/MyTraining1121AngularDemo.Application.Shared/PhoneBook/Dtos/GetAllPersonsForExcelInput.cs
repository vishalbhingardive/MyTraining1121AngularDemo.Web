using Abp.Application.Services.Dto;
using System;

namespace MyTraining1121AngularDemo.PhoneBook.Dtos
{
    public class GetAllPersonsForExcelInput
    {
        public string Filter { get; set; }

        public string FirstNameFilter { get; set; }

        public string LastNameFilter { get; set; }

        public DateTime? MaxBirthDateFilter { get; set; }
        public DateTime? MinBirthDateFilter { get; set; }

        public string EmailFilter { get; set; }

    }
}