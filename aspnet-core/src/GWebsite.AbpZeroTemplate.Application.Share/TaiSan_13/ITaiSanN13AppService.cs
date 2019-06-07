using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSan_13.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.TaiSan_13
{
    public interface  ITaiSanN13AppService
    {
        void CreateOrEditTaiSan(TaiSanN13Input taiSanInput);
        TaiSanN13Input GetTaiSanForEdit(int id);
        void DeleteTaiSan(int id);
        PagedResultDto<TaiSanDto> GetTaiSans(TaiSanN13Filter input);
        TaiSanN13ForViewDto GetTaiSanForView(int id);
    }
}
