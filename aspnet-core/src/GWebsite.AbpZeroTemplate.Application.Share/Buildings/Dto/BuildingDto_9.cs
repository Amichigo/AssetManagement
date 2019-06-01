using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Buildings.Dto
{
    /// <summary>
    /// <model cref="Building_9"></model>
    /// </summary>
    public class BuildingDto_9 : Entity<int>
    {
        public string DienTichDatXayDung { get; set; }
        public string DienTichSan { get; set; }
        public string SoTang { get; set; }
        public string KetCauNha { get; set; }
    }
}
