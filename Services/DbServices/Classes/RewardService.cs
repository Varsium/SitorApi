using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class RewardService : IRewardService
    {
        private readonly SitorDbContext _context;

        public RewardService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<Reward> GetRewardAsync(int id)
        {
            return await _context.Rewards
                .Include(r => r.Item)
                .SingleOrDefaultAsync(r => r.RewardId == id);
        }

        //Get many
        public async Task<IList<Reward>> GeRewardsAsync()
        {
            return await _context.Rewards
                .Include(r => r.Item)
                .ToListAsync();
        }
        //create
        public async Task<Reward> CreateRewardAsync(Reward reward)
        {
            try
            {
                _context.Rewards.Add(reward);
                await _context.SaveChangesAsync();
                return await GetRewardAsync(reward.RewardId);
            }
            catch (Exception e)
            {
                var error = new Reward
                {
                    Coins = e.HResult
                };
                return error;
            }
        }

        //update
        public async Task<Reward> UpdateRewardAsync(Reward reward)
        {
            var dbReward = await GetRewardAsync(reward.RewardId);
            if (dbReward == null)
            {
                return null;
            }

            dbReward.Exp = reward.Exp;
            dbReward.Item = reward.Item;
            dbReward.Coins = reward.Coins;
            await _context.SaveChangesAsync();
            return dbReward;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbReward = await GetRewardAsync(id);
            if (dbReward != null)
            {


                _context.Rewards.Attach(dbReward);
                _context.Rewards.Remove(dbReward);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
