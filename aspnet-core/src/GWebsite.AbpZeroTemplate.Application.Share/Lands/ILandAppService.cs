using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Lands.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Lands
{
    public interface ILandAppService
    {
        void CreateOrEditLand(LandInput_9 landInput);
        LandInput_9 GetLandForEdit(int id);
        void DeleteLand(int id);
        PagedResultDto<LandDto_9> GetLands(LandFilter_9 input);
        LandForViewDto_9 GetLandForView(int id);
    }
}
