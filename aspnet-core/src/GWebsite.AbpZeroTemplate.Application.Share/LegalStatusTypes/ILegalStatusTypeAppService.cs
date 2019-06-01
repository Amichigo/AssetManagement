using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LegalStatusTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.LegalStatusTypes
{
    public interface ILegalStatusTypeAppService
    {
        void CreateOrEditLegalStatusType(LegalStatusTypeInput_9 LegalStatusTypeInput);
        LegalStatusTypeInput_9 GetLegalStatusTypeForEdit(int id);
        void DeleteLegalStatusType(int id);
        PagedResultDto<LegalStatusTypeDto_9> GetLegalStatusTypes(LegalStatusTypeFilter_9 input);
        LegalStatusTypeForViewDto_9 GetLegalStatusTypeForView(int id);
    }
}
