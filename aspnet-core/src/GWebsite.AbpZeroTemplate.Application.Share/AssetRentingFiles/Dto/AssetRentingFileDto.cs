using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetRentingFiles.Dto
{
    /// <summary>
    /// <model cref="AssetRentingFile"></model>
    /// </summary>
    public class AssetRentingFileDto : Entity<int>
    {
        public string FileName { get; set; }
        public string FileCode { get; set; }
        public string AssetCode { get; set; }
        public string FormOfRenting { get; set; }
        public DateTime FileCreatedDate { get; set; }
        public string LinkofImage { get; set; }
    }
}
