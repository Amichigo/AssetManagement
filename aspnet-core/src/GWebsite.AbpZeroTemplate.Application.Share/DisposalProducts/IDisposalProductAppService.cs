using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalProducts.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.DisposalProducts
{
    public interface IDisposalProductAppService
    {
        void CreateOrEditDisposalProduct(DisposalProductInput customerInput);
        DisposalProductInput GetDisposalProductForEdit(int id);
        void DeleteDisposalProduct(int id);
        PagedResultDto<DisposalProductDto> GetDisposalProducts(DisposalProductFilter input);
    }
}