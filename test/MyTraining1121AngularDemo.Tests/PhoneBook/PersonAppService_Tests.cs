using MyTraining1121AngularDemo.PhoneBook;
using MyTraining1121AngularDemo.PhoneBook.Dtos;
using Shouldly;
using Xunit;

namespace MyTraining1121AngularDemo.Tests.PhoneBook
{
    public class PersonAppService_Tests:AppTestBase
    {
        private readonly IPersonAppService _personAppService;

        public PersonAppService_Tests(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }
        [Fact]
        public void Should_Get_All_People_Without_Any_Filter()
        {
            var persons = _personAppService.GetPeople(new GetPeopleInput());

            persons.Items.Count.ShouldBe(2);
        }

        [Fact]
        public void Should_Get_People_With_Filter()
        {
            var persons = _personAppService.GetPeople(
                
                new GetPeopleInput
                {
                    Filter = "firstHost"
                });
            }
        }
    }

