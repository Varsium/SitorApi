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
    public class ItemApiService : IItemApiService
    {
        private readonly IDatabase _database;

        public ItemApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<ItemApi> GetItemAsync(int id)
        {
            return await Task.FromResult(_database.ItemList.SingleOrDefault(i => i.ItemId == id));
        }

        //Get many
        public async Task<IList<ItemApi>> GetAllItemsAsync()
        {


            return await Task.FromResult(_database.ItemList);



        }
        //create
        public async Task<ItemApi> CreateItem(ItemApi item)
        {
            try
            {
                _database.ItemList.Add(item);
                return await GetItemAsync(item.ItemId);
            }
            catch (Exception e)
            {
                var error = new ItemApi { Name = e.Message };
                return error;
            }
        }

        //update
        public async Task<ItemApi> UpdateItem(ItemApi item)
        {
            var dbItem = await GetItemAsync(item.ItemId);
            dbItem.Cost = item.Cost;
            dbItem.Name = item.Name;
            dbItem.Image = item.Image;
            

            return item;
        }

        // DeleteAsync
        public async Task<bool> Delete(int id)
        {
            var dbItem = await GetItemAsync(id);

            if (_database.ItemList.Remove(dbItem))
            {
                return true;
            }

            return false;
        }
    }
}

