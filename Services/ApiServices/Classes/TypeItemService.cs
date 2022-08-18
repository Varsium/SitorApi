using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Services.ApiServices.Classes
{
    public class TypeItemApiService : ITypeItemApiService
    {
        private readonly IDatabase _database;

        public TypeItemApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<TypeItemApi> GetTypeItemAsync(int id)
        {
            return await Task.FromResult(_database.TypeItemList.SingleOrDefault(t => t.TypeItemId == id));
        }

        //Get many
        public async Task<IList<TypeItemApi>> GetTypeItemsAsync()
        {
            return await Task.FromResult(_database.TypeItemList);
        }
        //create
        public async Task<TypeItemApi> CreateTypeItemAsync(TypeItemApi typeItem)
        {
            try
            {
                _database.TypeItemList.Add(typeItem);
                return await GetTypeItemAsync(typeItem.TypeItemId);
            }
            catch (Exception e)
            {
                var error = new TypeItemApi { TypeItemId = e.HResult };
                return error;
            }
        }

        //update
        public async Task<TypeItemApi> UpdateTypeItemAsync(TypeItemApi typeItem)
        {
            var dbTypeItem = await GetTypeItemAsync(typeItem.TypeItemId);
            if (dbTypeItem == null)
            {
                return null;
            }

            dbTypeItem.TypeId = typeItem.TypeId;
            dbTypeItem.ItemId = typeItem.ItemId;
            return dbTypeItem;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbTypeItem = await GetTypeItemAsync(id);
            if (dbTypeItem != null)
            {

                if (_database.TypeItemList.Remove(dbTypeItem))
                {
                    return true;
                }

            }

            return false;
        }
    }
}