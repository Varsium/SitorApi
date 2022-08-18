using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface ICategoryTypeApiService
    {
        Task<CategoryTypeApi> GetCategoryTypeAsync(int id);
        Task<IList<CategoryTypeApi>> GetCategoryTypesAsync();
        Task<CategoryTypeApi> CreateCategoryTypeAsync(CategoryTypeApi equipment);
        Task<CategoryTypeApi> UpdateCategoryTypeAsync(CategoryTypeApi equipment);
        Task<bool> DeleteAsync(int id);
    }
}