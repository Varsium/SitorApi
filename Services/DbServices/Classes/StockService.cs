using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class StockService : IStockService
    {
        private readonly SitorDbContext _context;

        public StockService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<Stock> GetStockAsync(int id)
        {
            return await _context.Stocks
                .Include(s => s.Item)
                .SingleOrDefaultAsync(p => p.StockId == id);
        }

        //Get many
        public async Task<IList<Stock>> GetStocksAsync()
        {
            return await _context.Stocks
                .Include(s => s.Item)
                .ToListAsync();
        }
        //create
        public async Task<Stock> CreateStockAsync(Stock stock)
        {
            try
            {
                _context.Stocks.Add(stock);
                await _context.SaveChangesAsync();
                return await GetStockAsync(stock.StockId);
            }
            catch (Exception e)
            {
                var error = new Stock
                {
                    StockId = e.HResult
                };
                return error;
            }
        }

        //update
        public async Task<Stock> UpdateStockAsync(Stock stock)
        {
            var dbStock = await GetStockAsync(stock.StockId);
            if (dbStock == null)
            {
                return null;
            }

           
            dbStock.Item = stock.Item;
            await _context.SaveChangesAsync();
            return dbStock;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbStock = await GetStockAsync(id);
            if (dbStock != null)
            {


                _context.Stocks.Attach(dbStock);
                _context.Stocks.Remove(dbStock);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
