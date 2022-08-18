using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface IItemApiService
    {
        Task<ItemApi> GetItemAsync(int id);
        Task<IList<ItemApi>> GetAllItemsAsync();
        Task<ItemApi> CreateItem(ItemApi item);
        Task<ItemApi> UpdateItem(ItemApi item);
        Task<bool> Delete(int id);
    }
}