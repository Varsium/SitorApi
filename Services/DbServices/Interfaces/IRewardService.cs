using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface IRewardService
    {
        Task<Reward> GetRewardAsync(int id);
        Task<IList<Reward>> GeRewardsAsync();
        Task<Reward> CreateRewardAsync(Reward reward);
        Task<Reward> UpdateRewardAsync(Reward reward);
        Task<bool> DeleteAsync(int id);
    }
}