using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Lands.Dto
{
    /// <summary>
    /// <model cref="Land"></model>
    /// </summary>
    public class LandInput : Entity<int>
    {
        public string LoaiDat { get; set; }
        public string MucDichSuDung { get; set; }
    }
}
