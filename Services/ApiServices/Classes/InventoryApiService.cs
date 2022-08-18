using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Models.DbModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Services.ApiServices.Classes
{
    public class InventoryApiService : IInventoryApiService
    {
        private readonly IDatabase _database;

        public InventoryApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<InventoryApi> GetInventoryAsync(int id)
        {
            return await Task.FromResult(_database.InventoryList.SingleOrDefault(e => e.InventoryId == id));
        }

        //Get many
        public async Task<IList<InventoryApi>> GetInventoriesAsync()
        {
            var query = Task.FromResult(_database.InventoryList);

            return await query;
        }

        //GET many on EffectIdList

        //public async Task<IList<InventoryApi>> GetInventoriesFilteredAsync(IList<InventoryApi> inventoryList)
        //{
        //    var inventorysFilterdOnitemID = new List<InventoryApi>();
        //    var query = await Task.FromResult(_database.EffectList);

        //    foreach (var inventorydb in query)
        //    {
        //        foreach (var Inventory in inventoryList)
        //        {
        //            if (inventorydb.EffectId == Inventory.EffectId)
        //            {
        //                inventorysFilterdOnitemID.Add(inventorydb);
        //            }
        //        }
        //    }

        //    return inventorysFilterdOnitemID;




        //}

        //create
        public async Task<InventoryApi> CreateInventoryAsync(InventoryApi inventory)
        {
            try
            {
                _database.InventoryList.Add(inventory);
                return await GetInventoryAsync(inventory.InventoryId);
            }
            catch (Exception e)
            {
                var error = new InventoryApi { Name = e.Message };
                return error;
            }
        }

        //update
        public async Task<InventoryApi> UpdateInventoryAsync(InventoryApi inventory)
        {
            var dbInventory = await GetInventoryAsync(inventory.InventoryId);
            if (dbInventory == null)
            {
                return null;
            }


            dbInventory.Name = inventory.Name;
            return dbInventory;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbInventory = await GetInventoryAsync(id);
            if (dbInventory != null)
            {
                if (_database.InventoryList.Remove(dbInventory))
                {
                    return true;
                }

            }

            return false;
        }
    }
}
