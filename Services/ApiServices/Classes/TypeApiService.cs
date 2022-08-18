using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;


namespace SitorApi.Services.ApiServices.Classes
{
    public class TypeApiService : ITypeApiService
    {
        private readonly IDatabase _database;

        public TypeApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<TypeApi> GetTypeAsync(int id)
        {
            return await Task.FromResult(_database.TypeList.SingleOrDefault(t => t.TypeId == id));
        }

        //Get many
        public async Task<IList<TypeApi>> GetTypesAsync()
        {
            return await Task.FromResult(_database.TypeList);
        }
        //create
        public async Task<TypeApi> CreateTypeAsync(TypeApi type)
        {
            try
            {
                _database.TypeList.Add(type);
                return await GetTypeAsync(type.TypeId);
            }
            catch (Exception e)
            {
                var error = new TypeApi { type = e.Message };
                return error;
            }
        }

        //update
        public async Task<TypeApi> UpdateTypeAsync(TypeApi type)
        {
            var dbType = await GetTypeAsync(type.TypeId);
            if (dbType == null)
            {
                return null;
            }

            dbType.CategoryId = type.CategoryId;
            dbType.type = type.type;
            return dbType;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbType = await GetTypeAsync(id);
            if (dbType != null)
            {

                if (_database.TypeList.Remove(dbType))
                {
                    return true;
                }

            }

            return false;
        }
    }
}

