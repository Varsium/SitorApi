using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Services.ApiServices.Classes
{
    public class CategoryApiService : ICategoryApiService
    {
        private readonly IDatabase _database;

        public CategoryApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<CategoryApi> GetCategoryAsync(int id)
        {
            return await Task.FromResult(_database.CategoryList.SingleOrDefault(c => c.CategoryId == id));
        }

        //Get many
        public async Task<IList<CategoryApi>> GetCategoriesAsync()
        {
            return await Task.FromResult(_database.CategoryList);


        }
        //create
        public async Task<CategoryApi> CreateCategoryAsync(CategoryApi category)
        {
            try
            {
              _database.CategoryList.Add(category);
                return await GetCategoryAsync(category.CategoryId);
            }
            catch (Exception e)
            {
                var error = new CategoryApi { Name = e.Message };
                return error;
            }
        }

        //update
        public async Task<CategoryApi> UpdateCategoryAsync(CategoryApi category)
        {
            var dbCategory = await Task.FromResult(_database.CategoryList.SingleOrDefault(c => c.CategoryId == category.CategoryId));
            if (dbCategory == null)
            {
                return null;
            }

            dbCategory.Name = category.Name;

            return await GetCategoryAsync(category.CategoryId);
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbCategory = await Task.FromResult(_database.CategoryList.SingleOrDefault(c => c.CategoryId == id));
            if (dbCategory != null)
            {

                if (_database.CategoryList.Remove(dbCategory))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
