using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Suppliers.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Suppliers
{
    public interface ISupplierAppService
    {
        void CreateOrEditSupplier(SupplierInput supplierInput);
        SupplierInput GetSupplierForEdit(int id);
        void DeleteSupplier(int id);
        PagedResultDto<SupplierDto> GetSuppliers(SupplierFilter input);
        SupplierForViewDto GetSupplierForView(int id);
    }
}
