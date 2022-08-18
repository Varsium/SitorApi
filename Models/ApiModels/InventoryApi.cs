using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SitorApi.Models.ApiModels
{
    public class InventoryApi
    {
        [Key]
        public int InventoryId { get; set; }
        public string Name { get; set; }
      
    }
}
