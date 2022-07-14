using System.Collections.Generic;
using MyTraining1121AngularDemo.PhoneBook.Dtos;
using MyTraining1121AngularDemo.Dto;

namespace MyTraining1121AngularDemo.PhoneBook.Exporting
{
    public interface IPersonsExcelExporter
    {
        FileDto ExportToFile(List<GetPersonForViewDto> persons);
    }
}