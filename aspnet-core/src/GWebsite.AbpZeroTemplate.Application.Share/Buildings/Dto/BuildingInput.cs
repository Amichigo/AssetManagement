using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Buildings.Dto
{
    /// <summary>
    /// <model cref="Building"></model>
    /// </summary>
    public class BuildingInput : Entity<int>
    {
        public string DienTichDatXayDung { get; set; }
        public string DienTichSan { get; set; }
        public string SoTang { get; set; }
    }
}
