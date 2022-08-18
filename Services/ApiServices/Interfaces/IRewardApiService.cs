using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface IRewardApiService
    {
        Task<RewardApi> GetRewardAsync(int id);
        Task<IList<RewardApi>> GeRewardsAsync();
        Task<RewardApi> CreateRewardAsync(RewardApi reward);
        Task<RewardApi> UpdateRewardAsync(RewardApi reward);
        Task<bool> DeleteAsync(int id);
    }
}