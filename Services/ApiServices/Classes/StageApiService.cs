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
    public class StageApiService : IStageApiService
    {
        private readonly IDatabase _database;

        public StageApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<StageApi> GetStageAsync(int id)
        {
            return await Task.FromResult(_database.StageList.SingleOrDefault(s => s.StageId == id));
        }

        //Get many
        public async Task<IList<StageApi>> GetStagesAsync()
        {
            return await Task.FromResult(_database.StageList);
        }
        //create
        public async Task<StageApi> CreateStageAsync(StageApi stage)
        {
            try
            {
                _database.StageList.Remove(stage);
                return await GetStageAsync(stage.StageId);
            }
            catch (Exception e)
            {
                var error = new StageApi { Name = e.Message };
                return error;
            }
        }

        //update
        public async Task<StageApi> UpdateStageAsync(StageApi stage)
        {
            var dbStage = await GetStageAsync(stage.StageId);
            if (dbStage == null)
            {
                return null;
            }

            dbStage.BackgroundId = stage.BackgroundId;
            dbStage.CharacterId = stage.CharacterId;
            dbStage.Name = stage.Name;
            dbStage.RewardId = stage.RewardId;
            return dbStage;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbStage = await GetStageAsync(id);
            if (dbStage != null)
            {
                if (_database.StageList.Remove(dbStage))
                {
                    return true;
                }

            }

            return false;
        }
    }
}
