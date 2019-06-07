using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HopDong_N13.DTO
{
   public class HopDongN13Filter : PagedAndSortedInputDto
    {

        public string SoHopDong { set; get; }
        public string SoToTrinh { set; get; }
        public string MaHoSoThau { set; get; }
    }
}
