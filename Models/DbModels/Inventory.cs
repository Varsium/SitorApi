using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SitorApi.Models.DbModels
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public IList<InventoryItems> Items { get; set; }
    }
}
