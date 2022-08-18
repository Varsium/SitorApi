using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SitorApi.Core.Database;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Services.ApiServices.Classes
{
    public class PlayerApiService : IPlayerApiService
    {
        private readonly IDatabase _database;

        public PlayerApiService(IDatabase database)
        {
            _database = database;
        }

        //Get one 
        public async Task<PlayerApi> GetPlayerAsync(int id)
        {
            return await Task.FromResult(_database.PlayerList.SingleOrDefault(r => r.PlayerId == id));
        }

        //Get many
        public async Task<IList<PlayerApi>> GePlayersAsync()
        {
            return await Task.FromResult(_database.PlayerList);
        }
        //create
        public async Task<PlayerApi> CreatePlayerAsync(PlayerApi player)
        {
            try
            {
                _database.PlayerList.Add(player);
                return await GetPlayerAsync(player.PlayerId);
            }
            catch (Exception e)
            {
                var error = new PlayerApi
                {
                    Coins = e.HResult
                };
                return error;
            }
        }

        //update
        public async Task<PlayerApi> UpdatePlayerAsync(PlayerApi player)
        {
            var dbPlayer = await GetPlayerAsync(player.PlayerId);
            if (dbPlayer == null)
            {
                return null;
            }

            dbPlayer.Exp = player.Exp;
            dbPlayer.Name = player.Name;
            dbPlayer.InventoryId = player.InventoryId;
            dbPlayer.Password = player.Password;
            dbPlayer.StatusPointsAttack = player.StatusPointsAttack;
            dbPlayer.StatusPointsDefence = player.StatusPointsDefence;
            dbPlayer.StatusPointsHitpoints = player.StatusPointsHitpoints;
            dbPlayer.StatusPointsLeft = player.StatusPointsLeft;
            dbPlayer.StatusPointsStrength = player.StatusPointsStrength;
            dbPlayer.Coins = player.Coins;
            dbPlayer.CharacterId = player.CharacterId;
            return dbPlayer;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbPlayer = await GetPlayerAsync(id);
            if (dbPlayer != null)
            {
                if (_database.PlayerList.Remove(dbPlayer))
                {
                    return true;
                }

            }

            return false;
        }
    }
}