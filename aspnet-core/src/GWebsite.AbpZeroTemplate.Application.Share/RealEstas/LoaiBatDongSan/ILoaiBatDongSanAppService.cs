using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiBatDongSan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiBatDongSan
{
    public interface ILoaiBatDongSanAppService
    {
        void CreateOrEditLoaiBatDongSan(LoaiBatDongSanInput LoaiBatDongSanInput);
<<<<<<< HEAD

=======
  
>>>>>>> 89aa32dd1a69060e244752ec0b1b37fed4ad9028
        LoaiBatDongSanInput GetLoaiBatDongSanForEdit(int id);
        void DeleteLoaiBatDongSan(int id);
        PagedResultDto<LoaiBatDongSanDto> GetLoaiBatDongSans(LoaiBatDongSanFilter input);
        LoaiBatDongSanForViewDto GetLoaiBatDongSanForView(int id);
    }
}
