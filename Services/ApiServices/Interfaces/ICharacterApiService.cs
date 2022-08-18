using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface ICharacterApiService
    {
        Task<CharacterApi> GetCharacterAsync(int id);
        Task<IList<CharacterApi>> GetCharactersAsync();
        Task<CharacterApi> CreateCharacterAsync(CharacterApi characterApi);
        Task<CharacterApi> UpdateCharacterAsync(CharacterApi characterApi);
        Task<bool> DeleteAsync(int id);
    }
}