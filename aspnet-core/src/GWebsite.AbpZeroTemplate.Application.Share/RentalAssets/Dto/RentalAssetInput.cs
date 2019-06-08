using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto
{
    public class RentalAssetInput : Entity<int>
    {
        public string RentalAssetCode { set; get; }
        public string AssetCode { set; get; }
        public string AssetName { get; set; }
        public string AssetType { get; set; }
        public string AssetGroupName { get; set; }
        public string AssetStatus { get; set; }
        public float AssetValue { get; set; }
         public string LinkofImage { get; set; }
        public float DepreciationValue { get; set; }
        public float DepreciationRate { get; set; }
        public float RentalValue { get; set; }
        public string Note { set; get; }
    }
}
