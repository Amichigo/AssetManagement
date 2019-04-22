using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.TaiSans.Dto
{
    /// <summary>
    /// <model cref="TaiSan"></model>
    /// </summary>
    public class TaiSanDto : Entity<int>
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Info { get; set; }
    }
}
