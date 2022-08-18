using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SitorApi.Models.DbModels;

namespace SitorApi.Models.ApiModels
{
    public class EquipmentItemsApi
    {
        [Key]
        public int EquipmentItemsId { get; set; }

        public int EquipmentId { get; set; }
        public int ItemId { get; set; }
    }
}
