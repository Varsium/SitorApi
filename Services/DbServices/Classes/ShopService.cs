using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class ShopService : IShopService
    {
        private readonly SitorDbContext _context;

        public ShopService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<Shop> GetShopAsync(int id)
        {
            return await _context.Shops
                .Include(s => s.Stock)
                .ThenInclude(s => s.Item)
                .SingleOrDefaultAsync(s => s.ShopId == id);
        }

        //Get many
        public async Task<IList<Shop>> GetShopsAsync()
        {
            return await _context.Shops
                .Include(s => s.Stock)
                .ThenInclude(s => s.Item)
                
                .ToListAsync();
        }
        //create
        public async Task<Shop> CreateShopAsync(Shop shop)
        {
            try
            {
                _context.Shops.Add(shop);
                await _context.SaveChangesAsync();
                return await GetShopAsync(shop.ShopId);
            }
            catch (Exception e)
            {
                var error = new Shop { Name = e.Message };
                return error;
            }
        }

        //update
        public async Task<Shop> UpdateShopAsync(Shop shop)
        {
            var dbShop = await GetShopAsync(shop.ShopId);
            if (dbShop == null)
            {
                return null;
            }

            dbShop.Name = shop.Name;
            await _context.SaveChangesAsync();
            return dbShop;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbShop = await GetShopAsync(id);
            if (dbShop != null)
            {


                _context.Shops.Attach(dbShop);
                _context.Shops.Remove(dbShop);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
