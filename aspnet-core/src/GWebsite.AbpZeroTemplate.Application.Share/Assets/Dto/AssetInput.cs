using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;


namespace GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto
{
    /// <summary>
    /// <model cref="Asset"></model>
    /// </summary>
    public class AssetInput : Entity<int>
    {
        public string MaTaiSan { get; set; }
        public string LoaiTaiSan { get; set; }
    }
}
