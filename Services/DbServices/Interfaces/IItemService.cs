using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface IItemService
    {
        Task<Item> GetItemAsync(int id);
        Task<IList<Item>> GetAllItemsAsync();
        Task<Item> CreateItem(Item item);
        Task<Item> UpdateItem(Item item);
        Task<bool> Delete(int id);
    }
}