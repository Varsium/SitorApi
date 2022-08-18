using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class StageService : IStageService
    {
        private readonly SitorDbContext _context;

        public StageService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<Stage> GetStageAsync(int id)
        {
            return await _context.Stages
                .Include(s => s.Background)
                .Include(s => s.Character.Stats)
                .Include(s => s.Character)
                .ThenInclude(c => c.Equipment)
                .ThenInclude(e => e.EquipmentItems)
                .ThenInclude(i => i.Item)
                .Include(s => s.Reward)
                .ThenInclude(r => r.Item)
                .SingleOrDefaultAsync(e => e.StageId == id);
        }

        //Get many
        public async Task<IList<Stage>> GetStagesAsync()
        {
            return await _context.Stages
                .Include(s => s.Background)
                .Include(s => s.Character.Stats)
                .Include(s => s.Character)
                .ThenInclude(c => c.Equipment)
                .ThenInclude(e => e.EquipmentItems)
                .ThenInclude(i => i.Item)
                .Include(s => s.Reward)
                .ThenInclude(r => r.Item)
                .ToListAsync();
        }
        //create
        public async Task<Stage> CreateStageAsync(Stage stage)
        {
            try
            {
                _context.Stages.Add(stage);
                await _context.SaveChangesAsync();
                return await GetStageAsync(stage.StageId);
            }
            catch (Exception e)
            {
                var error = new Stage { Name = e.Message };
                return error;
            }
        }

        //update
        public async Task<Stage> UpdateStageAsync(Stage stage)
        {
            var dbStage = await GetStageAsync(stage.StageId);
            if (dbStage == null)
            {
                return null;
            }

            dbStage.Background = stage.Background;
            dbStage.Character = stage.Character;
            dbStage.Name = stage.Name;
            dbStage.Reward = stage.Reward;
            await _context.SaveChangesAsync();
            return dbStage;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbStage = await GetStageAsync(id);
            if (dbStage != null)
            {


                _context.Stages.Attach(dbStage);
                _context.Stages.Remove(dbStage);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
