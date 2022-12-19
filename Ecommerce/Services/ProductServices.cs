using Ecommerce.Data.Base;
using Ecommerce.Models;

namespace Ecommerce.Services
{
    public class ProductServices : EntityBaseRepository<Product>, IProductServices
    {
        public ProductServices(EcommerceDbContext context) : base(context)
        {

        }
    }
}
