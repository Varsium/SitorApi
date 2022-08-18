using System.ComponentModel.DataAnnotations;

namespace SitorApi.Models.DbModels
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public long Exp { get; set; }
        public bool IsHero { get; set; }
        public int? Image { get; set; }
        public Stats Stats { get; set; }
        public Equipment Equipment { get; set; }

    }
}
