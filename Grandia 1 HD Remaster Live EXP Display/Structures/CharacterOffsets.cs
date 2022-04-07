namespace Grandia_1_HD_Remaster_Live_EXP_Display
{
    public class CharacterOffsets
    {
        public enum Characters
        {
            Justin,
            Sue,
            Feena,
            Gadwin,
            Rapp,
            Milda,
            Guido,
            Liete
        }

        public class CharacterStats
        {
            public uint SlotGap = 0x1EC; // Gap Between Characters

            // Character Stats
            public uint HP_Current = 0x00; // 2 Bytes
            public uint HP_Max = 0x2; // 2 Bytes

            public uint STR = 0x6; // 2 Bytes
            public uint VIT = 0x8; // 2 Bytes
            public uint WIT = 0xA; // 2 Bytes
            public uint AGI = 0xC; // 2 Bytes
            public byte Level = 0xE; // 1 Byte

            //public uint EXP_Total = 0x7C;
            //public uint EXP_Next = 0x6C;


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
}
