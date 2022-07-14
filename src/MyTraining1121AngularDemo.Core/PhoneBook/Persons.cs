using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTraining1121AngularDemo.PhoneBook
{
    [Table("PbPersons")]
    public class Persons:FullAuditedEntity, IMustHaveTenant
    {

        public virtual int TenantId { get; set; }

        [Required]
        [MaxLength(PersonsConsts.MaxNameLength)]
        public virtual string Name { get; set; }

        [Required]
        [MaxLength(PersonsConsts.MaxSurnameLength)]
        public virtual string Surname { get; set; }

        [MaxLength(PersonsConsts.MaxEmailAddressLength)]
        public virtual string EmailAddress { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
    }
}
