using System;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.FixedAssets.Dto
{
    /// <summary>
    /// <model cref="Asset_05"></model>
    /// </summary>
    public class AssetInput_05 : Entity<int>
    {
        public string Id { get; set; }

        public string Name { get; set; }//Tên

        public string Description { get; set; }//Mô tả

        public DateTime DateAdded { get; set; }//Ngày nhận

        public int TotalMonthDepreciation { get; set; }//Số tháng khấu hao

        public float DepreciationRate { get; set; }//Tỉ lệ khấu hao

        public int Quantity { get; set; }//số lượng

        public float OriginalPrice { get; set; }//giá gốc

        public float DepreciationValue { get; set; }//giá trị khấu hao

        public string Note { get; set; }//ghi chú

        public bool IsActive { get; set; }//đang hoạt động

        public string AssetTypeId { get; set; }

        public string AssetGroupId { get; set; }

        public string AssetDetailId { get; set; }
    }
}
