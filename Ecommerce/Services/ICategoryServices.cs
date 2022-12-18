using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAllAsync();      // to use async & await
        Task<Category> GetByIdAsync(int id);
        Task CreateAsync(Category entity);
        Task UpdateAsync(Category entity);
        Task DeleteAsync(int id);

    }
}
