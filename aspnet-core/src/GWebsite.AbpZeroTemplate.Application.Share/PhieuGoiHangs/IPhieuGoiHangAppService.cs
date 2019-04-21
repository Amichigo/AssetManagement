using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PhieuGoiHangs.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.HopDongThaus.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.PhieuGoiHangs
{
    public interface IPhieuGoiHangAppService
    {
        void CreateOrEditPhieuGoiHang(PhieuGoiHangInput phieugoihangInput);
        PhieuGoiHangInput GetPhieuGoiHangForEdit(int id);
        void DeletePhieuGoiHang(int id);
        PagedResultDto<PhieuGoiHangDto> GetPhieuGoiHangs(PhieuGoiHangFilter input);
        PhieuGoiHangForViewDto GetPhieuGoiHangForView(int id);
        Task<HopDongThauOutput> GetHopDongThauComboboxForEditAsync(NullableIdDto input);
    }
}
