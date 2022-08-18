using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Services.ApiServices.Classes
{
    public class EquipmentApiService : IEquipmentApiService
    {
        private readonly IDatabase _database;

        public EquipmentApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
            public async Task<EquipmentApi> GetEquipmentAsync(int id)
            {
                return await Task.FromResult(_database.EquipmentList.SingleOrDefault(e => e.EquipmentId == id));

            }

            //Get many
            public async Task<IList<EquipmentApi>> GetEquipmentsAsync()
            {
                return await Task.FromResult(_database.EquipmentList);
            }

            //create
            public async Task<EquipmentApi> CreateEquipmentAsync(EquipmentApi equipment)
            {
                try
                {
                    _database.EquipmentList.Add(equipment);
                    return await GetEquipmentAsync(equipment.EquipmentId);
                }
                catch (Exception e)
                {
                    var error = new EquipmentApi { EquipmentId = e.HResult };
                    return error;
                }
            }

            //update
            public async Task<EquipmentApi> UpdateEquipmentAsync(EquipmentApi equipment)
            {
                var dbEquipment = await GetEquipmentAsync(equipment.EquipmentId);
                if (dbEquipment == null)
                {
                    return null;
                }

                dbEquipment.Name = equipment.Name;
                dbEquipment.CharacterId = equipment.CharacterId;
                return dbEquipment;
            }

            // DeleteAsync
            public async Task<bool> DeleteAsync(int id)
            {
                var dbEquipment = await GetEquipmentAsync(id);
                if (dbEquipment != null)
                {
                    if (_database.EquipmentList.Remove(dbEquipment))
                    {
                    return true;
                }
                  
                }

                return false;
            }
        }
    }

