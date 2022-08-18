using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface IStageService
    {
        Task<Stage> GetStageAsync(int id);
        Task<IList<Stage>> GetStagesAsync();
        Task<Stage> CreateStageAsync(Stage stage);
        Task<Stage> UpdateStageAsync(Stage stage);
        Task<bool> DeleteAsync(int id);
    }
}