using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DuAns.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.HoSoThaus
{
    public interface IHoSoThauAppService
    {
        void CreateOrEditHoSoThau(HoSoThauInput hosothauInput);
        HoSoThauInput GetHoSoThauForEdit(int id);
        void DeleteHoSoThau(int id);
        PagedResultDto<HoSoThauDto> GetHoSoThaus(HoSoThauFilter input);
        HoSoThauForViewDto GetHoSoThauForView(int id);
        Task<ListResultDto<DuAnDto>> GetDuAnLienQuanHoSos();
        //Task<HoSoThauOutput> GetHoSoThauForEditAsync(NullableIdDto input);
        Task<DuAnOutput> GetDuAnComboboxForEditAsync(NullableIdDto input);
    }
}
