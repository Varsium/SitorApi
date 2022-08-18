using System.Collections.Generic;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Services.DbServices.Interfaces
{
    public interface IEquipmentService
    {
        Task<Equipment> GetEquipmentAsync(int id);
        Task<IList<Equipment>> GetEquipmentsAsync();
        Task<Equipment> CreateEquipmentAsync(Equipment Equipment);
        Task<Equipment> UpdateEquipmentAsync(Equipment Equipment);
        Task<bool> DeleteAsync(int id);
    }
}