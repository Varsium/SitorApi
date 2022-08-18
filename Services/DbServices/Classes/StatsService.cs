using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class StatsService : IStatsService
    {
        private readonly SitorDbContext _context;

        public StatsService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<Stats> GetStatsAsync(int id)
        {
            return await _context.StatsSet.SingleOrDefaultAsync(e => e.StatsId == id);
        }

        //Get many
        public async Task<IList<Stats>> GetStatsSetAsync()
        {
            return await _context.StatsSet.ToListAsync();
        }
        //create
        public async Task<Stats> CreateStatsAsync(Stats stats)
        {
            try
            {
                _context.StatsSet.Add(stats);
                await _context.SaveChangesAsync();
                return await GetStatsAsync(stats.StatsId);
            }
            catch (Exception e)
            {
                var error = new Stats { Attack = e.HResult };
                return error;
            }
        }

        //update
        public async Task<Stats> UpdateStatsAsync(Stats stats)
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
            await _context.SaveChangesAsync();
            return dbStats;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbStats = await GetStatsAsync(id);
            if (dbStats != null)
            {
                _context.StatsSet.Attach(dbStats);
                _context.StatsSet.Remove(dbStats);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
