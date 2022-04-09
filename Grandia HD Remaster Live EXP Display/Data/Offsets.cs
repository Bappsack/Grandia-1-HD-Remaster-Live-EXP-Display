namespace Grandia_1_HD_Remaster_Live_EXP_Display
{
    public class GameDataOffsets
    {
        public class Grandia1
        {
            public static string Ingame_Characters_Stats = "grandia.exe+0x00212CAC,100";
            public static string DebugMenu = "grandia.exe+0x23B20E";
        }
        public class Grandia2
        {
            public static string Ingame_Characters_Stats = "grandia2.exe+0x0002D210,54";
            public static string Ingame_Battle_Rewards = "grandia2.exe+0x002341F4,88";
        }
    }
    public class Offsets
    {
        public class Grandia1
        {

            public class CharacterStats
            {
                public uint SlotGap = 0x1EC; // Gap Between Characters

                // Character Stats
                public uint Character = 0xF;
                public uint HP_Current = 0x00; // 2 Bytes
                public uint HP_Max = 0x2; // 2 Bytes

                public uint STR = 0x6; // 2 Bytes
                public uint VIT = 0x8; // 2 Bytes
                public uint WIT = 0xA; // 2 Bytes
                public uint AGI = 0xC; // 2 Bytes
                public byte Level = 0xE; // 1 Byte

                public uint Current_EXP = 0x68;
                public uint Total_EXP = 0x6C;

                /// Skill Points / Magic Points
                public byte SP_Current = 0x6E; // 2 Bytes
                public byte SP_Total = 0x70; // 2 Bytes

                public byte Magic1_Current = 0x12;
                public byte Magic1_Total = 0x15;

                public byte Magic2_Current = 0x13;
                public byte Magic2_Total = 0x16;

                public byte Magic3_Current = 0x14;
                public byte Magic3_Total = 0x17;


                // Magic/Weapon Level/Experience

                public byte FireLevel = 0x7A;
                public byte FireEXP = 0x86;

                public byte WaterLevel = 0x7B;
                public byte WaterEXP = 0x88;

                public byte WindLevel = 0x7C;
                public byte WindEXP = 0x8A;

                public byte EarthLevel = 0x7D;
                public byte EarthEXP = 0x8C;

                public byte Weapon1Level = 0x76;
                public byte Weapon1EXP = 0x7E;

                public byte Weapon2Level = 0x77;
                public byte Weapon2EXP = 0x80;

                public byte Weapon3Level = 0x78;
                public byte Weapon3EXP = 0x82;

                public byte Weapon4Level = 0x79;
                public byte Weapon4EXP = 0x84;
            }

        }

        public class Grandia2
        {
            public class BattleRewardsOffsets
            {
                public uint EXP = 0xAA0;
                public uint Gold = 0xAA4;
                public uint SP_Coins = 0xAA8;
                public uint MP_Coins = 0xAAC;

                public uint SP_Total = 0x228;
                public uint MP_Total = 0x22C;
                public uint Gold_Total = 0x224;
            }

            public class CharacterStats
            {
                public uint SlotGap = 0x254; // Gap Between Characters

                // Character Stats
                public uint HP_Current = 0xD4; // 2 Bytes
                public uint HP_Total = 0xD0; // 2 Bytes

                public uint STR = 0xC0; // 2 Bytes
                public uint VIT = 0xC2; // 2 Bytes
                public uint WIT = 0xC4; // 2 Bytes
                public uint AGI = 0xC6; // 2 Bytes
                public byte Level = 0xC8; // 1 Byte

                //public uint EXP_Total = 0x7C;
                //public uint EXP_Next = 0x6C;


                /// Skill Points / Magic Points
                public byte SP_Current = 0xE4; // 2 Bytes
                public byte SP_Total = 0xE0; // 2 Bytes

                public byte Magic_Current = 0xDC;
                public byte Magic_Total = 0xD8;
            }

        }
    }
}
