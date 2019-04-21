using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCaps.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.NhaCungCaps
{
    public interface INhaCungCapAppService
    {
        void CreateOrEditNhaCungCap(NhaCungCapInput nhacungcapInput);
        NhaCungCapInput GetNhaCungCapForEdit(int id);
        void DeleteNhaCungCap(int id);
        PagedResultDto<NhaCungCapDto> GetNhaCungCaps(NhaCungCapFilter input);
        NhaCungCapForViewDto GetNhaCungCapForView(int id);
    }
}
