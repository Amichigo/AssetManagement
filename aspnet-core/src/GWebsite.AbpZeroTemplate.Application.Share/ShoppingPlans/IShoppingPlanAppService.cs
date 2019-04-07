using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlans.Dto;
namespace GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlans
{
    public interface IShoppingPlanAppService
    {
        void CreateOrEditCustomer(ShoppingPlanInput customerInput);
        ShoppingPlanInput GetCustomerForEdit(int id);
        void DeleteCustomer(int id);
        PagedResultDto<ShoppingPlanDto> GetCustomers(ShoppingPlanFilter input);
        ShoppingPlanForViewDto GetCustomerForView(int id);
    }
}
