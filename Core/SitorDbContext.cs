using Microsoft.EntityFrameworkCore;
using SitorApi.Core.Extensions;
using SitorApi.Models.DbModels;


namespace SitorApi.Core
{
    public class SitorDbContext : DbContext
    {
        public SitorDbContext(DbContextOptions<SitorDbContext> options) : base(options)
        {
        }

        public DbSet<Background> Backgrounds { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Effect> Effects { get; set; }
        public DbSet<EffectList> EffectLists { get; set; }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentItems> EquipmentItemsSet { get; set; }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryItems> InventoryItemsSet { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Player> Players { get; set; }
       
        public DbSet<Reward> Rewards { get; set; }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Stage> Stages { get; set; }

        public DbSet<Stats> StatsSet { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<TypeItem> TypeItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.RemovePluralizingTableNameConvention();

         

        }
    }
}

