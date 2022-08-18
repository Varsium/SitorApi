using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Models.ApiModels
{
    public class InventoryItemsApi
    {
        [Key]
        public int InventoryItemId { get; set; }

        public int InventoryId { get; set; }
        public int ItemId { get; set; }
    }
}
