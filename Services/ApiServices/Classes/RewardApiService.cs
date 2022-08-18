using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Services.ApiServices.Classes
{
    public class RewardApiService : IRewardApiService
    {
        public readonly IDatabase _database;

        public RewardApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<RewardApi> GetRewardAsync(int id)
        {
            return await Task.FromResult(_database.RewardList.SingleOrDefault(r => r.RewardId == id));
        }

        //Get many
        public async Task<IList<RewardApi>> GeRewardsAsync()
        {
            return await Task.FromResult(_database.RewardList);
        }
        //create
        public async Task<RewardApi> CreateRewardAsync(RewardApi reward)
        {
            try
            {
                _database.RewardList.Add(reward);
                return await GetRewardAsync(reward.RewardId);
            }
            catch (Exception e)
            {
                var error = new RewardApi
                {
                    Coins = e.HResult
                };
                return error;
            }
        }

        //update
        public async Task<RewardApi> UpdateRewardAsync(RewardApi reward)
        {
            var dbReward = await GetRewardAsync(reward.RewardId);
            if (dbReward == null)
            {
                return null;
            }

            dbReward.Exp = reward.Exp;
            dbReward.ItemId = reward.ItemId;
            dbReward.Coins = reward.Coins;
            return dbReward;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbReward = await GetRewardAsync(id);
            if (dbReward != null)
            {
                if (_database.RewardList.Remove(dbReward))
                {
                    return true;
                }

            }

            return false;
        }
    }
}
