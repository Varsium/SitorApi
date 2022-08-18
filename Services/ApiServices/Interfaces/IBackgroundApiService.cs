using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface IBackgroundApiService
    {
        Task<BackgroundApi> GetBackgroundAsync(int id);
        Task<IList<BackgroundApi>> GetBackgroundsAsync();
        Task<BackgroundApi> CreateBackground(BackgroundApi backgroundApi);
        Task<BackgroundApi> UpdateBackgroundAsync(BackgroundApi BackgroundApi);
        Task<bool> DeleteAsync(int id);
    }
}