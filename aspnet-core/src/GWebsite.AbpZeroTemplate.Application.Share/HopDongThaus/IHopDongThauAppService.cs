using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCaps.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus
{
    public interface IHopDongThauAppService
    {
        void CreateOrEditHopDongThau(HopDongThauInput hopdongthauInput);
        HopDongThauInput GetHopDongThauForEdit(int id);
        void DeleteHopDongThau(int id);
        PagedResultDto<HopDongThauDto> GetHopDongThaus(HopDongThauFilter input);
        HopDongThauForViewDto GetHopDongThauForView(int id);
        Task<HoSoThauOutput> GetHoSoThauComboboxForEditAsync(NullableIdDto input);
        Task<NhaCungCapOutput> GetNhaCungCapComboboxForEditAsync(NullableIdDto input);
    }
}
