using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalProducts;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalProducts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DisposalProductController : GWebsiteAppServiceBase
    {
        private readonly IDisposalProductAppService disposalProductAppService;

        public DisposalProductController(IDisposalProductAppService disposalProductAppService)
        {
            this.disposalProductAppService = disposalProductAppService;
        }

        [HttpGet]
        public PagedResultDto<DisposalProductDto> GetDisposalProductsByFilter(DisposalProductFilter disposalProductFilter)
        {
            return disposalProductAppService.GetDisposalProducts(disposalProductFilter);
        }

        [HttpGet]
        public DisposalProductInput GetDisposalProductForEdit(int id)
        {
            return disposalProductAppService.GetDisposalProductForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditDisposalProduct([FromBody] DisposalProductInput input)
        {
            disposalProductAppService.CreateOrEditDisposalProduct(input);
        }

        [HttpDelete("{id}")]
        public void DeleteDisposalProduct(int id)
        {
            disposalProductAppService.DeleteDisposalProduct(id);
        }
    }
}
