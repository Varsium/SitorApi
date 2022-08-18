using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class ItemService : IItemService
    {
        private readonly SitorDbContext _context;

        public ItemService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<Item> GetItemAsync(int id)
        {
            var query = await _context.Items
                .Include(i => i.Effects)
                .ThenInclude(e => e.Effect)
                .SingleOrDefaultAsync(i => i.ItemId == id);

            return query;
        }

        //Get many
        public async Task<IList<Item>> GetAllItemsAsync()
        {


            return await _context.Items
                .Include(i => i.Effects)
                .ThenInclude(e => e.Effect)
                .ToListAsync();

            

        }
        //create
        public async Task<Item> CreateItem(Item item)
        {
            try
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception e)
            {
                var error = new Item { Name = e.Message };
                return error;
            }
        }

        //update
        public async Task<Item> UpdateItem(Item item)
        {
            var dbItem = new Item { ItemId = item.ItemId };
            _context.Items.Attach(dbItem);
           // dbItem.CategoryId = item.CategoryId;
            dbItem.Cost = item.Cost;
            dbItem.Name = item.Name;
            dbItem.Image = item.Image;
            await _context.SaveChangesAsync();
            return item;
        }

        // DeleteAsync
        public async Task<bool> Delete(int id)
        {
            var dbItem = new Item { ItemId = id };
            _context.Items.Attach(dbItem);
            _context.Items.Remove(dbItem);
            if (await _context.SaveChangesAsync() == 0)
            {
                return false;
            }

            return true;
        }
    }
}

