using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class EffectService : IEffectService
    {
        private readonly SitorDbContext _context;

        public EffectService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<Effect> GetEffectAsync(int id)
        {
            return await _context.Effects.SingleOrDefaultAsync(e => e.EffectId == id);
        }

        //Get many
        public async Task<IList<Effect>> GetEffectsAsync(int? id)
        {
            var query = _context.Effects.AsQueryable();

            if (id != null)
            {
                
                query = query.Where(e => e.EffectId == id);
            }
            return await query.ToListAsync();
        }

        //GET many on EffectIdList

        public async Task<IList<Effect>> GetEffectsFilteredAsync(IList<EffectList> effectList)
        {
            var effectsFilterdOnitemID = new List<Effect>();
            var query = await _context.Effects.ToListAsync();

            foreach (var effectdb in query)
            {
                foreach (var effect in effectList)
                {
                    if (effectdb.EffectId == effect.Effect.EffectId)
                    {
                        effectsFilterdOnitemID.Add(effectdb);
                    }
                }
            }

            return  effectsFilterdOnitemID;




        }

        //create
        public async Task<Effect> CreateEffectAsync(Effect effect)
        {
            try
            {
                _context.Effects.Add(effect);
                await _context.SaveChangesAsync();
                return await GetEffectAsync(effect.EffectId);
            }
            catch (Exception e)
            {
                var error = new Effect { Attribute = e.Message };
                return error;
            }
        }

        //update
        public async Task<Effect> UpdateEffectAsync(Effect effect)
        {
            var dbEffect = await GetEffectAsync(effect.EffectId);
            if (dbEffect == null)
            {
                return null;
            }


            dbEffect.Attribute = effect.Attribute;
            dbEffect.Value = effect.Value;
            await _context.SaveChangesAsync();
            return dbEffect;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbEffect = await GetEffectAsync(id);
            if (dbEffect != null)
            {


                _context.Effects.Attach(dbEffect);
                _context.Effects.Remove(dbEffect);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

