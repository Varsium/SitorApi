using System.ComponentModel.DataAnnotations;

namespace SitorApi.Models.DbModels
{
    public class InventoryItems
    {
        [Key]
        public int InventoryItemId { get; set; }
        public Item Item { get; set; }
    }
}
