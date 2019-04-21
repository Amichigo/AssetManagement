using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DuAns.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.DuAns
{
    public interface IDuAnAppService
    {
        void CreateOrEditDuAn(DuAnInput duanInput);
        DuAnInput GetDuAnForEdit(int id);
        void DeleteDuAn(int id);
        PagedResultDto<DuAnDto> GetDuAns(DuAnFilter input);
        DuAnForViewDto GetDuAnForView(int id);
    }
}
