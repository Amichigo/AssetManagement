using System.Collections.Generic;
using Abp.Extensions;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes.Dto;
using GWebsite.AbpZeroTemplate.DataExporting.Excel.EpPlus;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.CategoryTypes.Exporting
{
    public class CategoryTypeListExcelExporter : EpPlusExcelExporterBase, ICategoryTypeListExcelExporter
    {
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public CategoryTypeListExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<CategoryTypeDto> categoryTypeListDtos)
        {
            return CreateExcelPackage(
                "Categories.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.Workbook.Worksheets.Add(L("Categories"));
                    sheet.OutLineApplyStyle = true;

                    AddHeader(
                        sheet,
                        L("ID"),
                        L("Name"),
                        L("Prefix Word"),
                        L("Description"),
                        L("Status"),
                        L("CreatedDate"),
                        L("CreatedBy"),
                        L("UpdatedDate"),
                        L("UpdatedBy")
                    );

                    AddObjects(
                        sheet, 2, categoryTypeListDtos,
                        _ => _.Id,
                        _ => _.Name,
                        _ => _.PrefixWord,
                        _ => _.Description,
                        _ => _.Status,
                        _ => _.CreatedDate,
                        _ => _.CreatedBy,
                        _ => _.UpdatedDate,
                        _ => _.UpdatedBy
                        );

                    //Formatting cells

                    var timeColumn = sheet.Column(1);
                    timeColumn.Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss";

                    for (var i = 1; i <= 10; i++)
                    {
                        if (i.IsIn(5, 10)) //Don't AutoFit Parameters and Exception
                        {
                            continue;
                        }

                        sheet.Column(i).AutoFit();
                    }
                });
        }
    }
}