using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Services.ApiServices.Classes
{
    public class BackgroundApiService : IBackgroundApiService
    {
        private readonly IDatabase _database;

        public BackgroundApiService(IDatabase database)
        {
            _database = database;
        }


        //Get one 
        public async Task<BackgroundApi> GetBackgroundAsync(int id)
        {
            return await Task.FromResult(_database.BackgroundList.SingleOrDefault(b => b.BackgroundId == id));
        }

        //Get many
        public async Task<IList<BackgroundApi>> GetBackgroundsAsync()
        {
            return await Task.FromResult(_database.BackgroundList);
        }
        //create
        public async Task<BackgroundApi> CreateBackground(BackgroundApi backgroundApi)
        {
            try
            {
                _database.BackgroundList.Add(backgroundApi);
                return await GetBackgroundAsync(backgroundApi.BackgroundId);
            }
            catch (Exception e)
            {
                var error = new BackgroundApi
                {
                    Name = e.Message
                };
                return error;
            }
        }

        //update
        public async Task<BackgroundApi> UpdateBackgroundAsync(BackgroundApi BackgroundApi)
        {
            var dbBackground = await Task.FromResult(_database.BackgroundList.SingleOrDefault(b => b.BackgroundId == BackgroundApi.BackgroundId));
            if (dbBackground == null)
            {
                return null;
            }

            dbBackground.Image = BackgroundApi.Image;
            dbBackground.Name = BackgroundApi.Name;
            return await GetBackgroundAsync(BackgroundApi.BackgroundId);
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbBackground = await Task.FromResult(_database.BackgroundList.SingleOrDefault(b => b.BackgroundId == id));
            if (dbBackground != null)
            {
                if (_database.BackgroundList.Remove(dbBackground))
                {
                    return true;
                }
            }
            return false;

        }

    }
}
