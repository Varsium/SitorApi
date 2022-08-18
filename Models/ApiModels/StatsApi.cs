using System.ComponentModel.DataAnnotations;

namespace SitorApi.Models.ApiModels
{
    public class StatsApi
    {
        [Key]
        public int StatsId { get; set; }
        public long Lifepoints { get; set; }
        public long Attack { get; set; }
        public long Strength { get; set; }
        public long Defence { get; set; }

    }
}
