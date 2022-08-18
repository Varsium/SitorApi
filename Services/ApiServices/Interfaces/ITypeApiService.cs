using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface ITypeApiService
    {
        Task<TypeApi> GetTypeAsync(int id);
        Task<IList<TypeApi>> GetTypesAsync();
        Task<TypeApi> CreateTypeAsync(TypeApi type);
        Task<TypeApi> UpdateTypeAsync(TypeApi type);
        Task<bool> DeleteAsync(int id);
    }
}