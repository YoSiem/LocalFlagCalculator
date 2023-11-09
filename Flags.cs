namespace LocalFlagCalculator
{
    [Flags]
    public enum Local_Flags
    {
        LOCAL_FLAG_KOREA = 1 << 0,
        LOCAL_FLAG_HONGKONG = 1 << 1,
        LOCAL_FLAG_AMERICA = 1 << 2,
        LOCAL_FLAG_GERMAN = 1 << 3,
        LOCAL_FLAG_JAPAN = 1 << 4,
        LOCAL_FLAG_TAIWAN = 1 << 5,
        LOCAL_FLAG_CHINA = 1 << 6,
        LOCAL_FLAG_FRANCE = 1 << 7,
        LOCAL_FLAG_RUSSIA = 1 << 8,
        LOCAL_FLAG_MALAYSIA = 1 << 9,
        LOCAL_FLAG_SINGAPORE = 1 << 10,
        LOCAL_FLAG_VIETNAM = 1 << 11,
        LOCAL_FLAG_THAILAND = 1 << 12,
        LOCAL_FLAG_MIDEAST = 1 << 13,
        LOCAL_FLAG_TURKEY = 1 << 14,
        LOCAL_FLAG_POLAND = 1 << 15,
        LOCAL_FLAG_ITALY = 1 << 16,
        LOCAL_FLAG_BRAZIL = 1 << 17,
        LOCAL_FLAG_ESPANIA = 1 << 18,
        LOCAL_FLAG_INDONESIA = 1 << 19,
        LOCAL_FLAG_TEST_SERV = 1 << 29,
        LOCAL_FLAG_SERVICE_SERV = 1 << 30
    }
    [Flags]
    public enum State_Time_Flags
    {
        ERASE_ON_DEAD                       = 1 << 0, // Erase when the player or entity is dead.
        ERASE_ON_LOGOUT                     = 1 << 1, // Erase when the player logs out.
        TIME_DECREASE_ON_LOGOUT             = 1 << 2, // Decrease the time when the player logs out.

        NOT_ACTABLE_TO_BOSS                 = 1 << 3, // Cannot be applied to bosses.
        NOT_ERASABLE                        = 1 << 4, // Cannot be erased.
        ERASE_ON_REQUEST                    = 1 << 5, // Erase upon a specific request.
        ERASE_ON_DAMAGED                    = 1 << 6, // Erase when damaged.
        ERASE_ON_RESURRECT                  = 1 << 7, // Erase upon resurrection.
        ERASE_ON_QUIT_HUNTAHOLIC            = 1 << 8, // Erase when quitting huntaholic mode.

        ERASE_ON_QUIT_DEATHMATCH            = 1 << 9, // Erase when quitting a deathmatch.
        NOT_ERASABLE_ON_ENTER_DEATHMATCH    = 1 << 10, // Not erasable upon entering a deathmatch.
        NOT_ACTABLE_ON_DEATHMATCH           = 1 << 11, // Cannot be applied during a deathmatch.
        ERASE_ON_COMPETE_START              = 1 << 12, // Erase at the start of a competition.
        NOT_ACTABLE_IN_COMPETE              = 1 << 13, // Cannot be applied during a competition.

        ONLY_FOR_WORLD_STATE                = 1 << 14, // Only applicable for the world state.

        ERASE_ON_QUIT_BATTLE_ARENA          = 1 << 15, // Erase when quitting a battle arena.
        ERASE_ON_STAND_UP                   = 1 << 16, // Erase when standing up.
        UNKNOW1                             = 1 << 17, // ???????????????
        UNKNOW2                             = 1 << 18, // ???????????????
        UNKNOW3                             = 1 << 19, // ???????????????
    }

}
