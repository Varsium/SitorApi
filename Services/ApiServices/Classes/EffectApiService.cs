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
    public class EffectApiService : IEffectApiService
    {
        public readonly IDatabase _database;

        public EffectApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<EffectApi> GetEffectAsync(int id)
        {
            return await Task.FromResult(_database.EffectList.SingleOrDefault(e => e.EffectId == id));
        }

        //Get many
        public async Task<IList<EffectApi>> GetEffectsAsync()
        {
            var query =  Task.FromResult(_database.EffectList);

            return await query;
        }

        //GET many on EffectIdList

        public async Task<IList<EffectApi>> GetEffectsFilteredAsync(IList<EffectListApi> effectList)
        {
            var effectsFilterdOnitemID = new List<EffectApi>();
            var query = await Task.FromResult(_database.EffectList);

            foreach (var effectdb in query)
            {
                foreach (var effect in effectList)
                {
                    if (effectdb.EffectId == effect.EffectId)
                    {
                        effectsFilterdOnitemID.Add(effectdb);
                    }
                }
            }

            return  effectsFilterdOnitemID;




        }

        //create
        public async Task<EffectApi> CreateEffectAsync(EffectApi effect)
        {
            try
            {
               _database.EffectList.Add(effect);
                return await GetEffectAsync(effect.EffectId);
            }
            catch (Exception e)
            {
                var error = new EffectApi { Attribute = e.Message };
                return error;
            }
        }

        //update
        public async Task<EffectApi> UpdateEffectAsync(EffectApi effect)
        {
            var dbEffect = await GetEffectAsync(effect.EffectId);
            if (dbEffect == null)
            {
                return null;
            }


            dbEffect.Attribute = effect.Attribute;
            dbEffect.Value = effect.Value;
            return dbEffect;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbEffect = await GetEffectAsync(id);
            if (dbEffect != null)
            {
                if (_database.EffectList.Remove(dbEffect))
                {
                    return true;
                }
               
            }

            return false;
        }
    }
}

