﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Dto
{
    /// <summary>
    /// <model cref="Asset_05"></model>
    /// </summary>
    public class AssetDto_05 : Entity<int>
    {
        public string AssetId { get; set; }

        public string Name { get; set; }//Tên

        public string Description { get; set; }//Mô tả

        public DateTime? DateAdded { get; set; }//Ngày nhận

        public int TotalMonthDepreciation { get; set; }//Số tháng khấu hao

        public string NameAssetType { get; set; }//Tên

        public int AssetTypeId { get; set; }

        public string PurchaseOderId { get; set; }

        public string Supplier { get; set; }

        public float DepreciationRate { get; set; }//Tỉ lệ khấu hao

        public int Quantity { get; set; }//số lượng

        public float OriginalPrice { get; set; }//giá gốc

        public float DepreciationValue { get; set; }//giá trị khấu hao

        public string Note { get; set; }//ghi chú

        public bool IsActive { get; set; }//đang hoạt động

        public string AssetGroupId { get; set; }

        public string NameAssetGroup { get; set; }//Tên

        public DateTime PurchaseDate { get; set; }

        public string Categocy { get; set; }

        public string PurchaseFrom { get; set; }

        public string AssetDetailId { get; set; }

        public string LinkofImage { get; set; }
    }
}
