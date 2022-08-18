namespace SitorApi.Models.DbModels
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Character Character { get; set; }
        public long Coins { get; set; }
        public Inventory Inventory { get; set; }
        public int statusPointsLeft { get; set; }
        public int statusPointsAttack { get; set; }
        public int statusPointsDefence { get; set; }
        public int statusPointsStrength { get; set; }
        public int statusPointsHitpoints { get; set; }
    }
}
