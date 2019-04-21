using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Handovers.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Handovers
{
    public interface IHandoverAppService
    {
        void CreateOrEditHandover(HandoverInput andoverInput);
        HandoverInput GetHandoverForEdit(int id);
        void DeleteHandover(int id);
        PagedResultDto<HandoverDto> GetHandovers(HandoverFilter input);
        HandoverForViewDto GetHandoverForView(int id);
    }
}
