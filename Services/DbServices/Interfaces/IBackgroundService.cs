using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface IBackgroundService
    {
        Task<Background> GetBackgroundAsync(int id);
        Task<IList<Background>> GetBackgroundsAsync();
        Task<Background> CreateBackground(Background background);
        Task<Background> UpdateBackgroundAsync(Background background);
        Task<bool> DeleteAsync(int id);
    }
}