using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Models.DbModels;
using SitorApi.Services.ApiServices.Interfaces;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.ApiServices.Classes
{
    public class ShopApiService : IShopApiService
    {
        private readonly IDatabase _database;

        public ShopApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<ShopApi> GetShopAsync(int id)
        {
            return await Task.FromResult(_database.ShopList.SingleOrDefault(s => s.ShopId == id));
        }

        //Get many
        public async Task<IList<ShopApi>> GetShopsAsync()
        {
            return await Task.FromResult(_database.ShopList);
        }
        //create
        public async Task<ShopApi> CreateShopAsync(ShopApi shop)
        {
            try
            {
                _database.ShopList.Add(shop);
                return await GetShopAsync(shop.ShopId);
            }
            catch (Exception e)
            {
                var error = new ShopApi { Name = e.Message };
                return error;
            }
        }

        //update
        public async Task<ShopApi> UpdateShopAsync(ShopApi shop)
        {
            var dbShop = await GetShopAsync(shop.ShopId);
            if (dbShop == null)
            {
                return null;
            }

            dbShop.Name = shop.Name;
            return dbShop;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbShop = await GetShopAsync(id);
            if (dbShop != null)
            {
                if (_database.ShopList.Remove(dbShop))
                {
                    return true;
                }

            }

            return false;
        }
    }
}
