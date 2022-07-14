using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTraining1121AngularDemo.PhoneBook.Dtos;
using MyTraining1121AngularDemo.Dto;

namespace MyTraining1121AngularDemo.PhoneBook
{
    public interface IPersonsAppService : IApplicationService
    {
        Task<PagedResultDto<GetPersonForViewDto>> GetAll(GetAllPersonsInput input);

        Task<GetPersonForViewDto> GetPersonForView(int id);

        Task<GetPersonForEditOutputs> GetPersonForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditPersonDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetPersonsToExcel(GetAllPersonsForExcelInput input);

    }
}