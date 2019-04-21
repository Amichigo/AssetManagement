using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;


namespace GWebsite.AbpZeroTemplate.Application.Share.Constructions.Dto
{
    /// <summary>
    /// <model cref="Construction"></model>
    /// </summary>
    public class ConstructionInput : Entity<int>
    {
        public string MucDichXayDung { get; set; }
        public string TienDoXayDung { get; set; }
        public string ThoiGianDuKienHoanThanh { get; set; }
    }
}
