using System.Collections.Generic;
using Abp.Extensions;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto;
using GWebsite.AbpZeroTemplate.DataExporting.Excel.EpPlus;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Categories.Exporting
{
    public class CategoryListExcelExporter : EpPlusExcelExporterBase, ICategoryListExcelExporter
    {
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public CategoryListExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<CategoryDto> categoryListDtos)
        {
            return CreateExcelPackage(
                "Categories.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.Workbook.Worksheets.Add(L("Categories"));
                    sheet.OutLineApplyStyle = true;

                    AddHeader(
                        sheet,
                        L("CategoryId"),
                        L("CategoryType"),
                        L("Name"),
                        L("Symbol"),
                        L("Description"),
                        L("Status")
                    );

                    AddObjects(
                        sheet, 2, categoryListDtos,
                        _ => _.CategoryId,
                        _ => _.CategoryType,
                        _ => _.Name,
                        _ => _.Symbol,
                        _ => _.Description,
                        _ => _.Status
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