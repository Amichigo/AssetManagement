using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PurchasedAssets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.PurchasedAssets
{
    public interface IPurchasedAssetAppService
    {
        void CreateOrEditPurchasedAsset(PurchasedAssetInput purchasedAssetInput);
        PurchasedAssetInput GetPurchasedAssetForEdit(int id);
        void DeletePurchasedAsset(int id);
        PagedResultDto<PurchasedAssetDto> GetPurchasedAssets(PurchasedAssetFilter input);
        PurchasedAssetForViewDto GetPurchasedAssetForView(int id);
        PurchasedAssetGeneralStatistics GetGeneralStatistics(PurchasedAssetFilter purchasedAssetInput);
    }
}
