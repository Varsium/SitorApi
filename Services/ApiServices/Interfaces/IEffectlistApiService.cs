using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface IEffectlistApiService
    {
        Task<EffectListApi> GetEffectListAsync(int id);
        Task<IList<EffectListApi>> GetEffectListSetAsync();
        Task<EffectListApi> CreateEffectListAsync(EffectListApi effectList);
        Task<EffectListApi> UpdateEffectListSetAsync(EffectListApi effectList);
        Task<bool> DeleteAsync(int id);
    }
}