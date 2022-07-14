using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using MyTraining1121AngularDemo.DataExporting.Excel.NPOI;
using MyTraining1121AngularDemo.PhoneBook.Dtos;
using MyTraining1121AngularDemo.Dto;
using MyTraining1121AngularDemo.Storage;

namespace MyTraining1121AngularDemo.PhoneBook.Exporting
{
    public class PersonsExcelExporter : NpoiExcelExporterBase, IPersonsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public PersonsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetPersonForViewDto> persons)
        {
            return CreateExcelPackage(
                "Persons.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Persons"));

                    AddHeader(
                        sheet,
                        L("FirstName"),
                        L("LastName"),
                        L("BirthDate"),
                        L("Email")
                        );

                    AddObjects(
                        sheet, persons,
                        _ => _.Person.FirstName,
                        _ => _.Person.LastName,
                        _ => _timeZoneConverter.Convert(_.Person.BirthDate, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _.Person.Email
                        );

                    for (var i = 1; i <= persons.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[3], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(3);
                });
        }
    }
}