using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SitorApi.Models.ApiModels
{
    public class ItemApi
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public long Cost { get; set; }
   //     public IList<EffectApi> Effects { get; set; }
    }
}
