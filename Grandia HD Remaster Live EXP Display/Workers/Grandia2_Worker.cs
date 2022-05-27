using Grandia_HD_Remaster_Live_EXP_Display;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grandia_1_HD_Remaster_Live_EXP_Display
{
    public class Grandia2_Worker
    {
        private readonly static Memory.Mem memory = new Memory.Mem();
        private readonly static Offsets.Grandia2.BattleRewardsOffsets battle_offsets = new Offsets.Grandia2.BattleRewardsOffsets();
        private static bool ProcessExist() => System.Diagnostics.Process.GetProcessesByName(Structures.Processes.Grandia2).Length > 0;

        public static async void Loop()
        {
            if (ProcessExist())
                memory.OpenProcess(Structures.Processes.Grandia2);

            while (Program.Grandia2_Running)
            {
                try
                {
                    byte[] Dump_battle = memory.ReadBytes(GameDataOffsets.Grandia2.Ingame_Battle_Rewards, 4000);

                    var characters = new List<Structures.Grandia2.Character>();

                    if (!ProcessExist())
                    {
                        MessageBox.Show("Grandia 2 was closed, reading stopped!");
                        return;
                    }

                    if (Dump_battle is null)
                    {
                        MessageBox.Show("Unable to read Data!\n\n Make sure you were in a Battle atleast once!");
                        return;
                    }

#if DEBUG
                    System.IO.File.WriteAllBytes(System.IO.Directory.GetCurrentDirectory() + "\\debug.bin", Dump_battle);
#endif

                    var battle_Stats = new Structures.Grandia2.BattleRewards
                    {
                        EXP = BitConverter.ToInt32(Dump_battle, (int)battle_offsets.EXP),
                        Gold = BitConverter.ToInt32(Dump_battle, (int)battle_offsets.Gold),
                        Gold_Total = BitConverter.ToInt32(Dump_battle, (int)battle_offsets.Gold_Total),
                        SP_Coins = BitConverter.ToInt32(Dump_battle, (int)battle_offsets.SP_Coins),
                        SP_Total = BitConverter.ToInt32(Dump_battle, (int)battle_offsets.SP_Total),
                        MP_Coins = BitConverter.ToInt32(Dump_battle, (int)battle_offsets.MP_Coins),
                        MP_Total = BitConverter.ToInt32(Dump_battle, (int)battle_offsets.MP_Total),
                    };

                    await Task.Delay(Program.RefreshTime);

                    await Program.Form.Update_Grandia2_Stats(battle_Stats, characters);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }
    }
}
