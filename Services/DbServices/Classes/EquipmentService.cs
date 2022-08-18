using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class EquipmentService : IEquipmentService
    {
        private readonly SitorDbContext _context;

        public EquipmentService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<Equipment> GetEquipmentAsync(int id)
        {
            return await _context.Equipments
                .Include(e => e.EquipmentItems)
                .ThenInclude(i => i.Item)
                .SingleOrDefaultAsync(e => e.EquipmentId == id);
        }

        //Get many
        public async Task<IList<Equipment>> GetEquipmentsAsync()
        {
            var query= await _context.Equipments
                .Include(e => e.EquipmentItems)
                .ThenInclude(i => i.Item)
                .ToListAsync();

            return query;
        }

        //create
        public async Task<Equipment> CreateEquipmentAsync(Equipment equipment)
        {
            try
            {
                _context.Equipments.Add(equipment);
                await _context.SaveChangesAsync();
                return await GetEquipmentAsync(equipment.EquipmentId);
            }
            catch (Exception e)
            {
                var error = new Equipment {EquipmentId= e.HResult};
                return error;
            }
        }

        //update
        public async Task<Equipment> UpdateEquipmentAsync(Equipment Equipment)
        {
            var dbEquipment = await GetEquipmentAsync(Equipment.EquipmentId);
            if (dbEquipment == null)
            {
                return null;
            }

            dbEquipment.Name = Equipment.Name;
            dbEquipment.EquipmentItems = Equipment.EquipmentItems;
            await _context.SaveChangesAsync();
            return dbEquipment;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbEquipment = await GetEquipmentAsync(id);
            if (dbEquipment != null)
            {
                _context.Equipments.Attach(dbEquipment);
                _context.Equipments.Remove(dbEquipment);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
