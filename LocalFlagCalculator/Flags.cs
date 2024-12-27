using System;
using System.ComponentModel;

namespace LocalFlagCalculator.LocalFlagCalculator
{
    [Flags]
    public enum Local_Flags
    {
        [Description("Korea")] LOCAL_FLAG_KOREA = 1 << 0,
        [Description("Hong Kong")] LOCAL_FLAG_HONGKONG = 1 << 1,
        [Description("America")] LOCAL_FLAG_AMERICA = 1 << 2,
        [Description("Germany")] LOCAL_FLAG_GERMAN = 1 << 3,
        [Description("Japan")] LOCAL_FLAG_JAPAN = 1 << 4,
        [Description("Taiwan")] LOCAL_FLAG_TAIWAN = 1 << 5,
        [Description("China")] LOCAL_FLAG_CHINA = 1 << 6,
        [Description("France")] LOCAL_FLAG_FRANCE = 1 << 7,
        [Description("Russia")] LOCAL_FLAG_RUSSIA = 1 << 8,
        [Description("Malaysia")] LOCAL_FLAG_MALAYSIA = 1 << 9,
        [Description("Singapore")] LOCAL_FLAG_SINGAPORE = 1 << 10,
        [Description("Vietnam")] LOCAL_FLAG_VIETNAM = 1 << 11,
        [Description("Thailand")] LOCAL_FLAG_THAILAND = 1 << 12,
        [Description("Middle East")] LOCAL_FLAG_MIDEAST = 1 << 13,
        [Description("Turkey")] LOCAL_FLAG_TURKEY = 1 << 14,
        [Description("Poland")] LOCAL_FLAG_POLAND = 1 << 15,
        [Description("Italy")] LOCAL_FLAG_ITALY = 1 << 16,
        [Description("Brazil")] LOCAL_FLAG_BRAZIL = 1 << 17,
        [Description("Spain")] LOCAL_FLAG_ESPANIA = 1 << 18,
        [Description("Indonesia")] LOCAL_FLAG_INDONESIA = 1 << 19,
        [Description("Test Server")] LOCAL_FLAG_TEST_SERV = 1 << 29,
        [Description("Service Server")] LOCAL_FLAG_SERVICE_SERV = 1 << 30
    }

    [Flags]
    public enum State_Time_Flags
    {
        [Description("Erase on Death")] ERASE_ON_DEAD = 1 << 0,
        [Description("Erase on Logout")] ERASE_ON_LOGOUT = 1 << 1,
        [Description("Decrease on Logout")] TIME_DECREASE_ON_LOGOUT = 1 << 2,
        [Description("Not Actable to Boss")] NOT_ACTABLE_TO_BOSS = 1 << 3,
        [Description("Not Erasable")] NOT_ERASABLE = 1 << 4,
        [Description("Erase on Request")] ERASE_ON_REQUEST = 1 << 5,
        [Description("Erase on Damage")] ERASE_ON_DAMAGED = 1 << 6,
        [Description("Erase on Resurrection")] ERASE_ON_RESURRECT = 1 << 7,
        [Description("Erase on Quit Huntaholic")] ERASE_ON_QUIT_HUNTAHOLIC = 1 << 8,
        [Description("Erase on Quit Deathmatch")] ERASE_ON_QUIT_DEATHMATCH = 1 << 9,
        [Description("Not Erasable on DM Enter")] NOT_ERASABLE_ON_ENTER_DEATHMATCH = 1 << 10,
        [Description("Not Actable on DM")] NOT_ACTABLE_ON_DEATHMATCH = 1 << 11,
        [Description("Erase on Compete Start")] ERASE_ON_COMPETE_START = 1 << 12,
        [Description("Not Actable in Compete")] NOT_ACTABLE_IN_COMPETE = 1 << 13,
        [Description("World State Only")] ONLY_FOR_WORLD_STATE = 1 << 14,
        [Description("Erase on Quit Arena")] ERASE_ON_QUIT_BATTLE_ARENA = 1 << 15,
        [Description("Erase on Stand Up")] ERASE_ON_STAND_UP = 1 << 16,
        [Description("Unknown 1")] UNKNOW1 = 1 << 17,
        [Description("Unknown 2")] UNKNOW2 = 1 << 18,
        [Description("Unknown 3")] UNKNOW3 = 1 << 19
    }

