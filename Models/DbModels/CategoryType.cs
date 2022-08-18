using System.ComponentModel.DataAnnotations;

namespace SitorApi.Models.DbModels
{
    public class CategoryType
    {
        [Key]
        public int CategoryTypeId { get; set; }

        public Type Type { get; set; }
    }
}
