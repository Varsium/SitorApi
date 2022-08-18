using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Services.ApiServices.Classes
{
    public class InventoryItemsApiService : IInventoryItemsApiService
    {
        public readonly IDatabase _database;

        public InventoryItemsApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<InventoryItemsApi> GetInventoryItemsAsync(int id)
        {
            return await Task.FromResult(_database.InventoryItemsList.SingleOrDefault(e => e.InventoryItemId == id));
        }

        //Get many
        public async Task<IList<InventoryItemsApi>> GetInventoriesItemsAsync()
        {
            var query = Task.FromResult(_database.InventoryItemsList);

            return await query;
        }


        //create
        public async Task<InventoryItemsApi> CreateInventoryItemstAsync(InventoryItemsApi inventoryItems)
        {
            try
            {
                _database.InventoryItemsList.Add(inventoryItems);
                return await GetInventoryItemsAsync(inventoryItems.InventoryId);
            }
            catch (Exception e)
            {
                var error = new InventoryItemsApi { InventoryItemId = e.HResult };
                return error;
            }
        }

        //update
        public async Task<InventoryItemsApi> UpdateInventoryItemsAsync(InventoryItemsApi inventoryItems)
        {
            var dbInventoryItems = await GetInventoryItemsAsync(inventoryItems.InventoryItemId);
            if (dbInventoryItems == null)
            {
                return null;
            }


            dbInventoryItems.ItemId = inventoryItems.ItemId;
            dbInventoryItems.InventoryId = inventoryItems.InventoryId;
            return dbInventoryItems;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbInventoryItems = await GetInventoryItemsAsync(id);
            if (dbInventoryItems != null)
            {
                if (_database.InventoryItemsList.Remove(dbInventoryItems))
                {
                    return true;
                }

            }

            return false;
        }
    }
}