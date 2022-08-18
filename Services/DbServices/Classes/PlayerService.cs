using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SitorApi.Core;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Services.DbServices.Classes
{
    public class PlayerService : IPlayerService
    {
        private readonly SitorDbContext _context;

        public PlayerService(SitorDbContext context)
        {
            _context = context;
        }

        //Get one 
        public async Task<Player> GetPlayerAsync(int id)
        {
            return await _context.Players
                    .Include(p => p.Inventory)
                    .ThenInclude(i => i.Items)
                    .ThenInclude(i => i.Item)
                    .Include(p => p.Character)
                    .ThenInclude(c => c.Equipment)
                    .ThenInclude(e => e.EquipmentItems)
                    .ThenInclude(e => e.Item)
                    .Include(p => p.Character.Stats)
                .SingleOrDefaultAsync(p => p.PlayerId == id);
        }

        //Get many
        public async Task<IList<Player>> GetPlayersAsync()
        {
            return await _context.Players
                .Include(p => p.Inventory)
                .ThenInclude(i => i.Items)
                .ThenInclude(i => i.Item)
                .Include(p => p.Character)
                .ThenInclude(c => c.Equipment)
               .ThenInclude(e => e.EquipmentItems)
                .ThenInclude(e => e.Item)
                .Include(p => p.Character.Stats)
                .ToListAsync();
        }
        //create
        public async Task<Player> CreatePlayerAsync(Player player)
        {
            try
            {
                _context.Players.Add(player);
                await _context.SaveChangesAsync();
                return await GetPlayerAsync(player.PlayerId);
            }
            catch (Exception e)
            {
                var error = new Player
                {
                    Name = e.Message
                };
                return error;
            }
        }

        //update
        public async Task<Player> UpdatePlayerAsync(Player player)
        {
            var dbPlayer = await GetPlayerAsync(player.PlayerId);
            if (dbPlayer == null)
            {
                return null;
            }

            dbPlayer.Name = player.Name;
            dbPlayer.Password = player.Password;
            dbPlayer.Character = player.Character;
            dbPlayer.Coins = player.Coins;
            dbPlayer.Inventory = player.Inventory;
            await _context.SaveChangesAsync();
            return dbPlayer;
        }

        // DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var dbPlayer =await GetPlayerAsync(id);
            if (dbPlayer != null)
            {


                _context.Players.Attach(dbPlayer);
                _context.Players.Remove(dbPlayer);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
