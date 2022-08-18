using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface IStatsService
    {
        Task<Stats> GetStatsAsync(int id);
        Task<IList<Stats>> GetStatsSetAsync();
        Task<Stats> CreateStatsAsync(Stats stats);
        Task<Stats> UpdateStatsAsync(Stats stats);
        Task<bool> DeleteAsync(int id);
    }
}