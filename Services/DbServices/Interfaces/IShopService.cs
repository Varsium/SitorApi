using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface IShopService
    {
        Task<Shop> GetShopAsync(int id);
        Task<IList<Shop>> GetShopsAsync();
        Task<Shop> CreateShopAsync(Shop shop);
        Task<Shop> UpdateShopAsync(Shop shop);
        Task<bool> DeleteAsync(int id);
    }
}