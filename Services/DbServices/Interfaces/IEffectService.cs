using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface IEffectService
    {
        Task<Effect> GetEffectAsync(int id);
        Task<IList<Effect>> GetEffectsAsync(int? id);
        Task<IList<Effect>> GetEffectsFilteredAsync(IList<EffectList> effectList);
        Task<Effect> CreateEffectAsync(Effect effect);
        Task<Effect> UpdateEffectAsync(Effect effect);
        Task<bool> DeleteAsync(int id);
    }
}