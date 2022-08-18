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


    public class EffectlistApiService : IEffectlistApiService
    {
        private readonly IDatabase _database;

        public EffectlistApiService(IDatabase database)
        {
            _database = database;
        }


        //Get one 
        public async Task<EffectListApi> GetEffectListAsync(int id)
        {
            return await Task.FromResult(_database.EffectListSet.SingleOrDefault(e => e.EffectListId == id));
        }

        //Get many
        public async Task<IList<EffectListApi>> GetEffectListSetAsync()
        {

            return await Task.FromResult(_database.EffectListSet);
        }
        //create
        public async Task<EffectListApi> CreateEffectListAsync(EffectListApi effectList)
        {
            try
            {
                _database.EffectListSet.Add(effectList);

                return await GetEffectListAsync(effectList.EffectListId);
            }
            catch (Exception e)
            {
                var error = new EffectListApi { EffectListId = e.HResult };
                return error;
            }
        }

        //update
        public async Task<EffectListApi> UpdateEffectListSetAsync(EffectListApi effectList)
        {
            var dbEffectListSet = await GetEffectListAsync(effectList.EffectListId);
            if (dbEffectListSet == null)
            {
                return null;
            }

            dbEffectListSet.ItemId = effectList.ItemId;
            dbEffectListSet.EffectId = effectList.EffectId;

            return dbEffectListSet;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbEffectListSet = await GetEffectListAsync(id);
            if (dbEffectListSet != null)
            {


                if (_database.EffectListSet.Remove(dbEffectListSet))
                {
                    return true;
                }

            }

            return false;
        }
    }
}