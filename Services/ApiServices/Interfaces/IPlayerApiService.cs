using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface IPlayerApiService
    {
        Task<PlayerApi> GetPlayerAsync(int id);
        Task<IList<PlayerApi>> GePlayersAsync();
        Task<PlayerApi> CreatePlayerAsync(PlayerApi player);
        Task<PlayerApi> UpdatePlayerAsync(PlayerApi player);
        Task<bool> DeleteAsync(int id);
    }
}