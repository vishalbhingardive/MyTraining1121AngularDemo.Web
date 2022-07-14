using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace MyTraining1121AngularDemo.PhoneBook
{
    [Table("Persons")]
    public class Person1 : Entity
    {

        [Required]
        [StringLength(PersonConsts.MaxFirstNameLength, MinimumLength = PersonConsts.MinFirstNameLength)]
        public virtual string FirstName { get; set; }

        [Required]
        [StringLength(PersonConsts.MaxLastNameLength, MinimumLength = PersonConsts.MinLastNameLength)]
        public virtual string LastName { get; set; }

        public virtual DateTime BirthDate { get; set; }

        [StringLength(PersonConsts.MaxEmailLength, MinimumLength = PersonConsts.MinEmailLength)]
        public virtual string Email { get; set; }

    }
}