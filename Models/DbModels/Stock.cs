using System.ComponentModel.DataAnnotations;

namespace SitorApi.Models.DbModels
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        public Item Item { get; set; }
    }
}
