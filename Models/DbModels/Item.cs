using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SitorApi.Models.DbModels
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int? Image { get; set; }
        public long Cost { get; set; }
        public IList<EffectList> Effects { get; set; }
    }
}
