using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class CategoryService : ICategoryService
    {
        private readonly SitorDbContext _context;

        public CategoryService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.Types)
                .ThenInclude(t => t.Type)
                .ThenInclude(t => t.Items)
                .ThenInclude(i => i.Item)
                .ThenInclude(t => t.Effects)
                .ThenInclude(e => e.Effect)
                .SingleOrDefaultAsync(c => c.CategoryId == id);
        }

        //Get many
        public async Task<IList<Category>> GetCategoriesAsync()
        {
            return await _context.Categories
                .Include(c => c.Types)
                .ThenInclude(t => t.Type)
                .ThenInclude(t => t.Items)
                .ThenInclude(i => i.Item)
                .ThenInclude(t => t.Effects)
                .ThenInclude(e => e.Effect)
                .ToListAsync();


        }
        //create
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return await GetCategoryAsync(category.CategoryId);
            }
            catch (Exception e)
            {
                var error = new Category { Name = e.Message };
                return error;
            }
        }

        //update
        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var dbCategory = await _context.Categories.SingleOrDefaultAsync(c => c.CategoryId == category.CategoryId);
            if (dbCategory == null)
            {
                return null;
            }

            dbCategory.Name = category.Name;
            // dbCategory.TypeId = category.TypeId;
            await _context.SaveChangesAsync();
            return await GetCategoryAsync(category.CategoryId);
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbCategory = await _context.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);
            if (dbCategory != null)
            {

                _context.Categories.Attach(dbCategory);

                _context.Categories.Remove(dbCategory);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
