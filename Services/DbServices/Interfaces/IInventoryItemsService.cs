using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface IInventoryItemsService
    {
        Task<InventoryItems> GetInventoryItemsAsync(int id);
        Task<IList<InventoryItems>> GetInventoryItemsSetAsync();
        Task<InventoryItems> CreateInventoryItemAsync(InventoryItems inventoryItems);
        Task<InventoryItems> UpdateInventoryItemsAsync(InventoryItems inventoryItems);
        Task<bool> DeleteAsync(int id);
    }
}