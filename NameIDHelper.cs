﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace giantsummon
{
    public class ItemTooltipIDs
    {
        public const string ItemName = "ItemName",
            Favorite = "Favorite",
            FavoriteDescription = "FavoriteDesc",
            Social = "Social",
            SocialDescription = "SocialDesc",
            Damage = "Damage",
            CriticalChance = "CritChance",
            AttackSpeed = "Speed",
            KnockbackPower = "Knockback",
            FishingPower = "FishingPower",
            NeedBaitText = "NeedsBait",
            BaitPower = "BaitPower",
            Equipable = "Equipable",
            WandItemConsume = "WandConsumes",
            Quest = "Quest",
            Vanity = "Vanity",
            Defense = "Defense",
            PickPower = "PickPower",
            AxePower = "AxePower",
            HammerPower = "HammerPower",
            TilePlacementBoost = "TileBoost",
            HealLife = "HealLife",
            HealMana = "HealMana",
            ManaUseText = "UseMana",
            Placeable = "Placeable",
            Ammo = "Ammo",
            Consumable = "Consumable",
            Material = "Material",
            ///<summary>It's followed by a number between 0 and max tooltip count - 1</summary>
            Tooltip = "Tooltip",
            EtherManaWarning = "EtherManaWarning",
            WellFedExpertText = "WellFedExpert",
            BuffTime = "BuffTime",
            OneDropLogo = "OneDropLogo",
            PrefixDamage = "PrefixDamage",
            PrefixSpeed = "PrefixSpeed",
            PrefixCritChance = "PrefixCritChance",
            PrefixUseMana = "PrefixUseMana",
            PrefixSize = "PrefixSize",
            PrefixShotSpeed = "PrefixShotSpeed",
            PrefixKnockback = "PrefixKnockback",
            PrefixAccDefense = "PrefixAccDefense",
            PrefixAccMaxMana = "PrefixAccMaxMana",
            PrefixAccCritChance = "PrefixAccCritChance",
            PrefixAccDamage = "PrefixAccDamage",
            PrefixAccMoveSpeed = "PrefixAccMoveSpeed",
            PrefixAccMeleeSpeed = "PrefixAccMeleeSpeed",
            SetBonus = "SetBonus",
            ExpertModeText = "Expert",
            Price = "Price";
    }

    public class InterfaceLayersID
    {
        public const string Interface_0_InterfaceLogic1 = "Vanilla: Interface Logic 1",
            Interface_1_EmoteBubbles = "Vanilla: Emote Bubbles",
            Interface_2_SmartCursorTargets = "Vanilla: Smart Cursor Targets",
            Interface_3_LaserRuller = "Vanilla: Laser Ruler",
            Interface_4_Ruler = "Vanilla: Ruler",
            Interface_5_GamePadLockOn = "Vanilla: Gamepad Lock On",
            Interface_6_TileGridOption = "Vanilla: Tile Grid Option",
            Interface_7_TownNpcHouseBanner = "Vanilla: Town NPC House Banners",
            Interface_8_HideUIToggle = "Vanilla: Hide UI Toggle",
            Interface_9_WireSelection = "Vanilla: Wire Selection",
            Interface_10_CaptureManagerCheck = "Vanilla: Capture Manager Check",
            Interface_11_IngameOptions = "Vanilla: Ingame Options",
            Interface_12_FancyUI = "Vanilla: Fancy UI",
            Interface_13_AchievementCompletePopups = "Vanilla: Achievement Complete Popups",
            Interface_14_EntityHealthBars = "Vanilla: Entity Health Bars",
            Interface_15_InvasionProgressBar = "Vanilla: Invasion Progress Bars",
            Interface_16_MapAndMinimap = "Vanilla: Map / Minimap",
            Interface_17_DiagnoseNet = "Vanilla: Diagnose Net",
            Interface_18_DiagnoseVideo = "Vanilla: Diagnose Video",
            Interface_19_SignTileBubble = "Vanilla: Sign Tile Bubble",
            Interface_20_MpPlayerNames = "Vanilla: MP Player Names",
            Interface_21_HairDresserWindow = "Vanilla: Hair Window",
            Interface_22_DresserWindow = "Vanilla: Dresser Window",
            Interface_23_NpcSignDialogue = "Vanilla: NPC / Sign Dialog",
            Interface_24_InterfaceLogic2 = "Vanilla: Interface Logic 2",
            Interface_25_ResourceBars = "Vanilla: Resource Bars",
            Interface_26_InterfaceLogic3= "Vanilla: Interface Logic 3",
            Interface_27_Inventory = "Vanilla: Inventory",
            Interface_28_InfoAccessoryBar = "Vanilla: Info Accessories Bar",
            Interface_29_SettingButton = "Vanilla: Settings Button",
            Interface_30_Hotbar = "Vanilla: Hotbar",
            Interface_31_BuilderAccessoryBar = "Vanilla: Builder Accessories Bar",
            Interface_32_RadialHotbars = "Vanilla: Radial Hotbars",
            Interface_33_MouseText = "Vanilla: Mouse Text",
            Interface_34_PlayerChat = "Vanilla: Player Chat",
            Interface_35_DeathText = "Vanilla: Death Text",
            Interface_36_Cursor = "Vanilla: Cursor",
            Interface_37_DebugStuff = "Vanilla: Debug Stuff",
            Interface_38_MouseItemOrNpcHead = "Vanilla: Mouse Item / NPC Head",
            Interface_39_MouseOver = "Vanilla: Mouse Over",
            Interface_40_InteractItemIcon = "Vanilla: Interact Item Icon",
            Interface_41_InterfaceLogic4 = "Vanilla: Interface Logic 4";
    }

    public class WorldGenerationStepID
    {
        public string Step_0_Reset = "Reset",
            Step_1_Terrain = "Terrain",
            Step_2_Tunnels = "Tunnels",
            Step_3_Sands = "Sand",
            Step_4_MountCaves = "Mount Caves",
            Step_5_DirtWallBackgrounds = "Dirt Wall Backgrounds",
            Step_6_RocksInDirt = "Rocks In Dirt",
            Step_7_DirtInRocks = "Dirt In Rocks",
            Step_8_Clay = "Clay",
            Step_9_SmallHoles = "Small Holes",
            Step_10_DirtLayerCaves = "Dirt Layer Caves",
            Step_11_RockLayerCaves = "Rock Layer Caves",
            Step_12_SurfaceCaves = "Surface Caves",
            Step_13_SlushCheck = "Slush Check",
            Step_14_Grass = "Grass",
            Step_15_Jungle = "Jungle",
            Step_16_Marble = "Marble",
            Step_17_Granite = "Granite",
            Step_18_MudCavesToGrass = "Mud Caves To Grass",
            Step_19_FullDesert = "Full Desert",
            Step_20_FloatingIslands = "Floating Islands",
            Step_21_MushroomPatches = "Mushroom Patches",
            Step_22_MudToDirt = "Mud To Dirt",
            Step_23_Silt = "Silt",
            Step_24_Shinies = "Shinies",
            Step_25_Webs = "Webs",
            Step_26_Underworld = "Underworld",
            Step_27_Lakes = "Lakes",
            Step_28_Dungeon = "Dungeon",
            Step_29_Corruption = "Corruption",
            Step_30_Slush = "Slush",
            Step_31_MudCavesToGrass = "Mud Caves To Grass",
            Step_32_Beaches = "Beaches",
            Step_33_Gems = "Gems",
            Step_34_GravitatingSands = "Gravitating Sand",
            Step_35_CleanUpDirt = "Clean Up Dirt",
            Step_36_Pyramids = "Pyramids",
            Step_37_DirtRockWallRunner = "Dirt Rock Wall Runner",
            Step_38_LivingTrees = "Living Trees",
            Step_39_WoodTreeWalls = "Wood Tree Walls",
            Step_40_Altars = "Altars",
            Step_41_WetJungle = "Wet Jungle",
            Step_42_RemoveWaterFromSand = "Remove Water From Sand",
            Step_43_JungleTemple = "Jungle Temple",
            Step_44_Hives = "Hives",
            Step_45_JungleChests = "Jungle Chests",
            Step_46_SmoothWorld = "Smooth World",
            Step_47_SettleLiquids = "Settle Liquids",
            Step_48_Waterfalls = "Waterfalls",
            Step_49_Ice = "Ice",
            Step_50_WallVariety = "Wall Variety",
            Step_51_Traps = "Traps",
            Step_52_LifeCrystals = "Life Crystals",
            Step_53_Statues = "Statues",
            Step_54_BuriedChests = "Buried Chests",
            Step_55_SurfaceChests = "Surface Chests",
            Step_56_JungleChestsPlacement = "Jungle Chests Placement",
            Step_57_WaterChests = "Water Chests",
            Step_58_SpiderCaves = "Spider Caves",
            Step_59_GemCaves = "Gem Caves",
            Step_60_Moss = "Moss",
            Step_61_Temple = "Temple",
            Step_62_IceWalls = "Ice Walls",
            Step_63_JungleTrees = "Jungle Trees",
            Step_64_FloatingIslandHouses = "Floating Island Houses",
            Step_65_QuickCleanup = "Quick Cleanup",
            Step_66_Pots = "Pots",
            Step_67_HellForge = "Hellforge",
            Step_68_SpreadingGrass = "Spreading Grass",
            Step_69_Piles = "Piles",
            Step_70_Moss = "Moss",
            Step_71_SpawnPoint = "Spawn Point",
            Step_72_GrassWalls = "Grass Wall",
            Step_73_Guide = "Guide",
            Step_74_Sunflowers = "Sunflowers",
            Step_75_PlantingTrees = "Planting Trees",
            Step_76_Herbs = "Herbs",
            Step_77_DyePlants = "Dye Plants",
            Step_78_WebsAndHoney = "Webs And Honey",
            Step_79_Weeds = "Weeds",
            Step_80_MudCavesToGrass = "Mud Caves To Grass",
            Step_81_JunglePlants = "Jungle Plants",
            Step_82_Vines = "Vines",
            Step_83_Flowers = "Flowers",
            Step_84_Mushrooms = "Mushrooms",
            Step_85_Stalactite = "Stalac",
            Step_86_GemsInIceBiome = "Gems In Ice Biome",
            Step_87_RandomGems = "Random Gems",
            Step_88_MossGrass = "Moss Grass",
            Step_89_MudWallsInJungle = "Muds Walls In Jungle",
            Step_90_QBLarva = "Larva",
            Step_91_SettleLiquidsAgain = "Settle Liquids Again",
            Step_92_TileCleanup = "Tile Cleanup",
            Step_93_LihzahrdAltars = "Lihzahrd Altars",
            Step_94_MicroBiomes = "Micro Biomes",
            Step_95_FinalCleanup = "Final Cleanup";
    }
}
