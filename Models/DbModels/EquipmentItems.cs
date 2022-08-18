using System.ComponentModel.DataAnnotations;

namespace SitorApi.Models.DbModels
{
    public class EquipmentItems
    {
        [Key]
        public int EquipmentItemsId { get; set; }
        public Item Item { get; set; }
    }
}
