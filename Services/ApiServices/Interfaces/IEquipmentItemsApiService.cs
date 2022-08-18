using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface IEquipmentItemsApiService
    {
        Task<EquipmentItemsApi> GetEquipmentItemsAsync(int id);
        Task<IList<EquipmentItemsApi>> GetEquipmentItemssAsync();
        Task<EquipmentItemsApi> CreateEquipmentItemsAsync(EquipmentItemsApi equipment);
        Task<EquipmentItemsApi> UpdateEquipmentItemsAsync(EquipmentItemsApi equipment);
        Task<bool> DeleteAsync(int id);
    }
}