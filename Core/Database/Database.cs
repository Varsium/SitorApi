using System.Collections.Generic;
using SitorApi.Models.ApiModels;

namespace SitorApi.Core.Database
{
    public class Database : IDatabase
    {
        public Database()
        {
            BackgroundList = new List<BackgroundApi>();
            CategoryList = new List<CategoryApi>();
            CategoryTypeList = new List<CategoryTypeApi>();
            CharacterList = new List<CharacterApi>();
            EffectList = new List<EffectApi>();
            ItemList = new List<ItemApi>();
            RewardList = new List<RewardApi>();
            ShopList = new List<ShopApi>();
            StageList = new List<StageApi>();
            StatsList = new List<StatsApi>();
            TypeList = new List<TypeApi>();
            EquipmentList = new List<EquipmentApi>();
            EquipmentItemsList = new List<EquipmentItemsApi>();
            CategoryTypeList = new List<CategoryTypeApi>();
            EffectListSet = new List<EffectListApi>();
            InventoryList = new List<InventoryApi>();
            InventoryItemsList = new List<InventoryItemsApi>();
            StockList = new List<StockApi>();
            TypeItemList = new List<TypeItemApi>();
            PlayerList = new List<PlayerApi>();
        }

        public IList<BackgroundApi> BackgroundList { get; set; }
        public IList<PlayerApi> PlayerList { get; set; }
        public IList<CategoryApi> CategoryList { get; set; }
        public IList<CategoryTypeApi> CategoryTypeList { get; set; }
        public IList<CharacterApi> CharacterList { get; set; }
        public IList<EffectApi> EffectList { get; set; }
        public IList<EffectListApi> EffectListSet { get; set; }
        public IList<EquipmentApi> EquipmentList { get; set; }
        public IList<EquipmentItemsApi> EquipmentItemsList { get; set; }
        public IList<ItemApi> ItemList { get; set; }
        public IList<InventoryApi> InventoryList { get; set; }
        public IList<InventoryItemsApi> InventoryItemsList { get; set; }
        public IList<RewardApi> RewardList { get; set; }
        public IList<ShopApi> ShopList { get; set; }
        public IList<StockApi> StockList { get; set; }
        public IList<StageApi> StageList { get; set; }
        public IList<StatsApi> StatsList { get; set; }
        public IList<TypeApi> TypeList { get; set; }
        public IList<TypeItemApi> TypeItemList { get; set; }


