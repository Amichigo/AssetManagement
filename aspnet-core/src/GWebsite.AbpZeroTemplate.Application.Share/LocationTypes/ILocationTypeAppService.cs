using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LocationTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.LocationTypes
{
    public interface ILocationTypeAppService
    {
        void CreateOrEditLocationType(LocationTypeInput_9 LocationTypeInput);
        LocationTypeInput_9 GetLocationTypeForEdit(int id);
        void DeleteLocationType(int id);
        PagedResultDto<LocationTypeDto_9> GetLocationTypes(LocationTypeFilter_9 input);
        LocationTypeForViewDto_9 GetLocationTypeForView(int id);
    }
}
