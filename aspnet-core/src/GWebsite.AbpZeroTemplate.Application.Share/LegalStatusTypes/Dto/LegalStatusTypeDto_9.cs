using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.LegalStatusTypes.Dto
{
    /// <summary>
    /// <model cref="LegalStatusType_9"></model>
    /// </summary>
    public class LegalStatusTypeDto_9 : Entity<int>
    {
        public string MaHienTrangPhapLy { get; set; }
        public string TenHienTrangPhapLy { get; set; }
    }
}
