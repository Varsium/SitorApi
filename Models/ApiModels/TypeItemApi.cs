using System.ComponentModel.DataAnnotations;

namespace SitorApi.Models.ApiModels
{
    public class TypeItemApi
    {
        [Key]
        public int TypeItemId { get; set; }

        public int TypeId { get; set; }
        public int ItemId { get; set; }
    }
}
