using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.ApiModels;

namespace SitorApi.Services.ApiServices.Interfaces
{
    public interface IEquipmentApiService
    {
        Task<EquipmentApi> GetEquipmentAsync(int id);
        Task<IList<EquipmentApi>> GetEquipmentsAsync();
        Task<EquipmentApi> CreateEquipmentAsync(EquipmentApi equipment);
        Task<EquipmentApi> UpdateEquipmentAsync(EquipmentApi equipment);
        Task<bool> DeleteAsync(int id);
    }
}