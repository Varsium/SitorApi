using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Classes
{
    public class EquipmentItemsService
    {
        private readonly SitorDbContext _context;

        public EquipmentItemsService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<EquipmentItems> GetEquipmentItemsAsync(int id)
        {
            return await _context.EquipmentItemsSet.SingleOrDefaultAsync(e => e.EquipmentItemsId == id);
        }

        //Get many
        public async Task<IList<EquipmentItems>> GetEquipmentItemsListsAsync()
        {

            var query = _context.EquipmentItemsSet.ToListAsync();

            return await query;
        }
        //create
        public async Task<EquipmentItems> CreateEquipmentItemsAsync(EquipmentItems equipmentItems)
        {
            try
            {
                _context.EquipmentItemsSet.Add(equipmentItems);
                await _context.SaveChangesAsync();
                return await GetEquipmentItemsAsync(equipmentItems.EquipmentItemsId);
            }
            catch (Exception e)
            {
                var error = new EquipmentItems { EquipmentItemsId = e.HResult };
                return error;
            }
        }

        //update
        public async Task<EquipmentItems> UpdateEquipmentItemsAsync(EquipmentItems equipmentItems)
        {
            var dbEffectList = await GetEquipmentItemsAsync(equipmentItems.EquipmentItemsId);
            if (dbEffectList == null)
            {
                return null;
            }

            dbEffectList.Item = equipmentItems.Item;
         
            await _context.SaveChangesAsync();
            return dbEffectList;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var equipmentItems = await GetEquipmentItemsAsync(id);
            if (equipmentItems != null)
            {


                _context.EquipmentItemsSet.Attach(equipmentItems);
                _context.EquipmentItemsSet.Remove(equipmentItems);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

