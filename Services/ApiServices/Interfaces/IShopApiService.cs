using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface IShopApiService
    {
        Task<ShopApi> GetShopAsync(int id);
        Task<IList<ShopApi>> GetShopsAsync();
        Task<ShopApi> CreateShopAsync(ShopApi shop);
        Task<ShopApi> UpdateShopAsync(ShopApi shop);
        Task<bool> DeleteAsync(int id);
    }
}