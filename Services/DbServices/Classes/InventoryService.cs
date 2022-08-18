using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class InventoryService : IInventoryService
    {
        private readonly SitorDbContext _context;

        public InventoryService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<Inventory> GetInventoryAsync(int id)
        {
            return await _context.Inventories
                .Include(i => i.Items)
                .ThenInclude(i => i.Item)
                .SingleOrDefaultAsync(e => e.InventoryId == id);
        }

        //Get many
        public async Task<IList<Inventory>> GetInventoriesAsync()
        {
            return await _context.Inventories
                .Include(i => i.Items)
                .ThenInclude(i => i.Item)
                .ToListAsync();
        }
        //create
        public async Task<Inventory> CreateInventoryAsync(Inventory inventory)
        {
            try
            {
                _context.Inventories.Add(inventory);
                await _context.SaveChangesAsync();
                return await GetInventoryAsync(inventory.InventoryId);
            }
            catch (Exception e)
            {
                var invo = new Inventory
                {
                    Name = e.Message
                };
                return invo;
            }
        }

        //update
        public async Task<Inventory> UpdateInventoryAsync(Inventory inventory)
        {
            var dbInventory = await GetInventoryAsync(inventory.InventoryId);
            if (dbInventory == null)
            {
                return null;
            }

            dbInventory.Name = inventory.Name;
            await _context.SaveChangesAsync();
            return dbInventory;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbInventory = await GetInventoryAsync(id);
            if (dbInventory != null)
            {


                _context.Inventories.Attach(dbInventory);
                _context.Inventories.Remove(dbInventory);
                await _context.SaveChangesAsync();
                return true;

            }

            return false;
        }
    }
}
