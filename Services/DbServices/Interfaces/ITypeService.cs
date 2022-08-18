using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface ITypeService
    {
        Task<Type> GetTypeAsync(int id);
        Task<IList<Type>> GetTypesAsync();
        Task<Type> CreateTypeAsync(Type type);
        Task<Type> UpdateTypeAsync(Type type);
        Task<bool> DeleteAsync(int id);
    }
}