using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface ICharacterService
    {
        Task<Character> GetCharacterAsync(int id);
        Task<IList<Character>> GetCharactersAsync();
        Task<Character> CreateCharacterAsync(Character character);
        Task<Character> UpdateCharacterAsync(Character character);
        Task<bool> DeleteAsync(int id);
    }
}