using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.ThanhToan_N13.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.ThanhToan_N13
{
    public interface IThanhToanN13AppService
    {
        void CreateOrEditThanhToanN13(ThanhToanN13Input taiSanInput);

        ThanhToanN13Input GetThanhToanN13ForEdit(int id);
        void DeleteThanhToanN13(int id);
        PagedResultDto<ThanhToanN13Dto> GetThanhToanN13s(ThanhToanN13Filter input);
        ThanhToanN13ForViewDto GetThanhToanN13ForView(int id);
    }
}
