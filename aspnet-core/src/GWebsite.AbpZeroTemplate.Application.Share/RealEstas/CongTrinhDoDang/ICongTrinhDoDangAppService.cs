using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.CongTrinhDoDang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.CongTrinhDoDang
{
    public interface ICongTrinhDoDangAppService
    {
        void CreateOrEditCongTrinhDoDang(CongTrinhDoDangInput BatDongSanInput);
        CongTrinhDoDangInput GetCongTrinhDoDangForEdit(int id);
        void DeleteCongTrinhDoDang(int id);
        PagedResultDto<CongTrinhDoDangDto> GetCongTrinhDoDang(CongTrinhDoDangFilter input);
        CongTrinhDoDangForViewDto GetCongTrinhDoDangForView(int id);
    }
}

