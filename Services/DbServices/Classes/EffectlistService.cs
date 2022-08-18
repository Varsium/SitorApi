using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class EffectListService : IEffectlistService
    {
        private readonly SitorDbContext _context;

        public EffectListService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<EffectList> GetEffectListAsync(int id)
        {
            return await _context.EffectLists.SingleOrDefaultAsync(e => e.EffectListId == id);
        }

        //Get many
        public async Task<IList<EffectList>> GetEffectListsAsync()
        {

            var query = _context.EffectLists.AsQueryable();


            //if (id != null)
            //{

            //    query = query.Where(e => e.Effect. == id);
            //}
            return await query.ToListAsync();
        }
        //create
        public async Task<EffectList> CreateEffectAsync(EffectList effectList)
        {
            try
            {
                _context.EffectLists.Add(effectList);
                await _context.SaveChangesAsync();
                return await GetEffectListAsync(effectList.EffectListId);
            }
            catch (Exception e)
            {
                var error = new EffectList { EffectListId = e.HResult };
                return error;
            }
        }

        //update
        public async Task<EffectList> UpdateEffectListAsync(EffectList effectList)
        {
            var dbEffectList = await GetEffectListAsync(effectList.EffectListId);
            if (dbEffectList == null)
            {
                return null;
            }

           // dbEffectList.Item =effectList.Item;
            dbEffectList.Effect =effectList.Effect;
            await _context.SaveChangesAsync();
            return dbEffectList;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbEffectList = await GetEffectListAsync(id);
            if (dbEffectList != null)
            {


                _context.EffectLists.Attach(dbEffectList);
                _context.EffectLists.Remove(dbEffectList);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}