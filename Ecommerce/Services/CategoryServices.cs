using Ecommerce.Data.Base;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services
{
    public class CategoryServices :  EntityBaseRepository<Category> , ICategoryServices
    {
        public CategoryServices(EcommerceDbContext context) : base(context)    // ctor for Dependency injection
        {
        }

    }
}
