using System.Collections.Generic;

namespace SitorApi.Models.DbModels
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public IList<CategoryType> Types { get; set; }
    }
}
