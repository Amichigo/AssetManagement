using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HopDong_N13.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HopDong_N13
{
    public interface IHopDongN13AppService
    {
        int CreateOrEditHopDong(HopDongN13Input taiSanInput, int idGoiThau);
        HopDongN13Input GetHopDongForEdit(int id);
        void DeleteHopDong(int id);
        PagedResultDto<HopDongN13Dto> GetHopDongs(HopDongN13Filter input);
        HopDongN13ForViewDto GetHopDongForView(int id);
    }
}
