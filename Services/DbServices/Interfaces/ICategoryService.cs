using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryAsync(int id);
        Task<IList<Category>> GetCategoriesAsync();
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<bool> DeleteAsync(int id);
    }
}