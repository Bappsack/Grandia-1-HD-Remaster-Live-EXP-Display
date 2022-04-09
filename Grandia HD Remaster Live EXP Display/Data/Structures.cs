namespace Grandia_1_HD_Remaster_Live_EXP_Display
{
    public static class Structures
    {
        public static class Processes
        {
            public static string Grandia = "grandia";
            public static string Grandia2 = "grandia2";
        }


        public class Grandia1
        {
            public enum Characters
            {
                Justin = 1,
                Sue = 3,
                Feena = 2,
                Gadwin = 4,
                Rapp = 5,
                Milda = 6,
                Guido = 7,
                Liete = 8,

                None = 0,
            }


            public class Character
            {
                public uint SlotGap;

                // Character Stats
                public string Name;

                public uint Current_EXP;
                public uint Total_EXP;

                public int HP_Current;
                public int HP_Max;

                public int STR;
                public int VIT;
                public int WIT;
                public int AGI;
                public int Level;

                /// Skill Points / Magic Points
                public int SP_Current;
                public int SP_Total;

                public int Magic1_Current;
                public int Magic1_Total;

                public int Magic2_Current;
                public int Magic2_Total;

                public int Magic3_Current;
                public int Magic3_Total;


                // Magic/Weapon Level/Experience

                public int FireLevel;
                public int FireEXP;

                public int WaterLevel;
                public int WaterEXP;

                public int WindLevel;
                public int WindEXP;

                public int EarthLevel;
                public int EarthEXP;

                public int Weapon1Level;
                public int Weapon1EXP;

                public int Weapon2Level;
                public int Weapon2EXP;

                public int Weapon3Level;
                public int Weapon3EXP;
            }
        }

        public class Grandia2
        {
            public enum Characters
            {
                Ryudo,
                Elena,
                Millenia,
                Roan,
                Mareg,
                Tio,
            }

            public class BattleRewards
            {
                public int EXP;
                public int Gold;
                public int SP_Coins;
                public int MP_Coins;

                public int SP_Total;
                public int MP_Total;
                public int Gold_Total;
            }

            public class Character
            {
                public uint SlotGap;

                // Character Stats
                public int HP_Current;
                public int HP_Total;

                public int STR;
                public int VIT;
                public int WIT;
                public int AGI;
                public int Level;

                /// Skill Points / Magic Points
                public int SP_Current;
                public int SP_Total;

                public int Magic_Current;
                public int Magic_Total;

            }
        }
    }
}
