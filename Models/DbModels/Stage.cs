namespace SitorApi.Models.DbModels
{
    public class Stage
    {
        public int StageId { get; set; }
        public string Name { get; set; }
        public Background Background { get; set; }
        public Character Character { get; set; }
        public Reward Reward { get; set; }
    }
}
