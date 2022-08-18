using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface IStatsApiService
    {
        Task<StatsApi> GetStatsAsync(int id);
        Task<IList<StatsApi>> GetStatsSetAsync();
        Task<StatsApi> CreateStatsAsync(StatsApi stats);
        Task<StatsApi> UpdateStatsAsync(StatsApi stats);
        Task<bool> DeleteAsync(int id);
    }
}