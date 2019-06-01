using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RentalAssets;
using GWebsite.AbpZeroTemplate.Application.Share.RentalAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets;
using GWebsite.AbpZeroTemplate.Application.Share.TypeOfRentalAssets.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RentalAssetController : GWebsiteControllerBase
    {
        private readonly IRentalAssetAppService rentalAssetAppService;

        public RentalAssetController(IRentalAssetAppService rentalAssetAppService)
        {
            this.rentalAssetAppService = rentalAssetAppService;
        }

        [HttpGet]
        public PagedResultDto<RentalAssetDto> GetRentalAssetsByFilter(RentalAssetFilter rentalAssetFilter)
        {
            return rentalAssetAppService.GetRentalAssets(rentalAssetFilter);
        }

        [HttpGet]
        public RentalAssetInput GetRentalAssetForEdit(int id)
        {
            return rentalAssetAppService.GetRentalAssetForEdit(id);
        }

        [HttpGet]
        public async Task<TypeOfRentalAssetOutput> GetTypeOfRentalAssetComboboxForEditAsync(int id)
        {
            return await rentalAssetAppService.GetTypeOfRentalAssetComboboxForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpPost]
        public void CreateOrEditRentalAsset([FromBody] RentalAssetInput input)
        {
            rentalAssetAppService.CreateOrEditRentalAsset(input);
        }

        [HttpDelete("{id}")]
        public void DeleteRentalAsset(int id)
        {
            rentalAssetAppService.DeleteRentalAsset(id);
        }

        [HttpGet]
        public RentalAssetForViewDto GetRentalAssetForView(int id)
        {
            return rentalAssetAppService.GetRentalAssetForView(id);
        }
    }
}

