using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Services.ApiServices.Classes
{
    public class CategoryTypeApiService : ICategoryTypeApiService
    {
        private readonly IDatabase _database;

        public CategoryTypeApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<CategoryTypeApi> GetCategoryTypeAsync(int id)
        {
            return await Task.FromResult(_database.CategoryTypeList.SingleOrDefault(e => e.CategoryTypeId == id));

        }

        //Get many
        public async Task<IList<CategoryTypeApi>> GetCategoryTypesAsync()
        {
            return await Task.FromResult(_database.CategoryTypeList);
        }

        //create
        public async Task<CategoryTypeApi> CreateCategoryTypeAsync(CategoryTypeApi equipment)
        {
            try
            {
                _database.CategoryTypeList.Add(equipment);
                return await GetCategoryTypeAsync(equipment.CategoryTypeId);
            }
            catch (Exception e)
            {
                var error = new CategoryTypeApi { CategoryTypeId = e.HResult };
                return error;
            }
        }

        //update
        public async Task<CategoryTypeApi> UpdateCategoryTypeAsync(CategoryTypeApi equipment)
        {
            var dbCategoryType = await GetCategoryTypeAsync(equipment.CategoryTypeId);
            if (dbCategoryType == null)
            {
                return null;
            }

            dbCategoryType.TypeId = equipment.TypeId;
            dbCategoryType.CategoryId = equipment.CategoryId;
            return dbCategoryType;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbCategoryType = await GetCategoryTypeAsync(id);
            if (dbCategoryType != null)
            {
                if (_database.CategoryTypeList.Remove(dbCategoryType))
                {
                    return true;
                }

            }

            return false;
        }
    }
}
