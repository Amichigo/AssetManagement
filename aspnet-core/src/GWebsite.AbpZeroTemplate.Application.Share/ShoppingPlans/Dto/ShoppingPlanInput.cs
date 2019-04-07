using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
namespace GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlans.Dto
{
    public class ShoppingPlanInput: Entity<int> 
    {
        public string KhuVuc { get; set; }
        public string PhongBan { get; set; }
        public int Nam { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public string KinhPhi { get; set; }
    }
}
}
