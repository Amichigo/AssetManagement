using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.SanPhams.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.SanPhams
{
    public interface IProductAppService
    {
        void CreateOrEditProduct(ProductInput productInput);
        ProductInput GetProductForEdit(int id);
        void DeleteProduct(int id);
        PagedResultDto<ProductDto> GetProducts(ProductFilter input);
        PagedResultDto<ProductDto> GetProductTypes(ProductFilterType input);
        PagedResultDto<ProductDto> GetProductNames(ProductFilterName input);
        ProductForViewDto GetProductForView(int id);
    }
}
