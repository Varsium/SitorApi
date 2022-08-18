using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class CharacterService : ICharacterService
    {
        private readonly SitorDbContext _context;

        public CharacterService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<Character> GetCharacterAsync(int id)
        {
            return await _context.Characters
                .Include(c => c.Stats)
                .Include(c => c.Equipment)
                .ThenInclude(e => e.EquipmentItems)
                .ThenInclude(e => e.Item)
                .SingleOrDefaultAsync(c => c.CharacterId == id);
        }

        //Get many
        public async Task<IList<Character>> GetCharactersAsync()
        {

            var query = await _context.Characters
                .Include(c => c.Stats)
                .Include(c => c.Equipment)
                .ThenInclude(e => e.EquipmentItems)
               .ThenInclude(e => e.Item)
                .ToListAsync();
            return query;
        }
        //create
        public async Task<Character> CreateCharacterAsync(Character character)
        {
            try
            {
                _context.Characters.Add(character);
                await _context.SaveChangesAsync();
                return await GetCharacterAsync(character.CharacterId);
            }
            catch (Exception e)
            {
                var error = new Character { Name = e.Message };
                return error;
            }
        }

        //update
        public async Task<Character> UpdateCharacterAsync(Character character)
        {
            var dbCharacter = await _context.Characters.SingleOrDefaultAsync(c => c.CharacterId == character.CharacterId);
            if (dbCharacter == null)
            {
                return null;
            }

            dbCharacter.Equipment = character.Equipment;
            dbCharacter.Name = character.Name;
            dbCharacter.Level = character.Level;
            dbCharacter.Exp = character.Exp;
            dbCharacter.Stats = character.Stats;
            await _context.SaveChangesAsync();
            return await GetCharacterAsync(character.CharacterId);
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbCharacter = await _context.Characters.SingleOrDefaultAsync(c => c.CharacterId == id);
            if (dbCharacter != null)
            {

                _context.Characters.Attach(dbCharacter);
                _context.Characters.Remove(dbCharacter);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
