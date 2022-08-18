using System.ComponentModel.DataAnnotations;

namespace SitorApi.Models.DbModels
{
    public class TypeItem
    {
        [Key]
        public int TypeItemId { get; set; }
        public Item Item { get; set; }
    }
}
