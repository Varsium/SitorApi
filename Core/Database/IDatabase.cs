using System.Collections.Generic;
using SitorApi.Models.ApiModels;

namespace SitorApi.Core.Database
{
    public interface IDatabase
    {
        IList<BackgroundApi> BackgroundList { get; set; }
        IList<PlayerApi> PlayerList { get; set; }
        IList<CategoryApi> CategoryList { get; set; }
        IList<CategoryTypeApi> CategoryTypeList { get; set; }
        IList<CharacterApi> CharacterList { get; set; }
        IList<EffectApi> EffectList { get; set; }
        IList<EffectListApi> EffectListSet { get; set; }
        IList<EquipmentApi> EquipmentList { get; set; }
        IList<EquipmentItemsApi> EquipmentItemsList { get; set; }
        IList<ItemApi> ItemList { get; set; }
        IList<InventoryApi> InventoryList { get; set; }
        IList<InventoryItemsApi> InventoryItemsList { get; set; }
        IList<RewardApi> RewardList { get; set; }
        IList<ShopApi> ShopList { get; set; }
        IList<StockApi> StockList { get; set; }
        IList<StageApi> StageList { get; set; }
        IList<StatsApi> StatsList { get; set; }
        IList<TypeApi> TypeList { get; set; }
        IList<TypeItemApi> TypeItemList { get; set; }

        void Initialize();
    }
}