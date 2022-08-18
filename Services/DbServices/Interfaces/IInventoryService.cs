using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface IInventoryService
    {
        Task<Inventory> GetInventoryAsync(int id);
        Task<IList<Inventory>> GetInventoriesAsync();
        Task<Inventory> CreateInventoryAsync(Inventory inventory);
        Task<Inventory> UpdateInventoryAsync(Inventory inventory);
        Task<bool> DeleteAsync(int id);
    }
}