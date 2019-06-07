using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau
{
    public interface  IDonViThauN13AppService
    {
        void CreateOrEditDonViThau(DonViThauN13Input taiSanInput);

        DonViThauN13Input GetDonViThauForEdit(int id);
        void DeleteDonViThau(int id);
        PagedResultDto<DonViThauN13Dto> GetDonViThaus(DonViThauN13Filter input);
        DonViThauN13ForViewDto GetDonViThauForView(int id);
    }
}
