using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Services.DbServices.Interfaces;
using Type = SitorApi.Models.DbModels.Type;

namespace SitorApi.Services.DbServices.Classes
{
    public class TypeService : ITypeService
    {
        private readonly SitorDbContext _context;

        public TypeService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<Type> GetTypeAsync(int id)
        {
            return await _context.Types
                .Include(t => t.Items)
                .ThenInclude(i => i.Item)
                .SingleOrDefaultAsync(t => t.TypeId == id);
        }

        //Get many
        public async Task<IList<Type>> GetTypesAsync()
        {
            return await _context.Types
                .Include(t => t.Items)
                .ThenInclude(i => i.Item)
                .ToListAsync();
        }
        //create
        public async Task<Type> CreateTypeAsync(Type type)
        {
            try
            {
                _context.Types.Add(type);
                await _context.SaveChangesAsync();
                return await GetTypeAsync(type.TypeId);
            }
            catch (Exception e)
            {
                var error = new Type { type = e.Message };
                return error;
            }
        }

        //update
        public async Task<Type> UpdateTypeAsync(Type type)
        {
            var dbType = await GetTypeAsync(type.TypeId);
            if (dbType == null)
            {
                return null;
            }

            //dbType.Name = type.Name;
            dbType.type = type.type;
            await _context.SaveChangesAsync();
            return dbType;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbType = await GetTypeAsync(id);
            if (dbType != null)
            {


                _context.Types.Attach(dbType);
                _context.Types.Remove(dbType);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

