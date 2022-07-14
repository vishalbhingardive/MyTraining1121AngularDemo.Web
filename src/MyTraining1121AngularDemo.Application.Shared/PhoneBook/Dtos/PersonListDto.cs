
using Abp.Application.Services.Dto;
using Microsoft.Graph;
using System.Collections.ObjectModel;

namespace MyTraining1121AngularDemo.PhoneBook.Dtos
{
    public class PersonListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }

        public Collection<PhoneInPersonListDto>Phones { get; set; }
    }

    public class PhoneInPersonListDto : CreationAuditedEntityDto<long>
    {
        public PhoneType Type { get; set; }

        public string Number { get; set; }
    }
}
