using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface ITypeItemApiService
    {
        Task<TypeItemApi> GetTypeItemAsync(int id);
        Task<IList<TypeItemApi>> GetTypeItemsAsync();
        Task<TypeItemApi> CreateTypeItemAsync(TypeItemApi typeItem);
        Task<TypeItemApi> UpdateTypeItemAsync(TypeItemApi typeItem);
        Task<bool> DeleteAsync(int id);
    }
}