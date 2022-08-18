using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface IStockApiService
    {
        Task<StockApi> GetStockAsync(int id);
        Task<IList<StockApi>> GetStocksAsync();
        Task<StockApi> CreateStockAsync(StockApi stock);
        Task<StockApi> UpdateStockAsync(StockApi stock);
        Task<bool> DeleteAsync(int id);
    }
}