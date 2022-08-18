using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.ApiServices.Classes
{
    public class CharacterApiService : ICharacterApiService
    {
        private readonly IDatabase _database;

        public CharacterApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<CharacterApi> GetCharacterAsync(int id)
        {
            return await Task.FromResult(_database.CharacterList.SingleOrDefault(c => c.CharacterId == id));
        }

        //Get many
        public async Task<IList<CharacterApi>> GetCharactersAsync()
        {

            return await Task.FromResult(_database.CharacterList);
        }
        //create
        public async Task<CharacterApi> CreateCharacterAsync(CharacterApi characterApi)
        {
            try
            {
                _database.CharacterList.Add(characterApi);
                return await Task.FromResult(_database.CharacterList.SingleOrDefault(c => c.CharacterId == characterApi.CharacterId));
            }
            catch (Exception e)
            {
                var error = new CharacterApi { Name = e.Message };
                return error;
            }
        }

        //update
        public async Task<CharacterApi> UpdateCharacterAsync(CharacterApi characterApi)
        {
            var dbCharacter = await Task.FromResult(_database.CharacterList.SingleOrDefault(c => c.CharacterId == characterApi.CharacterId));
            if (dbCharacter == null)
            {
                return null;
            }

           
            dbCharacter.Name = characterApi.Name;
            dbCharacter.Exp = characterApi.Exp;
            dbCharacter.StatsId = characterApi.StatsId;

            return await GetCharacterAsync(characterApi.CharacterId);
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbCharacter = await Task.FromResult(_database.CharacterList.SingleOrDefault(c => c.CharacterId == id));
            if (dbCharacter != null)
            {

                if (_database.CharacterList.Remove(dbCharacter))
                {
                    return true;
                }

            }

            return false;
        }
    }
}
