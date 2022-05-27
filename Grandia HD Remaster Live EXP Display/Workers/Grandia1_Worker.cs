using Grandia_HD_Remaster_Live_EXP_Display;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Grandia_1_HD_Remaster_Live_EXP_Display
{
    public static class Grandia1_Worker
    {
        private readonly static Memory.Mem memory = new Memory.Mem();
        private readonly static Offsets.Grandia1.CharacterStats offsets = new Offsets.Grandia1.CharacterStats();

        private static bool ProcessExist() => System.Diagnostics.Process.GetProcessesByName(Structures.Processes.Grandia).Length > 0;

        public static async void Loop()
        {
            if (ProcessExist())
                memory.OpenProcess(Structures.Processes.Grandia);

            while (Program.Grandia1_Running)
            {
                try
                {
                    if (!ProcessExist())
                    {
                        MessageBox.Show("Grandia was closed, reading stopped!");
                        return;
                    }

                    byte[] Characters = memory.ReadBytes(GameDataOffsets.Grandia1.Battle_Characters_Stats, 3000);

                    var CharacterList = new List<Structures.Grandia1.Character>();

                    if (Characters is null)
                    {
                        MessageBox.Show("Unable to read Data!\n\n Make sure you were in a Battle atleast once!");
                        return;
                    }

#if DEBUG
                    System.IO.File.WriteAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\debug.bin", Characters);
#endif

                    for (int i = 0; i < 4; i++)
                    {
                        long Gap = i * offsets.SlotGap;

                        // EXP
                        var FireEXP = Characters[Gap + offsets.FireEXP];
                        var WindEXP = Characters[Gap + offsets.WindEXP];
                        var WaterEXP = Characters[Gap + offsets.WaterEXP];
                        var EarthEXP = Characters[Gap + offsets.EarthEXP];

                        var Weapon1EXP = Characters[Gap + offsets.Weapon1EXP];
                        var Weapon2EXP = Characters[Gap + offsets.Weapon2EXP];
                        var Weapon3EXP = Characters[Gap + offsets.Weapon3EXP];

                        var slot = new Structures.Grandia1.Character
                        {
                            // Character Stats
                            Name = ((Structures.Grandia1.Characters)Characters[Gap + offsets.Character]).ToString(),

                            Current_EXP = BitConverter.ToUInt16(Characters, (int)(Gap + offsets.Current_EXP)),
                            Total_EXP = BitConverter.ToUInt16(Characters, (int)(Gap + offsets.Total_EXP)),

                            HP_Current = BitConverter.ToInt16(Characters, (int)(Gap + offsets.HP_Current)),
                            HP_Max = BitConverter.ToInt16(Characters, (int)(Gap + offsets.HP_Max)),
                            SP_Current = BitConverter.ToInt16(Characters, (int)(Gap + offsets.SP_Current)),
                            SP_Total = BitConverter.ToInt16(Characters, (int)(Gap + offsets.SP_Total)),

                            Magic1_Current = Characters[Gap + offsets.Magic1_Current],
                            Magic1_Total = Characters[Gap + offsets.Magic1_Total],
                            Magic2_Current = Characters[Gap + offsets.Magic2_Current],
                            Magic2_Total = Characters[Gap + offsets.Magic2_Total],
                            Magic3_Current = Characters[Gap + offsets.Magic3_Current],
                            Magic3_Total = Characters[Gap + offsets.Magic3_Total],

                            // Base Stats
                            STR = BitConverter.ToInt16(Characters, (int)(Gap + offsets.STR)),
                            WIT = BitConverter.ToInt16(Characters, (int)(Gap + offsets.WIT)),
                            VIT = BitConverter.ToInt16(Characters, (int)(Gap + offsets.VIT)),
                            AGI = BitConverter.ToInt16(Characters, (int)(Gap + offsets.AGI)),

                            Level = Characters[Gap + offsets.Level],

                            FireLevel = Characters[Gap + offsets.FireLevel],
                            WindLevel = Characters[Gap + offsets.WindLevel],
                            WaterLevel = Characters[Gap + offsets.WaterLevel],
                            EarthLevel = Characters[Gap + offsets.EarthLevel],

                            Weapon1Level = Characters[Gap + offsets.Weapon1Level],
                            Weapon2Level = Characters[Gap + offsets.Weapon2Level],
                            Weapon3Level = Characters[Gap + offsets.Weapon3Level],

                            FireEXP = Characters[Gap + offsets.FireEXP],
                            WindEXP = Characters[Gap + offsets.WindEXP],
                            WaterEXP = Characters[Gap + offsets.WaterEXP],
                            EarthEXP = Characters[Gap + offsets.EarthEXP],

                            Weapon1EXP = Characters[Gap + offsets.Weapon1EXP],
                            Weapon2EXP = Characters[Gap + offsets.Weapon2EXP],
                            Weapon3EXP = Characters[Gap + offsets.Weapon3EXP],
                        };
                        CharacterList.Add(slot);
                    }

                    await Program.Form.Update_Grandia1_Stats(CharacterList);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }
    }
}
