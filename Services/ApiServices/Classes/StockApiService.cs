using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Services.ApiServices.Classes
{
    public class StockApiService : IStockApiService
    {
        private readonly IDatabase _database;

        public StockApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<StockApi> GetStockAsync(int id)
        {
            return await Task.FromResult(_database.StockList.SingleOrDefault(s => s.StockId == id));
        }

        //Get many
        public async Task<IList<StockApi>> GetStocksAsync()
        {
            return await Task.FromResult(_database.StockList);
        }
        //create
        public async Task<StockApi> CreateStockAsync(StockApi stock)
        {
            try
            {
                _database.StockList.Add(stock);
                return await GetStockAsync(stock.StockId);
            }
            catch (Exception e)
            {
                var error = new StockApi { StockId = e.HResult };
                return error;
            }
        }

        //update
        public async Task<StockApi> UpdateStockAsync(StockApi stock)
        {
            var dbStock = await GetStockAsync(stock.StockId);
            if (dbStock == null)
            {
                return null;
            }

            dbStock.ItemId = stock.ItemId;
            dbStock.ShopId = stock.ShopId;
            return dbStock;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbStock = await GetStockAsync(id);
            if (dbStock != null)
            {
                if (_database.StockList.Remove(dbStock))
                {
                    return true;
                }

            }

            return false;
        }
    }
}
