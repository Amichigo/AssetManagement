using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.SanPhams;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.SanPhams.Dto;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;


namespace GWebsite.AbpZeroTemplate.Web.Core.SanPhams
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Product)]
    public class ProductAppService : GWebsiteAppServiceBase, IProductAppService
    {
        private readonly IRepository<Product> ProductRepository;

        public ProductAppService(IRepository<Product> ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        #region Public Method

        public void CreateOrEditProduct(ProductInput productInput)
        {
            if (productInput.Id == 0)
            {
                Create(productInput);
            }
            else
            {
                Update(productInput);
            }
        }

        public void DeleteProduct(int id)
        {
            var ProductEntity = ProductRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ProductEntity != null)
            {
                ProductEntity.IsDelete = true;
                ProductRepository.Update(ProductEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ProductInput GetProductForEdit(int id)
        {
            var ProductEntity = ProductRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ProductEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProductInput>(ProductEntity);
        }

        public ProductForViewDto GetProductForView(int id)
        {
            var ProductEntity = ProductRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ProductEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProductForViewDto>(ProductEntity);
        }

        public PagedResultDto<ProductDto> GetProducts(ProductFilter input)
        {
            var query = ProductRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaSanPham != null)
            {
                query = query.Where(x => x.MaSanPham.ToLower().Equals(input.MaSanPham));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<ProductDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ProductDto>(item)).ToList());
        }
        public PagedResultDto<ProductDto> GetProductTypes(ProductFilterType input)
        {
            var query = ProductRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaLoaiSanPham != null)
            {
                query = query.Where(x => x.MaLoaiSanPham.ToLower().Equals(input.MaLoaiSanPham));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<ProductDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ProductDto>(item)).ToList());
        }
        public PagedResultDto<ProductDto> GetProductNames(ProductFilterName input)
        {
            var query = ProductRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaNhaCungCap != null)
            {
                query = query.Where(x => x.MaNhaCungCap.ToLower().Equals(input.MaNhaCungCap));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<ProductDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ProductDto>(item)).ToList());
        }
        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Product_Create)]
        private void Create(ProductInput productInput)
        {
            var ProductEntity = ObjectMapper.Map<Product>(productInput);
            SetAuditInsert(ProductEntity);
            ProductRepository.Insert(ProductEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Product_Edit)]
        private void Update(ProductInput productInput)
        {
            var ProductEntity = ProductRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == productInput.Id);
            if (ProductEntity == null)
            {
            }
            ObjectMapper.Map(productInput, ProductEntity);
            SetAuditEdit(ProductEntity);
            ProductRepository.Update(ProductEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