    [Flags]
    public enum AttributeFlags
    {
        [Description("Strength")] FLAG_STR = 1 << 0,
        [Description("Vitality")] FLAG_VIT = 1 << 1,
        [Description("Agility")] FLAG_AGI = 1 << 2,
        [Description("Dexterity")] FLAG_DEX = 1 << 3,
        [Description("Intelligence")] FLAG_INT = 1 << 4,
        [Description("Wisdom")] FLAG_MEN = 1 << 5,
        [Description("Luck")] FLAG_LUK = 1 << 6,
        [Description("Attack Points")] FLAG_ATTACK_POINT = 1 << 7,
        [Description("Magic Points")] FLAG_MAGIC_POINT = 1 << 8,
        [Description("Defense")] FLAG_DEFENCE = 1 << 9,
        [Description("Magic Defense")] FLAG_MAGIC_DEFENCE = 1 << 10,
        [Description("Attack Speed")] FLAG_ATTACK_SPEED = 1 << 11,
        [Description("Casting Speed")] FLAG_CAST_SPEED = 1 << 12,
        [Description("Movement Speed")] FLAG_MOVE_SPEED = 1 << 13,
        [Description("Accuracy")] FLAG_ACCURACY = 1 << 14,
        [Description("Magic Accuracy")] FLAG_MAGIC_ACCURACY = 1 << 15,
        [Description("Critical Hit Chance")] FLAG_CRITICAL = 1 << 16,
        [Description("Block Chance")] FLAG_BLOCK = 1 << 17,
        [Description("Block Defense")] FLAG_BLOCK_DEFENCE = 1 << 18,
        [Description("Evasion")] FLAG_AVOID = 1 << 19,
        [Description("Magic Resistance")] FLAG_MAGIC_RESISTANCE = 1 << 20,
        [Description("Max HP")] FLAG_MAX_HP = 1 << 21,
        [Description("Max MP")] FLAG_MAX_MP = 1 << 22,
        [Description("Max SP")] FLAG_MAX_SP = 1 << 23,
        [Description("HP Regen Add")] FLAG_HP_REGEN_ADD = 1 << 24,
        [Description("MP Regen Add")] FLAG_MP_REGEN_ADD = 1 << 25,
        [Description("SP Regen Add")] FLAG_SP_REGEN_ADD = 1 << 26,
        [Description("HP Regen Ratio")] FLAG_HP_REGEN_RATIO = 1 << 27,
        [Description("MP Regen Ratio")] FLAG_MP_REGEN_RATIO = 1 << 28,
        [Description("Triple Critical Damage")] FLAG_CRITICAL_DAMAGE_X3 = 1 << 29,
        [Description("Max Weight")] FLAG_MAX_WEIGHT = 1 << 30
    }

