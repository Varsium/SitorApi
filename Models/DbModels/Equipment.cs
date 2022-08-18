using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SitorApi.Models.DbModels
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }
        public string Name { get; set; }
       public int CharacterId { get; set; }

        public IList<EquipmentItems> EquipmentItems { get; set; }
    }
}
