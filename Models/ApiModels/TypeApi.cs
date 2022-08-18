using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SitorApi.Models.ApiModels
{
    public class TypeApi
    {
        [Key]
        public int TypeId { get; set; }

        public int CategoryId { get; set; }
        public string type { get; set; }
     //   public IList<ItemApi> Items { get; set; }
    }
}
