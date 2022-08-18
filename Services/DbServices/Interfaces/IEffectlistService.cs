using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface IEffectlistService
    {
        Task<EffectList> GetEffectListAsync(int id);
        Task<IList<EffectList>> GetEffectListsAsync();
        Task<EffectList> CreateEffectAsync(EffectList effectlist);
        Task<EffectList> UpdateEffectListAsync(EffectList effectList);
        Task<bool> DeleteAsync(int id);
    }
}