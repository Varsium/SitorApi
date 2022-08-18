using System.ComponentModel.DataAnnotations;
using SitorApi.Models.DbModels;

namespace SitorApi.Models.ApiModels
{
    public class CharacterApi
    {
        [Key]
        public int CharacterId { get; set; }
        public string Name { get; set; }
      
        public long Exp { get; set; }
        public bool IsHero { get; set; }
        public string Image { get; set; }
        public int StatsId { get; set; }
        public int EquipmentId { get; set; }

    }
}