        public void Initialize()
        {
            const string strength = "Strength";
            const string attack = "Attack";
            const string defence = "Defence";
            const string hitpoints = "Hitpoints";
            BackgroundList = new List<BackgroundApi>
            {

                new BackgroundApi
                {
                    BackgroundId = 1,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/hrStage1.jpg",
                    Name = "Stage 1"
                },
                new BackgroundApi
                {
                    BackgroundId = 2,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/hrStage2.jpg",
                    Name = "Stage 2"
                },
                new BackgroundApi
                {
                    BackgroundId = 3,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/hrStage3.jpg",
                    Name = "Stage 3"
                },
                new BackgroundApi
                {
                    BackgroundId = 4,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/hrStage4.jpg",
                    Name = "Stage 4"
                },
                new BackgroundApi
                {
                    BackgroundId = 5,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/hrStage5.png",
                    Name = "Stage 5"
                },
                new BackgroundApi
                {
                    BackgroundId = 6,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/hrStage6.jpg",
                    Name = "Stage 6"
                },
                new BackgroundApi
                {
                    BackgroundId = 7,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/hrStage7.png",
                    Name = "Stage 7"
                },
                new BackgroundApi
                {
                    BackgroundId = 8,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/hrStage8.png",
                    Name = "Stage 8"
                },
                new BackgroundApi
                {
                    BackgroundId = 9,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/hrStage9.png",
                    Name = "Stage 9"
                },
                new BackgroundApi
                {
                    BackgroundId = 10,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/hrStage10.png",
                    Name = "Stage 10"
                },
                new BackgroundApi
                {
                    BackgroundId = 11,
                    Image = "https://www.dropbox.com/s/pdbaa95b8qm9rm3/Livestage1.gif?dl=0&raw=1",
                    Name = "LiveStage 1"
                },


            };
            EffectList = new List<EffectApi>
            {
                new EffectApi
                {
                    Attribute = attack,
                    EffectId = 1,
                    Value = 12
                },

                new EffectApi
                {
                    Attribute = hitpoints,
                    EffectId = 2,
                    Value = 12
                },
                new EffectApi
                {
                    Attribute = attack,
                    EffectId = 3,
                    Value = 12
                },
                new EffectApi
                {
                    Attribute = defence,
                    EffectId = 4,
                    Value = 1
                },
                //legs 
                new EffectApi
                {
                    Attribute = strength,
                    EffectId = 5,
                    Value = 5
                },
                new EffectApi
                {
                    Attribute = defence,
                    EffectId = 6,
                    Value = 8
                },
                new EffectApi
                {
                    Attribute = strength,
                    EffectId = 7,
                    Value = 20
                },
                new EffectApi
                {
                    Attribute = hitpoints,
                    EffectId = 8,
                    Value = 20
                },
                new EffectApi
                {
                    Attribute = defence,
                    EffectId = 9,
                    Value = 20
                },
                new EffectApi
                {
                    Attribute = attack,
                    EffectId = 10,
                    Value = 25
                },

                new EffectApi
                {
                    Attribute = hitpoints,
                    EffectId = 11,
                    Value = 37
                },
                new EffectApi
                {
                    Attribute = defence,
                    EffectId = 12,
                    Value = 40
                },
                new EffectApi
                {
                    Attribute = strength,
                    EffectId = 13,
                    Value = 100
                },
                new EffectApi
                {
                    Attribute = hitpoints,
                    EffectId = 14,
                    Value = 100
                },
                new EffectApi
                {
                    Attribute = attack,
                    EffectId = 15,
                    Value = 100
                },
                new EffectApi
                {
                    Attribute = defence,
                    EffectId = 16,
                    Value = 100
                },

                //boots
                new EffectApi
                {
                    Attribute = hitpoints,
                    EffectId = 17,
                    Value = 20
                },
                new EffectApi
                {
                    Attribute = hitpoints,
                    EffectId = 18,
                    Value = 20
                },

            };
            //Urls implementen voor images
            //nog consumables
            ItemList = new List<ItemApi>
            {
                new ItemApi
                {
                    Cost = 200,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/sword1.png",
                    ItemId = 1,
                    Name = "Dagger of the Darklord"
                },
                new ItemApi
                {
                    Cost = 500,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/helmet1.png",
                    ItemId = 2,
                    Name = "helmet of the Darklord"

                },
                new ItemApi
                {
                    Cost = 400,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/chainbody1.png",
                    ItemId = 3,
                    Name = "Platebody of the Darklord"
                },
                new ItemApi
                {
                    Cost = 500,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/legs1.png",
                    ItemId = 4,
                    Name = "Legs of the Darklord"

                },
                new ItemApi
                {
                    Cost = 600,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/2h1.png",
                    ItemId = 5,
                    Name = "2h of the Darklord"
                },
                new ItemApi
                {
                    Cost = 300,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/shield1.png",
                    ItemId = 6,
                    Name = "Shield of the Darklord"

                },
                new ItemApi
                {
                    Cost = 500,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/sword2.png",
                    ItemId = 7,
                    Name = "Sword of Rahzull"
                },
                new ItemApi
                {
                    Cost = 700,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/helmet2.png",
                    ItemId = 8,
                    Name = "Gladiator helmet of Rahzull"

                },
                new ItemApi
                {
                    Cost = 1000,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/chainbody2.png",
                    ItemId = 9,
                    Name = "Platebody of Rahzull"
                },
                new ItemApi
                {
                    Cost = 800,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/legs2.png",
                    ItemId = 10,
                    Name = "Platelegs of Rahzull"

                },
                new ItemApi
                {
                    Cost = 750,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/2h2.png",
                    ItemId = 11,
                    Name = "2h of rahzull"
                },
                new ItemApi
                {
                    Cost = 650,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/shield2.png",
                    ItemId = 12,
                    Name = "Shield of Rahzull"

                },

                new ItemApi
            {
                Cost = 2000,
                Image = "https://sitorphotos.blob.core.windows.net/photossitor/sword3.png",
                ItemId = 13,
                Name = "Longsword of Death"
            },
            new ItemApi
            {
                Cost = 2200,
                Image = "https://sitorphotos.blob.core.windows.net/photossitor/helmet3.png",
                ItemId = 14,
                Name = "Slayer helmet of Death"

            },
            new ItemApi
            {
                Cost = 2800,
                Image = "https://sitorphotos.blob.core.windows.net/photossitor/chainbody3.png",
                ItemId = 15,
                Name = "Cursed Platebody of Death"
            },
            new ItemApi
            {
                Cost = 2400,
                Image = "https://sitorphotos.blob.core.windows.net/photossitor/legs3.png",
                ItemId = 16,
                Name = "Cursed Platelegs of Death"

            },
            new ItemApi
            {
                Cost = 2800,
                Image = "https://sitorphotos.blob.core.windows.net/photossitor/2h3.png",
                ItemId = 17,
                Name = "Godsword of Death"
            },
            new ItemApi
            {
                Cost = 2100,
                Image = "https://sitorphotos.blob.core.windows.net/photossitor/shield3.png",
                ItemId = 18,
                Name = "Devour shield of Death"

            },
            new ItemApi
            {
                Cost = 2100,
                Image = "https://sitorphotos.blob.core.windows.net/photossitor/boots3.png",
                ItemId = 19,
                Name = "Boots of Death"

            },
            new ItemApi
            {
                Cost = 700,
                Image = "https://sitorphotos.blob.core.windows.net/photossitor/boots2.png",
                ItemId = 20,
                Name = "Boots of Rahzull"

            },
            new ItemApi
            {
                Cost = 350,
                Image = "https://sitorphotos.blob.core.windows.net/photossitor/boots1.png",
                ItemId = 21,
                Name = "Boots of the Darklord"

            },
        };
            TypeList = new List<TypeApi>
            {
                new TypeApi
                {
                    type = "Weapon",
                    TypeId = 1
                },

                new TypeApi
                {
                type = "2H weapon",
                TypeId = 2
            },

                new TypeApi
                {
                    type = "Helmet",
                    TypeId = 3
                },

                new TypeApi
                {
                    type = "Body",
                    TypeId = 4
                },

                new TypeApi
                {
                    type = "Legs",
                    TypeId = 5
                },

                new TypeApi
                {
                    type = "Shield",
                    TypeId = 6
                },

                new TypeApi
                {
                    type = "Boots",
                    TypeId = 7
                },
            };
            CategoryList = new List<CategoryApi>
            {
                new CategoryApi
                {
                    CategoryId = 1,
                    Name = "Equipment"
                },
                new CategoryApi
                {
                    CategoryId = 2,
                    Name = "Consumables"
                }
            };
            //Nog consumables

            CategoryTypeList = new List<CategoryTypeApi>
            {
                new CategoryTypeApi
                {
                    CategoryTypeId = 1,
                    CategoryId = 1,
                    TypeId = 1
                },
                new CategoryTypeApi
                {
                    CategoryTypeId = 2,
                    CategoryId = 1,
                    TypeId = 2
                },
                new CategoryTypeApi
                {
                    CategoryTypeId = 3,
                    CategoryId = 1,
                    TypeId = 3
                },
                new CategoryTypeApi
                {
                    CategoryTypeId = 4,
                    CategoryId = 1,
                    TypeId = 4
                },
                new CategoryTypeApi
                {
                    CategoryTypeId = 5,
                    CategoryId = 1,
                    TypeId = 5
                },
                new CategoryTypeApi
                {
                    CategoryTypeId = 6,
                    CategoryId = 1,
                    TypeId = 6
                },
                new CategoryTypeApi
                {
                    CategoryTypeId = 7,
                    CategoryId = 1,
                    TypeId = 7
                }
            };
            CharacterList = new List<CharacterApi>
            {
                new CharacterApi
                {
                    CharacterId = 1,
                    EquipmentId = 1,
                    Exp = 500,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/angelcharacter.png",
                    IsHero = false,
                    Name = "Angel of Nepal",
                    StatsId = 1
                },
                new CharacterApi
                {
                CharacterId = 2,
                EquipmentId = 2,
                Exp = 1000,
                Image = "https://sitorphotos.blob.core.windows.net/photossitor/izcharacter.png",
                IsHero = false,
                Name = "Crafter Iz",
                StatsId = 2
            },
                new CharacterApi
                {
                    CharacterId = 3,
                    EquipmentId = 3,
                    Exp = 3000,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/kanadeharacter.png",
                    IsHero = false,
                    Name = "Skilled Kanade",
                    StatsId = 3
                },
                new CharacterApi
                {
                    CharacterId = 4,
                    EquipmentId = 4,
                    Exp = 5000,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/katsumicharacter.png",
                    IsHero = false,
                    Name = "Fortress warrior Katsumi",
                    StatsId = 4
                },
                new CharacterApi
                {
                    CharacterId = 5,
                    EquipmentId = 5,
                    Exp = 7000,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/kuromucharacter.png",
                    IsHero = false,
                    Name = "Great shielder Kuromu",
                    StatsId = 5
                },
                new CharacterApi
                {
                    CharacterId = 6,
                    EquipmentId = 6,
                    Exp = 12000,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/maycharacter.png",
                    IsHero = false,
                    Name = " May of the one hit twins ",
                    StatsId = 6
                },
                new CharacterApi
                {
                    CharacterId = 7,
                    EquipmentId = 7,
                    Exp = 18000,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/yuicharacter.png",
                    IsHero = false,
                    Name = " Yui of the one hit twins ",
                    StatsId = 7
                },
                new CharacterApi
                {
                    CharacterId = 8,
                    EquipmentId = 8,
                    Exp = 18000,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/maplecharacter.png",
                    IsHero = false,
                    Name = "High defending Maple ",
                    StatsId = 8
                },
                new CharacterApi
                {
                    CharacterId = 9,
                    EquipmentId = 9,
                    Exp = 21000,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/albedocharacter.jpg",
                    IsHero = false,
                    Name = "Albedo the demon servant",
                    StatsId = 9
                },
                new CharacterApi
                {
                    CharacterId = 10,
                    EquipmentId = 10,
                    Exp = 50000,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/finalbosscharacter.jpg",
                    IsHero = false,
                    Name = "The demon king",
                    StatsId = 10
                },

                new CharacterApi
                {
                    CharacterId = 11,
                    EquipmentId = 11,
                    Exp = 0,
                    Image = "https://sitorphotos.blob.core.windows.net/photossitor/playercharacter.jpg",
                    IsHero = true,
                    Name = "Player",
                    StatsId = 11
                },
            };
            EffectListSet = new List<EffectListApi>
            {
                //Linked 1st rate items with effects)
                new EffectListApi
                {
                    EffectListId = 1,
                    ItemId = 1,
                    EffectId = 1
                },
                new EffectListApi
                {
                    EffectListId = 2,
                    ItemId = 1,
                    EffectId = 5
                },
                new EffectListApi
                {
                    EffectListId = 3,
                    ItemId = 2,
                    EffectId = 4
                },
                new EffectListApi
                {
                    EffectListId = 4,
                    ItemId = 2,
                    EffectId = 5
                },
                new EffectListApi
                {
                    EffectListId = 5,
                    ItemId = 3,
                    EffectId = 2
                },
                new EffectListApi
                {
                    EffectListId = 6,
                    ItemId = 3,
                    EffectId = 6
                },
                new EffectListApi
                {
                    EffectListId = 7,
                    ItemId = 4,
                    EffectId = 8
                },
                new EffectListApi
                {
                    EffectListId = 8,
                    ItemId = 4,
                    EffectId = 5
                },
                new EffectListApi
                {
                    EffectListId = 9,
                    ItemId = 5,
                    EffectId = 10
                },
                new EffectListApi
                {
                    EffectListId = 10,
                    ItemId = 5,
                    EffectId = 13
                },
                new EffectListApi
                {
                    EffectListId = 11,
                    ItemId = 6,
                    EffectId = 9
                },
                new EffectListApi
                {
                    EffectListId = 12,
                    ItemId = 6,
                    EffectId = 8
                },
                //Linked higher ranked items with effects)

                 new EffectListApi
                {
                    EffectListId = 13,
                    ItemId = 7,
                    EffectId = 7
                },
                new EffectListApi
                {
                    EffectListId = 14,
                    ItemId = 7,
                    EffectId = 10
                },
                new EffectListApi
                {
                    EffectListId = 15,
                    ItemId = 8,
                    EffectId = 8
                },
                new EffectListApi
                {
                    EffectListId = 16,
                    ItemId = 8,
                    EffectId = 9
                },
                new EffectListApi
                {
                    EffectListId = 17,
                    ItemId = 8,
                    EffectId = 7
                },
                new EffectListApi
                {
                    EffectListId = 18,
                    ItemId = 9,
                    EffectId = 8
                },
                new EffectListApi
                {
                    EffectListId = 19,
                    ItemId = 9,
                    EffectId = 12
                },
                new EffectListApi
                {
                    EffectListId = 20,
                    ItemId = 9,
                    EffectId = 13
                },
                new EffectListApi
                {
                    EffectListId = 21,
                    ItemId = 10,
                    EffectId = 11
                },
                new EffectListApi
                {
                    EffectListId = 22,
                    ItemId = 10,
                    EffectId = 12
                },
                new EffectListApi
                {
                    EffectListId = 23,
                    ItemId = 10,
                    EffectId = 7
                },
                new EffectListApi
                {
                    EffectListId = 24,
                    ItemId = 11,
                    EffectId = 15
                },
                new EffectListApi
                {
                    EffectListId = 25,
                    ItemId = 11,
                    EffectId = 18
                },
                new EffectListApi
                {
                    EffectListId = 26,
                    ItemId = 12,
                    EffectId = 16
                },
                new EffectListApi
                {
                    EffectListId = 27,
                    ItemId = 12,
                    EffectId = 14
                },
                new EffectListApi
                {
                    EffectListId = 28,
                    ItemId = 13,
                    EffectId = 19
                },
                new EffectListApi
                {
                    EffectListId = 29,
                    ItemId = 13,
                    EffectId = 20
                },
                new EffectListApi
                {
                    EffectListId = 30,
                    ItemId = 13,
                    EffectId = 12
                },
                new EffectListApi
                {
                    EffectListId = 31,
                    ItemId = 13,
                    EffectId = 11
                },
                new EffectListApi
                {
                    EffectListId = 32,
                    ItemId = 14,
                    EffectId = 10
                },
                new EffectListApi
                {
                    EffectListId = 33,
                    ItemId = 14,
                    EffectId = 20
                },
                new EffectListApi
                {
                    EffectListId = 34,
                    ItemId = 14,
                    EffectId = 24
                },
                new EffectListApi
                {
                    EffectListId = 35,
                    ItemId = 14,
                    EffectId = 21
                },
                new EffectListApi
                {
                    EffectListId = 36,
                    ItemId = 15,
                    EffectId = 25
                },
                new EffectListApi
                {
                    EffectListId = 37,
                    ItemId = 15,
                    EffectId = 26
                },
                new EffectListApi
                {
                    EffectListId = 38,
                    ItemId = 15,
                    EffectId = 27
                },
                new EffectListApi
                {
                    EffectListId = 39,
                    ItemId = 15,
                    EffectId = 28
                },
                new EffectListApi
                {
                    EffectListId = 43,
                    ItemId = 16,
                    EffectId = 31
                },
                new EffectListApi
                {
                    EffectListId = 44,
                    ItemId = 16,
                    EffectId = 32
                },
                new EffectListApi
                {
                    EffectListId = 45,
                    ItemId = 16,
                    EffectId = 33
                },
                new EffectListApi
                {
                    EffectListId = 46,
                    ItemId = 16,
                    EffectId = 34
                },
                new EffectListApi
                {
                    EffectListId = 39,
                    ItemId = 15,
                    EffectId = 28
                },
                new EffectListApi
                {
                    EffectListId = 40,
                    ItemId = 17,
                    EffectId = 29
                },
                new EffectListApi
                {
                    EffectListId = 41,
                    ItemId = 17,
                    EffectId = 30
                },
                new EffectListApi
                {
                    EffectListId = 42,
                    ItemId = 18,
                    EffectId = 35
                },
                new EffectListApi
                {
                    EffectListId = 43,
                    ItemId = 18,
                    EffectId = 36
                },
                new EffectListApi
                {
                    EffectListId = 44,
                    ItemId = 21,
                    EffectId = 17
                },
                new EffectListApi
                {
                    EffectListId = 45,
                    ItemId = 21,
                    EffectId = 4
                },
                new EffectListApi
                {
                    EffectListId = 46,
                    ItemId = 20,
                    EffectId = 14
                },
                new EffectListApi
                {
                    EffectListId = 47,
                    ItemId = 20,
                    EffectId = 12
                },
                new EffectListApi
                {
                    EffectListId = 48,
                    ItemId = 19,
                    EffectId = 28
                },
                new EffectListApi
                {
                    EffectListId = 49,
                    ItemId = 19,
                    EffectId = 24
                },
            };
            EquipmentList = new List<EquipmentApi>
            {
                new EquipmentApi
                {
                    EquipmentId = 1,CharacterId = 1,
                Name    = "Equipment"
                },
                new EquipmentApi
                {
                    EquipmentId = 2,CharacterId = 2,
                Name    = "Equipment"
                },
                new EquipmentApi
                {
                    EquipmentId = 2,CharacterId = 2,
                  Name  = "Equipment"
                },
                new EquipmentApi
                {
                    EquipmentId = 3,CharacterId = 3,
                Name = "Equipment"
                },
                new EquipmentApi
                {
                    EquipmentId = 4,CharacterId = 4,
                 Name   = "Equipment"
                },
                new EquipmentApi
                {
                    EquipmentId = 5,CharacterId = 5,
                   Name = "Equipment"
                },
                new EquipmentApi
                {
                    EquipmentId = 6,CharacterId = 6,
                    Name    = "Equipment"
                },
                new EquipmentApi
                {
                    EquipmentId =7,CharacterId = 7,
                    Name    = "Equipment"
                },
                new EquipmentApi
                {
                    EquipmentId = 8,CharacterId = 8,
                    Name  = "Equipment"
                },
                new EquipmentApi
                {
                    EquipmentId = 9,CharacterId = 9,
                    Name = "Equipment"
                },
                new EquipmentApi
                {
                    EquipmentId = 10,CharacterId = 10,
                    Name   = "Equipment"
                },
                new EquipmentApi
                {
                    EquipmentId = 11,CharacterId = 11,
                    Name = "Equipment"
                },

            };
            EquipmentItemsList = new List<EquipmentItemsApi>
            {
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 1,
                    EquipmentId = 1,
                    ItemId = 21
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 2,
                    EquipmentId = 2,
                    ItemId = 21
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 3,
                    EquipmentId = 2,
                    ItemId = 1
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 4,
                    EquipmentId = 2,
                    ItemId = 2
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 5,
                    EquipmentId = 3,
                    ItemId = 21
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 6,
                    EquipmentId = 3,
                    ItemId = 1
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 7,
                    EquipmentId = 3,
                    ItemId = 2
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 8,
                    EquipmentId = 3,
                    ItemId = 3
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 9,
                    EquipmentId = 3,
                    ItemId = 4
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 10,
                    EquipmentId = 3,
                    ItemId = 6
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 11,
                    EquipmentId = 4,
                    ItemId = 8
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 12,
                    EquipmentId = 4,
                    ItemId = 9
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 13,
                    EquipmentId = 5,
                    ItemId = 8
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 14,
                    EquipmentId = 5,
                    ItemId = 9
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 15,
                    EquipmentId = 5,
                    ItemId = 10
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 16,
                    EquipmentId = 6,
                    ItemId = 8
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 17,
                    EquipmentId = 6,
                    ItemId = 9
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 18,
                    EquipmentId = 6,
                    ItemId = 10
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 19,
                    EquipmentId = 6,
                    ItemId = 11
                },
                new EquipmentItemsApi
                {
                EquipmentItemsId = 25,
                EquipmentId = 6,
                ItemId = 20
            },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 20,
                    EquipmentId = 7,
                    ItemId = 14
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 21,
                    EquipmentId = 7,
                    ItemId = 9
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 22,
                    EquipmentId = 7,
                    ItemId = 10
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 23,
                    EquipmentId = 7,
                    ItemId = 11
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 24,
                    EquipmentId = 7,
                    ItemId = 20
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 26,
                    EquipmentId = 8,
                    ItemId = 14
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 27,
                    EquipmentId = 8,
                    ItemId = 15
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 28,
                    EquipmentId = 8,
                    ItemId = 10
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 29,
                    EquipmentId = 8,
                    ItemId = 11
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 30,
                    EquipmentId = 8,
                    ItemId = 20
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 31,
                    EquipmentId = 9,
                    ItemId = 7
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 32,
                    EquipmentId = 9,
                    ItemId = 14
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 33,
                    EquipmentId = 9,
                    ItemId = 15
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 34,
                    EquipmentId = 9,
                    ItemId = 16
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 35,
                    EquipmentId = 9,
                    ItemId = 18
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 36,
                    EquipmentId = 9,
                    ItemId = 19
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 37,
                    EquipmentId = 9,
                    ItemId = 17
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 32,
                    EquipmentId = 9,
                    ItemId = 14
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 33,
                    EquipmentId = 9,
                    ItemId = 15
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 34,
                    EquipmentId = 9,
                    ItemId = 16
                },
                new EquipmentItemsApi
                {
                    EquipmentItemsId = 36,
                    EquipmentId = 9,
                    ItemId = 19
                },
            };
            InventoryList = new List<InventoryApi>
            {
                new InventoryApi
                {
                    InventoryId = 1,
                    Name = "Player inventory"
                }
            };
            InventoryItemsList = new List<InventoryItemsApi>
            {
                new InventoryItemsApi
                {
                    InventoryItemId = 1,
                    InventoryId = 1,
                    ItemId = 1
                }
            };
            PlayerList = new List<PlayerApi>
            {
                new PlayerApi
                {
                    CharacterId = 11,
                    Coins = 500L,
                    Exp = 0,
                    InventoryId = 1,
                 Name   = "Player",
                 Password = "Password",
                 PlayerId = 1,
                 StatusPointsAttack = 0,
                 StatusPointsDefence = 0,
                 StatusPointsHitpoints = 0,
                 StatusPointsLeft = 5,
                 StatusPointsStrength = 0
                }
            };
            RewardList = new List<RewardApi>
            {
                new RewardApi
                {
                    Coins = 120,
                    Exp = 100,
                    ItemId = 2,
                    RewardId = 1
                },

                new RewardApi
                {
                    Coins = 200,
                    Exp = 150,
                    ItemId = 3,
                    RewardId = 2
                },
                new RewardApi
                {
                Coins = 500,
                Exp = 400,
                ItemId = 6,
                RewardId = 3
            },

                new RewardApi
                {
                    Coins = 1000,
                    Exp = 600,
                    ItemId =9,
                    RewardId = 4
                },

                new RewardApi
                {
                    Coins = 1200,
                    Exp = 800,
                    ItemId = 7,
                    RewardId = 5
                },
                new RewardApi
                {
                    Coins = 2000,
                    Exp = 1500,
                    ItemId = 12,
                    RewardId = 6
                },

                new RewardApi
                {
                    Coins = 2300,
                    Exp = 1800,
                    ItemId =11,
                    RewardId = 7
                },

                new RewardApi
                {
                    Coins = 2800,
                    Exp = 2000,
                    ItemId = 13,
                    RewardId = 8
                },
                new RewardApi
                {
                    Coins = 4000,
                    Exp = 2500,
                    ItemId = 17,
                    RewardId = 9
                },
                new RewardApi
                {
                    Coins = 10000,
                    Exp = 8000,
                    ItemId = 15,
                    RewardId = 10
                }
            };
            ShopList = new List<ShopApi>
             {
                 new ShopApi
                 {
                     Name = "General Store",
                     ShopId = 1
                 }
             };
            StageList = new List<StageApi>
             {
                 new StageApi
                 {
                     BackgroundId = 1,
                     CharacterId = 1,
                     Name = "Stage 1",
                     RewardId = 1,
                     StageId = 1
                 },
                 new StageApi
                 {
                     BackgroundId = 2,
                     CharacterId = 2,
                     Name = "Stage 2",
                     RewardId = 2,
                     StageId = 2
                 },
                 new StageApi
                 {
                     BackgroundId = 3,
                     CharacterId = 3,
                     Name = "Stage 3",
                     RewardId = 3,
                     StageId = 3
                 },
                 new StageApi
                 {
                     BackgroundId = 4,
                     CharacterId = 4,
                     Name = "Stage 4",
                     RewardId = 4,
                     StageId = 4
                 },
                 new StageApi
                 {
                     BackgroundId = 5,
                     CharacterId = 5,
                     Name = "Stage 5",
                     RewardId = 5,
                     StageId = 5
                 },
                 new StageApi
                 {
                     BackgroundId = 6,
                     CharacterId = 6,
                     Name = "Stage 6",
                     RewardId = 6,
                     StageId = 6
                 },
                 new StageApi
                 {
                     BackgroundId = 7,
                     CharacterId = 7,
                     Name = "Stage 7",
                     RewardId = 7,
                     StageId = 7
                 },
                 new StageApi
                 {
                     BackgroundId = 8,
                     CharacterId = 8,
                     Name = "Stage 8",
                     RewardId = 8,
                     StageId = 8
                 },
                 new StageApi
                 {
                     BackgroundId =9,
                     CharacterId = 9,
                     Name = "Stage 9",
                     RewardId = 9,
                     StageId = 9
                 },
                 new StageApi
                 {
                     BackgroundId = 10,
                     CharacterId = 10,
                     Name = "Final Stage",
                     RewardId = 10,
                     StageId = 10
                 }
             };
            StatsList = new List<StatsApi>
             {
                 new StatsApi
                 {
                     Attack = 5,
                     Defence = 10,
                     Lifepoints = 15,
                     Strength = 8,
                     StatsId = 1
                 },
                 new StatsApi
                 {
                     Attack = 15,
                     Defence = 18,
                     Lifepoints = 22,
                     Strength = 6,
                     StatsId = 2
                 },
                 new StatsApi
                 {
                     Attack = 24,
                     Defence = 10,
                     Lifepoints = 30,
                     Strength = 17,
                     StatsId = 3
                 },
                 new StatsApi
                 {
                     Attack = 30,
                     Defence = 22,
                     Lifepoints = 40,
                     Strength = 40,
                     StatsId = 4
                 },

                 new StatsApi
                 {
                     Attack = 10,
                     Defence = 40,
                     Lifepoints = 70,
                     Strength = 8,
                     StatsId = 5
                 },

                 new StatsApi
                 {
                     Attack = 60,
                     Defence = 10,
                     Lifepoints = 80,
                     Strength = 60,
                     StatsId = 6
                 },

                 new StatsApi
                 {
                     Attack = 68,
                     Defence = 10,
                     Lifepoints = 85,
                     Strength = 70,
                     StatsId = 7
                 },

                 new StatsApi
                 {
                     Attack = 20,
                     Defence = 90,
                     Lifepoints = 100,
                     Strength = 20,
                     StatsId = 8
                 },
                 new StatsApi
                 {
                     Attack = 70,
                     Defence = 70,
                     Lifepoints = 120,
                     Strength = 70,
                     StatsId = 9
                 },
                 new StatsApi
                 {
                     Attack = 120,
                     Defence = 120,
                     Lifepoints = 200,
                     Strength = 120,
                     StatsId = 10
                 },
             };
            StockList = new List<StockApi>
             {
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 1
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 2
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 3
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 4
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 5
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 6
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 7
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 8
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 9
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 10
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 11
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 12
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 13
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 14
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 15
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 16
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 17
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 18
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 19
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 20
                 },
                 new StockApi
                 {
                     StockId = 1,
                     ShopId = 1,
                     ItemId = 21
                 },


             };
            TypeItemList = new List<TypeItemApi>
             {
                 new TypeItemApi
                 {
                     TypeItemId = 1,
                     TypeId = 1,
                     ItemId = 1
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 2,
                     TypeId = 1,
                     ItemId = 7
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 3,
                     TypeId = 1,
                     ItemId = 13
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 4,
                     TypeId = 1,
                     ItemId = 1
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 5,
                     TypeId = 2,
                     ItemId = 5
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 6,
                     TypeId = 2,
                     ItemId = 11
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 7,
                     TypeId = 2,
                     ItemId = 17
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 8,
                     TypeId = 3,
                     ItemId = 2
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 9,
                     TypeId = 3,
                     ItemId = 8
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 10,
                     TypeId = 3,
                     ItemId = 14
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 11,
                     TypeId = 4,
                     ItemId = 3
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 12,
                     TypeId = 4,
                     ItemId = 9
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 13,
                     TypeId = 4,
                     ItemId = 15
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 14,
                     TypeId = 5,
                     ItemId = 4
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 15,
                     TypeId = 5,
                     ItemId = 10
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 16,
                     TypeId = 5,
                     ItemId = 16
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 17,
                     TypeId = 6,
                     ItemId = 6
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 18,
                     TypeId = 6,
                     ItemId = 12
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 19,
                     TypeId = 6,
                     ItemId = 18
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 20,
                     TypeId = 7,
                     ItemId = 21
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 20,
                     TypeId = 7,
                     ItemId = 20
                 },
                 new TypeItemApi
                 {
                     TypeItemId = 20,
                     TypeId = 7,
                     ItemId = 19
                 }


             };

        }
    }
}
