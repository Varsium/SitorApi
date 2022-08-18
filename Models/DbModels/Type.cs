using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SitorApi.Models.DbModels
{
    public class Type
    {
        [Key]
        public int TypeId { get; set; }
        public string type { get; set; }
        public IList<TypeItem> Items { get; set; }
    }
}
