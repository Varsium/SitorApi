using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface IPlayerService
    {
        Task<Player> GetPlayerAsync(int id);
        Task<IList<Player>> GetPlayersAsync();
        Task<Player> CreatePlayerAsync(Player player);
        Task<Player> UpdatePlayerAsync(Player player);
        Task<bool> DeleteAsync(int id);
    }
}