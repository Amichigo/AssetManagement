using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Core.Models.Base;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Asset_05 : Entity<string>
    {
        public string Name { get; set; }//Tên

        public string Description { get; set; }//Mô tả

        public DateTime DateAdded { get; set; }//Ngày nhận

        public int  Quantity { get; set; }//số lượng

        public float OriginalPrice { get; set; }//giá gốc

        public string Note { get; set; }//ghi chú

        public bool IsActive { get; set; }//đang hoạt động

        public string PurchaseOderId { get; set; }

        public string AssetDetailId  { get; set; }

        public string AssetGroupId { get; set; }

        public string WarrantyId { get; set; }

        public string CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public bool IsDelete { get; set; }
    }
}
