using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Constructions.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Constructions
{
    public interface IConstructionAppService
    {
        void CreateOrEditConstruction(ConstructionInput constructionInput);
        ConstructionInput GetConstructionForEdit(int id);
        void DeleteConstruction(int id);
        PagedResultDto<ConstructionDto> GetConstructions(ConstructionFilter input);
        ConstructionForViewDto GetConstructionForView(int id);
    }
}
