using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Services.ApiServices.Classes
{
    public class EquipmentItemsApiService : IEquipmentItemsApiService
    {
        private readonly IDatabase _database;

        public EquipmentItemsApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<EquipmentItemsApi> GetEquipmentItemsAsync(int id)
        {
            return await Task.FromResult(_database.EquipmentItemsList.SingleOrDefault(e => e.EquipmentItemsId == id));

        }

        //Get many
        public async Task<IList<EquipmentItemsApi>> GetEquipmentItemssAsync()
        {
            return await Task.FromResult(_database.EquipmentItemsList);
        }

        //create
        public async Task<EquipmentItemsApi> CreateEquipmentItemsAsync(EquipmentItemsApi equipment)
        {
            try
            {
                _database.EquipmentItemsList.Add(equipment);
                return await GetEquipmentItemsAsync(equipment.EquipmentItemsId);
            }
            catch (Exception e)
            {
                var error = new EquipmentItemsApi { EquipmentItemsId = e.HResult };
                return error;
            }
        }

        //update
        public async Task<EquipmentItemsApi> UpdateEquipmentItemsAsync(EquipmentItemsApi equipment)
        {
            var dbEquipmentItems = await GetEquipmentItemsAsync(equipment.EquipmentItemsId);
            if (dbEquipmentItems == null)
            {
                return null;
            }

            dbEquipmentItems.ItemId = equipment.ItemId;
            dbEquipmentItems.EquipmentId = equipment.EquipmentId;
            return dbEquipmentItems;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbEquipmentItems = await GetEquipmentItemsAsync(id);
            if (dbEquipmentItems != null)
            {
                if (_database.EquipmentItemsList.Remove(dbEquipmentItems))
                {
                    return true;
                }

            }

            return false;
        }
    }
}