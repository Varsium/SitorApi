namespace SitorApi.Models.DbModels
{
    public class Reward
    {
        public int RewardId { get; set; }
        public Item Item { get; set; }
        public long Exp { get; set; }
        public long Coins { get; set; }
    }
}
