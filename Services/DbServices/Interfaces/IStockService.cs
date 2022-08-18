using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface IStockService
    {
        Task<Stock> GetStockAsync(int id);
        Task<IList<Stock>> GetStocksAsync();
        Task<Stock> CreateStockAsync(Stock stock);
        Task<Stock> UpdateStockAsync(Stock stock);
        Task<bool> DeleteAsync(int id);
    }
}