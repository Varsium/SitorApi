using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitorApi.Models.ApiModels
{
    public class EquipmentApi
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public int CharacterId { get; set; }

      //  public IList<ItemApi> Items { get; set; }
    }
}
