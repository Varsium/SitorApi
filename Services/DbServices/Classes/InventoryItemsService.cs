using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class InventoryItemsService : IInventoryItemsService
    {
        private readonly SitorDbContext _context;

        public InventoryItemsService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<InventoryItems> GetInventoryItemsAsync(int id)
        {
            return await _context.InventoryItemsSet
                .Include(i => i.Item)
                .SingleOrDefaultAsync(e => e.InventoryItemId == id);
        }

        //Get many
        public async Task<IList<InventoryItems>> GetInventoryItemsSetAsync()
        {
            return await _context.InventoryItemsSet
                .Include(i => i.Item)
                .ToListAsync();
        }
        //create
        public async Task<InventoryItems> CreateInventoryItemAsync(InventoryItems inventoryItems)
        {
            try
            {
                _context.InventoryItemsSet.Add(inventoryItems);
                await _context.SaveChangesAsync();
                return await GetInventoryItemsAsync(inventoryItems.InventoryItemId);
            }
            catch (Exception e)
            {
                var error = new InventoryItems
                {
                    InventoryItemId = e.HResult
                };
                return error;
            }
        }

        //update
        public async Task<InventoryItems> UpdateInventoryItemsAsync(InventoryItems inventoryItems)
        {
            var dbInventoryItems = await GetInventoryItemsAsync(inventoryItems.InventoryItemId);
            if (dbInventoryItems == null)
            {
                return null;
            }

            dbInventoryItems.InventoryItemId = inventoryItems.InventoryItemId;
            dbInventoryItems.Item = inventoryItems.Item;
            await _context.SaveChangesAsync();
            return dbInventoryItems;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbInventoryList = await GetInventoryItemsAsync(id);
            if (dbInventoryList != null)
            {


                _context.InventoryItemsSet.Attach(dbInventoryList);
                _context.InventoryItemsSet.Remove(dbInventoryList);
                await _context.SaveChangesAsync();
                return true;

            }

            return false;
        }
    }
}
