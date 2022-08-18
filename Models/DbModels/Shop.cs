using System.Collections.Generic;

namespace SitorApi.Models.DbModels
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public IList<Stock> Stock { get; set; }
    }
}
