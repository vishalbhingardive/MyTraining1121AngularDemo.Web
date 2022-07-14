using MyTraining1121AngularDemo.EntityFrameworkCore;
using MyTraining1121AngularDemo.PhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Migrations.Seed.Host
{
    internal class InitialPeopleCreator
    {
        private readonly MyTraining1121AngularDemoDbContext _context;

        public InitialPeopleCreator(MyTraining1121AngularDemoDbContext context)
        {
            _context = context;
        }
        public void create()
        {
            var firstHost = _context.Persons.FirstOrDefault(p => p.EmailAddress == "vishal.bhingardive@foundation.org");
            if (firstHost == null)
            {
                _context.Persons.Add(
                new Persons
                {
                    Name = "Vishal",
                    Surname = "Bhingardive",
                    EmailAddress = "vishal.bhingardive@gmail.com",
                    Phones = new List<Phone>
                    {
                         new Phone {Type = PhoneType.Home, Number = "88998656"},
                          new Phone {Type = PhoneType.Mobile, Number = "84774558"}
                    }

                });
            }

            var kanji = _context.Persons.FirstOrDefault(p => p.EmailAddress == "stephin.kaniyanjalil@waiin.com");
            if (kanji == null)
            {
                _context.Persons.Add(
                    new Persons
                    {
                        Name = "Stephin",
                        Surname = "Kaniyanjalil",
                        EmailAddress = "stephin.kaniyanjalil@waiin.com",
                        Phones = new List<Phone>
                        {
                          new Phone {Type = PhoneType.Mobile, Number = "9957565"}

                        }
                    });
            }

           

        }

    }
}
