using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface IEffectApiService
    {
        Task<EffectApi> GetEffectAsync(int id);
        Task<IList<EffectApi>> GetEffectsAsync();
        Task<IList<EffectApi>> GetEffectsFilteredAsync(IList<EffectListApi> effectList);
        Task<EffectApi> CreateEffectAsync(EffectApi effect);
        Task<EffectApi> UpdateEffectAsync(EffectApi effect);
        Task<bool> DeleteAsync(int id);
    }
}