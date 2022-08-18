using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface IInventoryApiService
    {
        Task<InventoryApi> GetInventoryAsync(int id);
        Task<IList<InventoryApi>> GetInventoriesAsync();
        Task<InventoryApi> CreateInventoryAsync(InventoryApi inventory);
        Task<InventoryApi> UpdateInventoryAsync(InventoryApi inventory);
        Task<bool> DeleteAsync(int id);
    }
}