    [Flags]
    public enum ResistanceFlags
    {
        [Description("No Resistance")] FLAG_ET_NONE_RESIST = 1 << 0,
        [Description("Fire Resistance")] FLAG_ET_FIRE_RESIST = 1 << 1,
        [Description("Water Resistance")] FLAG_ET_WATER_RESIST = 1 << 2,
        [Description("Wind Resistance")] FLAG_ET_WIND_RESIST = 1 << 3,
        [Description("Earth Resistance")] FLAG_ET_EARTH_RESIST = 1 << 4,
        [Description("Light Resistance")] FLAG_ET_LIGHT_RESIST = 1 << 5,
        [Description("Dark Resistance")] FLAG_ET_DARK_RESIST = 1 << 6,
        [Description("Attack Range")] FLAG_ET_ATTACK_RANGE = 1 << 8,
        [Description("Perfect Block")] FLAG_ET_PERFECT_BLOCK = 1 << 9,
        [Description("Ignore Physical Defense")] FLAG_ET_IGNORE_PHYSICAL_DEFENCE = 1 << 10,
        [Description("Ignore Magical Defense")] FLAG_ET_IGNORE_MAGICAL_DEFENCE = 1 << 11,
        [Description("No Damage")] FLAG_ET_NONE_DAMAGE = 1 << 14,
        [Description("Fire Damage")] FLAG_ET_FIRE_DAMAGE = 1 << 15,
        [Description("Water Damage")] FLAG_ET_WATER_DAMAGE = 1 << 16,
        [Description("Wind Damage")] FLAG_ET_WIND_DAMAGE = 1 << 17,
        [Description("Earth Damage")] FLAG_ET_EARTH_DAMAGE = 1 << 18,
        [Description("Light Damage")] FLAG_ET_LIGHT_DAMAGE = 1 << 19,
        [Description("Dark Damage")] FLAG_ET_DARK_DAMAGE = 1 << 20,
        [Description("No Additional Damage")] FLAG_ET_NONE_ADDITIONAL_DAMAGE = 1 << 21,
        [Description("Additional Fire Damage")] FLAG_ET_FIRE_ADDITIONAL_DAMAGE = 1 << 22,
        [Description("Additional Water Damage")] FLAG_ET_WATER_ADDITIONAL_DAMAGE = 1 << 23,
        [Description("Additional Wind Damage")] FLAG_ET_WIND_ADDITIONAL_DAMAGE = 1 << 24,
        [Description("Additional Earth Damage")] FLAG_ET_EARTH_ADDITIONAL_DAMAGE = 1 << 25,
        [Description("Additional Light Damage")] FLAG_ET_LIGHT_ADDITIONAL_DAMAGE = 1 << 26,
        [Description("Additional Dark Damage")] FLAG_ET_DARK_ADDITIONAL_DAMAGE = 1 << 27,
        [Description("Critical Damage")] FLAG_CRITICAL_DAMAGE = 1 << 28,
        [Description("Stop HP Regen")] FLAG_HP_REGEN_STOP = 1 << 29,
        [Description("Stop MP Regen")] FLAG_MP_REGEN_STOP = 1 << 30
    }

    [Flags]
    public enum EquipmentFlags
    {
        [Description("One-Handed Sword")] FLAG_EQUIP_ONEHAND_SWORD = 1 << 0,
        [Description("Two-Handed Sword")] FLAG_EQUIP_TWOHAND_SWORD = 1 << 1,
        [Description("Dagger")] FLAG_EQUIP_DAGGER = 1 << 2,
        [Description("Two-Handed Spear")] FLAG_EQUIP_TWOHAND_SPEAR = 1 << 3,
        [Description("Two-Handed Axe")] FLAG_EQUIP_TWOHAND_AXE = 1 << 4,
        [Description("One-Handed Mace")] FLAG_EQUIP_ONEHAND_MACE = 1 << 5,
        [Description("Two-Handed Mace")] FLAG_EQUIP_TWOHAND_MACE = 1 << 6,
        [Description("Heavy Bow")] FLAG_EQUIP_HEAVY_BOW = 1 << 7,
        [Description("Light Bow")] FLAG_EQUIP_LIGHT_BOW = 1 << 8,
        [Description("Crossbow")] FLAG_EQUIP_CROSSBOW = 1 << 9,
        [Description("One-Handed Staff")] FLAG_EQUIP_ONEHAND_STAFF = 1 << 10,
        [Description("Two-Handed Staff")] FLAG_EQUIP_TWOHAND_STAFF = 1 << 11,
        [Description("Dual Swords")] FLAG_EQUIP_DOUBLE_SWORD = 1 << 12,
        [Description("Dual Daggers")] FLAG_EQUIP_DOUBLE_DAGGER = 1 << 13
    }
}
