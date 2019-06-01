using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.LegalStatusTypes.Dto
{
    /// <summary>
    /// <model cref="LegalStatusType_9"></model>
    /// </summary>
    public class LegalStatusTypeFilter_9 : PagedAndSortedInputDto
    {
        public string MaHienTrangPhapLy { get; set; }
        public string TenHienTrangPhapLy { get; set; }
    }
}
