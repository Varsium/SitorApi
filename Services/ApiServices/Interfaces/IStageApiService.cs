using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface IStageApiService
    {
        Task<StageApi> GetStageAsync(int id);
        Task<IList<StageApi>> GetStagesAsync();
        Task<StageApi> CreateStageAsync(StageApi stage);
        Task<StageApi> UpdateStageAsync(StageApi stage);
        Task<bool> DeleteAsync(int id);
    }
}