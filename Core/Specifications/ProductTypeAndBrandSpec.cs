using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductTypeAndBrandSpec : BaseSpecification<Product>
    {
        public ProductTypeAndBrandSpec(ProductSpecParams productParams)
            : base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
                (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);

            int skip = productParams.PageSize * (productParams.PageIndex - 1);
            int take = productParams.PageSize;
            ApplyPaging(skip, take);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductTypeAndBrandSpec(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}