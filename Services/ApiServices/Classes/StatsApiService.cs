using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Services.ApiServices.Classes
{
    public class StatsApiService : IStatsApiService
    {
        public readonly IDatabase _database;

        public StatsApiService(IDatabase database)
        {

            _database = database;
        }

        //Get one 
        public async Task<StatsApi> GetStatsAsync(int id)
        {
            return await Task.FromResult(_database.StatsList.SingleOrDefault(s => s.StatsId == id));
        }

        //Get many
        public async Task<IList<StatsApi>> GetStatsSetAsync()
        {
            return await Task.FromResult(_database.StatsList);
        }
        //create
        public async Task<StatsApi> CreateStatsAsync(StatsApi stats)
        {
            try
            {
                _database.StatsList.Add(stats);
                return await GetStatsAsync(stats.StatsId);
            }
            catch (Exception e)
            {
                var error = new StatsApi { Attack = e.HResult };
                return error;
            }
        }

        //update
        public async Task<StatsApi> UpdateStatsAsync(StatsApi stats)
        {
            var dbStats = await GetStatsAsync(stats.StatsId);
            if (dbStats == null)
            {
                return null;
            }

            dbStats.Lifepoints = stats.Lifepoints;
            dbStats.Attack = stats.Attack;
            dbStats.Defence = stats.Defence;
            dbStats.Strength = stats.Strength;

            return dbStats;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbStats = await GetStatsAsync(id);
            if (dbStats != null)
            {
                if (_database.StatsList.Remove(dbStats))
                {
                    return true;
                }

            }

            return false;
        }
    }
}
