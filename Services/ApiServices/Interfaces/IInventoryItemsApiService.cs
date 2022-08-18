using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface IInventoryItemsApiService
    {
        Task<InventoryItemsApi> GetInventoryItemsAsync(int id);
        Task<IList<InventoryItemsApi>> GetInventoriesItemsAsync();
        Task<InventoryItemsApi> CreateInventoryItemstAsync(InventoryItemsApi inventoryItems);
        Task<InventoryItemsApi> UpdateInventoryItemsAsync(InventoryItemsApi inventoryItems);
        Task<bool> DeleteAsync(int id);
    }
}