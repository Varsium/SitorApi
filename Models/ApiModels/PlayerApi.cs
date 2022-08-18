using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitorApi.Models.ApiModels
{
    public class PlayerApi
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int CharacterId { get; set; }
        public long Coins { get; set; }
        public int InventoryId { get; set; }
        public int StatusPointsLeft { get; set; }
        public int StatusPointsAttack { get; set; }
        public int StatusPointsDefence { get; set; }
        public int StatusPointsStrength { get; set; }
        public int StatusPointsHitpoints { get; set; }
        public long Exp { get; set; }
    }
}
