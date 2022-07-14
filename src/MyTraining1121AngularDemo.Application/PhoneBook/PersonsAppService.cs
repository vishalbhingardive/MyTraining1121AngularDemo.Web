using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MyTraining1121AngularDemo.Authorization;
using MyTraining1121AngularDemo.Dto;
using MyTraining1121AngularDemo.PhoneBook.Dtos;
using MyTraining1121AngularDemo.PhoneBook.Exporting;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.PhoneBook
{
    [AbpAuthorize(AppPermissions.Pages_Persons)]
    public class PersonsAppService : MyTraining1121AngularDemoAppServiceBase, IPersonsAppService
    {
        private readonly IRepository<Person1> _personRepository;
        private readonly IPersonsExcelExporter _personsExcelExporter;

        public PersonsAppService(IRepository<Person1> personRepository, IPersonsExcelExporter personsExcelExporter)
        {
            _personRepository = personRepository;
            _personsExcelExporter = personsExcelExporter;

        }

        public async Task<PagedResultDto<GetPersonForViewDto>> GetAll(GetAllPersonsInput input)
        {

            var filteredPersons = _personRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.FirstName.Contains(input.Filter) || e.LastName.Contains(input.Filter) || e.Email.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FirstNameFilter), e => e.FirstName == input.FirstNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LastNameFilter), e => e.LastName == input.LastNameFilter)
                        .WhereIf(input.MinBirthDateFilter != null, e => e.BirthDate >= input.MinBirthDateFilter)
                        .WhereIf(input.MaxBirthDateFilter != null, e => e.BirthDate <= input.MaxBirthDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailFilter), e => e.Email == input.EmailFilter);

            var pagedAndFilteredPersons = filteredPersons
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var persons = from o in pagedAndFilteredPersons
                          select new
                          {

                              o.FirstName,
                              o.LastName,
                              o.BirthDate,
                              o.Email,
                              Id = o.Id
                          };

            var totalCount = await filteredPersons.CountAsync();

            var dbList = await persons.ToListAsync();
            var results = new List<GetPersonForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetPersonForViewDto()
                {
                    Person = new PersonDto1
                    {

                        FirstName = o.FirstName,
                        LastName = o.LastName,
                        BirthDate = o.BirthDate,
                        Email = o.Email,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetPersonForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetPersonForViewDto> GetPersonForView(int id)
        {
            var person = await _personRepository.GetAsync(id);

            var output = new GetPersonForViewDto { Person = ObjectMapper.Map<PersonDto1>(person) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Persons_Edit)]
        public async Task<GetPersonForEditOutputs> GetPersonForEdit(EntityDto input)
        {
            var person = await _personRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetPersonForEditOutputs { Person = ObjectMapper.Map<CreateOrEditPersonDto>(person) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditPersonDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Persons_Create)]
        protected virtual async Task Create(CreateOrEditPersonDto input)
        {
            var person = ObjectMapper.Map<Person1>(input);

            await _personRepository.InsertAsync(person);

        }

        [AbpAuthorize(AppPermissions.Pages_Persons_Edit)]
        protected virtual async Task Update(CreateOrEditPersonDto input)
        {
            var person = await _personRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, person);

        }

        [AbpAuthorize(AppPermissions.Pages_Persons_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _personRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetPersonsToExcel(GetAllPersonsForExcelInput input)
        {

            var filteredPersons = _personRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.FirstName.Contains(input.Filter) || e.LastName.Contains(input.Filter) || e.Email.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FirstNameFilter), e => e.FirstName == input.FirstNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LastNameFilter), e => e.LastName == input.LastNameFilter)
                        .WhereIf(input.MinBirthDateFilter != null, e => e.BirthDate >= input.MinBirthDateFilter)
                        .WhereIf(input.MaxBirthDateFilter != null, e => e.BirthDate <= input.MaxBirthDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailFilter), e => e.Email == input.EmailFilter);

            var query = (from o in filteredPersons
                         select new GetPersonForViewDto()
                         {
                             Person = new PersonDto1
                             {
                                 FirstName = o.FirstName,
                                 LastName = o.LastName,
                                 BirthDate = o.BirthDate,
                                 Email = o.Email,
                                 Id = o.Id
                             }
                         });

            var personListDtos = await query.ToListAsync();

            return _personsExcelExporter.ExportToFile(personListDtos);
        }

    }
}