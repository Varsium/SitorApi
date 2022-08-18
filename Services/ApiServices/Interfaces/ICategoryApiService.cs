using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface ICategoryApiService
    {
        Task<CategoryApi> GetCategoryAsync(int id);
        Task<IList<CategoryApi>> GetCategoriesAsync();
        Task<CategoryApi> CreateCategoryAsync(CategoryApi category);
        Task<CategoryApi> UpdateCategoryAsync(CategoryApi category);
        Task<bool> DeleteAsync(int id);
    }
}