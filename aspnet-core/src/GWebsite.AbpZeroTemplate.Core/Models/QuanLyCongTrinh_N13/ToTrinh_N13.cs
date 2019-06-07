using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13
{
    public class ToTrinh_N13 : FullAuditModel
    {
        public string SoToTrinh { set; get; }
        public string NoiDungToTrinh { set; get; }
        public string NgayKy { set; get; }
        public string ChiPhiDuyet { set; get; }
        public string FileDinhKem { set; get; }
        public string MaHopDong { set; get; }
    }
}
