using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class BackgroundService : IBackgroundService
    {
        private readonly SitorDbContext _context;

        public BackgroundService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<Background> GetBackgroundAsync(int id)
        {
            return await _context.Backgrounds.SingleOrDefaultAsync(b => b.BackgroundId == id);
        }

        //Get many
        public async Task<IList<Background>> GetBackgroundsAsync()
        {
            return await _context.Backgrounds.ToListAsync();
        }
        //create
        public async Task<Background> CreateBackground(Background background)
        {
            try
            {
                await _context.Backgrounds.AddAsync(background);
                await _context.SaveChangesAsync();
                return await GetBackgroundAsync(background.BackgroundId);
            }
            catch (Exception e)
            {
                var error = new Background
                {
                    Name = e.Message
                };
                return error;
            }
        }

        //update
        public async Task<Background> UpdateBackgroundAsync(Background background)
        {
            var dbBackground = await _context.Backgrounds.SingleOrDefaultAsync(b => b.BackgroundId == background.BackgroundId);
            if (dbBackground == null)
            {
                return null;
            }

            dbBackground.Image = background.Image;
            dbBackground.Name = background.Name;
            await _context.SaveChangesAsync();
            return await GetBackgroundAsync(background.BackgroundId);
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbBackground = await _context.Backgrounds.SingleOrDefaultAsync(b => b.BackgroundId == id);
            if (dbBackground != null)
            {


                _context.Backgrounds.Attach(dbBackground);

                _context.Backgrounds.Remove(dbBackground);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

    }
}
