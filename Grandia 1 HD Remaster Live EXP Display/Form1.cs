using Memory;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Grandia_1_HD_Remaster_Live_EXP_Display
{
    public partial class Form1 : Form
    {
        private Memory.Mem memory = new Mem();
        private static bool AllowExitLoop = true;

        public Form1()
        {
            InitializeComponent();
            Stop.Enabled = false;

            this.FormClosing += Form1_Close;
        }

        private void Form1_Close(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MemoryWatcher()
        {
            memory.OpenProcess("grandia");

            while (AllowExitLoop)
            {
                try
                {
                    byte[] Characters = memory.ReadBytes(GameOffsets.Ingame_Characters_Stats, 3000);

                    int RefreshTime = 1000; /// just in case

                    Refresh_Time_Box.Invoke((MethodInvoker)(() => int.TryParse(Refresh_Time_Box.Text, out RefreshTime)));

                    var stats = new CharacterOffsets.CharacterStats();

                    if (Characters is null)
                    {
                        MessageBox.Show("Unable to read Data!\n\n Make sure you were in a Battle atleast once!");
                        Start.Invoke((MethodInvoker)(() => Start.Enabled = true));
                        Start.Invoke((MethodInvoker)(() => Stop.Enabled = false));
                        AllowExitLoop = true;
                        return;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        long Gap = i * stats.SlotGap;
                        if (i is 0)
                        {
                            // Character Stats
                            HP_Current_1.Invoke((MethodInvoker)(() => HP_Current_1.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.HP_Current)).ToString()));
                            HP_Total_1.Invoke((MethodInvoker)(() => HP_Total_1.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.HP_Max)).ToString()));
                            SP_Current_1.Invoke((MethodInvoker)(() => SP_Current_1.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.SP_Current)).ToString()));
                            SP_Total_1.Invoke((MethodInvoker)(() => SP_Total_1.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.SP_Total)).ToString()));

                            MP1_Current_1.Invoke((MethodInvoker)(() => MP1_Current_1.Text = Characters[Gap + stats.Magic1_Current].ToString()));
                            MP1_Total_1.Invoke((MethodInvoker)(() => MP1_Total_1.Text = Characters[Gap + stats.Magic1_Total].ToString()));
                            MP2_Current_1.Invoke((MethodInvoker)(() => MP2_Current_1.Text = Characters[Gap + stats.Magic2_Current].ToString()));
                            MP2_Total_1.Invoke((MethodInvoker)(() => MP2_Total_1.Text = Characters[Gap + stats.Magic2_Total].ToString()));
                            MP3_Current_1.Invoke((MethodInvoker)(() => MP3_Current_1.Text = Characters[Gap + stats.Magic3_Current].ToString()));
                            MP3_Total_1.Invoke((MethodInvoker)(() => MP3_Total_1.Text = Characters[Gap + stats.Magic3_Total].ToString()));


                            // Base Stats
                            STR_1.Invoke((MethodInvoker)(() => STR_1.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.STR)).ToString()));
                            VIT_1.Invoke((MethodInvoker)(() => VIT_1.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.VIT)).ToString()));
                            WIT_1.Invoke((MethodInvoker)(() => WIT_1.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.WIT)).ToString()));
                            AGI_1.Invoke((MethodInvoker)(() => AGI_1.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.AGI)).ToString()));

                            Level_1.Invoke((MethodInvoker)(() => Level_1.Text = Characters[Gap + stats.Level].ToString()));


                            // Levels
                            label_Fire_Level_1.Invoke((MethodInvoker)(() => label_Fire_Level_1.Text = Characters[Gap + stats.FireLevel].ToString()));
                            label_Wind_Level_1.Invoke((MethodInvoker)(() => label_Wind_Level_1.Text = Characters[Gap + stats.WindLevel].ToString()));
                            label_Water_Level_1.Invoke((MethodInvoker)(() => label_Water_Level_1.Text = Characters[Gap + stats.WaterLevel].ToString()));
                            label_Earth_Level_1.Invoke((MethodInvoker)(() => label_Earth_Level_1.Text = Characters[Gap + stats.EarthLevel].ToString()));

                            label_Weapon1_Level_1.Invoke((MethodInvoker)(() => label_Weapon1_Level_1.Text = Characters[Gap + stats.Weapon1Level].ToString()));
                            label_Weapon2_Level_1.Invoke((MethodInvoker)(() => label_Weapon2_Level_1.Text = Characters[Gap + stats.Weapon2Level].ToString()));
                            label_Weapon3_Level_1.Invoke((MethodInvoker)(() => label_Weapon3_Level_1.Text = Characters[Gap + stats.Weapon3Level].ToString()));


                            // EXP
                            var FireEXP = Characters[Gap + stats.FireEXP];
                            var WindEXP = Characters[Gap + stats.WindEXP];
                            var WaterEXP = Characters[Gap + stats.WaterEXP];
                            var EarthEXP = Characters[Gap + stats.EarthEXP];

                            var Weapon1EXP = Characters[Gap + stats.Weapon1EXP];
                            var Weapon2EXP = Characters[Gap + stats.Weapon2EXP];
                            var Weapon3EXP = Characters[Gap + stats.Weapon3EXP];

                            label_Fire_EXP_1.Invoke((MethodInvoker)(() => label_Fire_EXP_1.Text = FireEXP.ToString()));
                            label_Wind_EXP_1.Invoke((MethodInvoker)(() => label_Wind_EXP_1.Text = WindEXP.ToString()));
                            label_Water_EXP_1.Invoke((MethodInvoker)(() => label_Water_EXP_1.Text = WaterEXP.ToString()));
                            label_Earth_EXP_1.Invoke((MethodInvoker)(() => label_Earth_EXP_1.Text = EarthEXP.ToString()));

                            label_Weapon1_EXP_1.Invoke((MethodInvoker)(() => label_Weapon1_EXP_1.Text = Weapon1EXP.ToString()));
                            label_Weapon2_EXP_1.Invoke((MethodInvoker)(() => label_Weapon2_EXP_1.Text = Weapon2EXP.ToString()));
                            label_Weapon3_EXP_1.Invoke((MethodInvoker)(() => label_Weapon3_EXP_1.Text = Weapon3EXP.ToString()));

                            /// Progress Bars
                            Fire_EXP_Progressbar_1.Invoke((MethodInvoker)(() => Fire_EXP_Progressbar_1.Value = FireEXP));
                            Wind_EXP_Progressbar_1.Invoke((MethodInvoker)(() => Wind_EXP_Progressbar_1.Value = WindEXP));
                            Water_EXP_Progressbar_1.Invoke((MethodInvoker)(() => Water_EXP_Progressbar_1.Value = WaterEXP));
                            Earth_EXP_Progressbar_1.Invoke((MethodInvoker)(() => Earth_EXP_Progressbar_1.Value = EarthEXP));

                            Weapon1_EXP_Progressbar_1.Invoke((MethodInvoker)(() => Weapon1_EXP_Progressbar_1.Value = Weapon1EXP));
                            Weapon2_EXP_Progressbar_1.Invoke((MethodInvoker)(() => Weapon2_EXP_Progressbar_1.Value = Weapon2EXP));
                            Weapon3_EXP_Progressbar_1.Invoke((MethodInvoker)(() => Weapon3_EXP_Progressbar_1.Value = Weapon3EXP));
                        }
                        else if (i is 1)
                        {
                            // Character Stats
                            HP_Current_2.Invoke((MethodInvoker)(() => HP_Current_2.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.HP_Current)).ToString()));
                            HP_Total_2.Invoke((MethodInvoker)(() => HP_Total_2.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.HP_Max)).ToString()));
                            SP_Current_2.Invoke((MethodInvoker)(() => SP_Current_2.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.SP_Current)).ToString()));
                            SP_Total_2.Invoke((MethodInvoker)(() => SP_Total_2.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.SP_Total)).ToString()));

                            MP1_Current_2.Invoke((MethodInvoker)(() => MP1_Current_2.Text = Characters[Gap + stats.Magic1_Current].ToString()));
                            MP1_Total_2.Invoke((MethodInvoker)(() => MP1_Total_2.Text = Characters[Gap + stats.Magic1_Total].ToString()));
                            MP2_Current_2.Invoke((MethodInvoker)(() => MP2_Current_2.Text = Characters[Gap + stats.Magic2_Current].ToString()));
                            MP2_Total_2.Invoke((MethodInvoker)(() => MP2_Total_2.Text = Characters[Gap + stats.Magic2_Total].ToString()));
                            MP3_Current_2.Invoke((MethodInvoker)(() => MP3_Current_2.Text = Characters[Gap + stats.Magic3_Current].ToString()));
                            MP3_Total_2.Invoke((MethodInvoker)(() => MP3_Total_2.Text = Characters[Gap + stats.Magic3_Total].ToString()));


                            // Base Stats
                            STR_2.Invoke((MethodInvoker)(() => STR_2.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.STR)).ToString()));
                            VIT_2.Invoke((MethodInvoker)(() => VIT_2.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.VIT)).ToString()));
                            WIT_2.Invoke((MethodInvoker)(() => WIT_2.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.WIT)).ToString()));
                            AGI_2.Invoke((MethodInvoker)(() => AGI_2.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.AGI)).ToString()));

                            Level_2.Invoke((MethodInvoker)(() => Level_2.Text = Characters[Gap + stats.Level].ToString()));


                            // Levels
                            label_Fire_Level_2.Invoke((MethodInvoker)(() => label_Fire_Level_2.Text = Characters[Gap + stats.FireLevel].ToString()));
                            label_Wind_Level_2.Invoke((MethodInvoker)(() => label_Wind_Level_2.Text = Characters[Gap + stats.WindLevel].ToString()));
                            label_Water_Level_2.Invoke((MethodInvoker)(() => label_Water_Level_2.Text = Characters[Gap + stats.WaterLevel].ToString()));
                            label_Earth_Level_2.Invoke((MethodInvoker)(() => label_Earth_Level_2.Text = Characters[Gap + stats.EarthLevel].ToString()));

                            label_Weapon1_Level_2.Invoke((MethodInvoker)(() => label_Weapon1_Level_2.Text = Characters[Gap + stats.Weapon1Level].ToString()));
                            label_Weapon2_Level_2.Invoke((MethodInvoker)(() => label_Weapon2_Level_2.Text = Characters[Gap + stats.Weapon2Level].ToString()));
                            label_Weapon3_Level_2.Invoke((MethodInvoker)(() => label_Weapon3_Level_2.Text = Characters[Gap + stats.Weapon3Level].ToString()));


                            // EXP
                            var FireEXP = Characters[Gap + stats.FireEXP];
                            var WindEXP = Characters[Gap + stats.WindEXP];
                            var WaterEXP = Characters[Gap + stats.WaterEXP];
                            var EarthEXP = Characters[Gap + stats.EarthEXP];

                            var Weapon1EXP = Characters[Gap + stats.Weapon1EXP];
                            var Weapon2EXP = Characters[Gap + stats.Weapon2EXP];
                            var Weapon3EXP = Characters[Gap + stats.Weapon3EXP];

                            label_Fire_EXP_2.Invoke((MethodInvoker)(() => label_Fire_EXP_2.Text = FireEXP.ToString()));
                            label_Wind_EXP_2.Invoke((MethodInvoker)(() => label_Wind_EXP_2.Text = WindEXP.ToString()));
                            label_Water_EXP_2.Invoke((MethodInvoker)(() => label_Water_EXP_2.Text = WaterEXP.ToString()));
                            label_Earth_EXP_2.Invoke((MethodInvoker)(() => label_Earth_EXP_2.Text = EarthEXP.ToString()));

                            label_Weapon1_EXP_2.Invoke((MethodInvoker)(() => label_Weapon1_EXP_2.Text = Weapon1EXP.ToString()));
                            label_Weapon2_EXP_2.Invoke((MethodInvoker)(() => label_Weapon2_EXP_2.Text = Weapon2EXP.ToString()));
                            label_Weapon3_EXP_2.Invoke((MethodInvoker)(() => label_Weapon3_EXP_2.Text = Weapon3EXP.ToString()));

                            /// Progress Bars
                            Fire_EXP_Progressbar_2.Invoke((MethodInvoker)(() => Fire_EXP_Progressbar_2.Value = FireEXP));
                            Wind_EXP_Progressbar_2.Invoke((MethodInvoker)(() => Wind_EXP_Progressbar_2.Value = WindEXP));
                            Water_EXP_Progressbar_2.Invoke((MethodInvoker)(() => Water_EXP_Progressbar_2.Value = WaterEXP));
                            Earth_EXP_Progressbar_2.Invoke((MethodInvoker)(() => Earth_EXP_Progressbar_2.Value = EarthEXP));

                            Weapon1_EXP_Progressbar_2.Invoke((MethodInvoker)(() => Weapon1_EXP_Progressbar_2.Value = Weapon1EXP));
                            Weapon2_EXP_Progressbar_2.Invoke((MethodInvoker)(() => Weapon2_EXP_Progressbar_2.Value = Weapon2EXP));
                            Weapon3_EXP_Progressbar_2.Invoke((MethodInvoker)(() => Weapon3_EXP_Progressbar_2.Value = Weapon3EXP));
                        }
                        else if (i is 2)
                        {
                            // Character Stats
                            HP_Current_3.Invoke((MethodInvoker)(() => HP_Current_3.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.HP_Current)).ToString()));
                            HP_Total_3.Invoke((MethodInvoker)(() => HP_Total_3.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.HP_Max)).ToString()));
                            SP_Current_3.Invoke((MethodInvoker)(() => SP_Current_3.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.SP_Current)).ToString()));
                            SP_Total_3.Invoke((MethodInvoker)(() => SP_Total_3.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.SP_Total)).ToString()));

                            MP1_Current_3.Invoke((MethodInvoker)(() => MP1_Current_3.Text = Characters[Gap + stats.Magic1_Current].ToString()));
                            MP1_Total_3.Invoke((MethodInvoker)(() => MP1_Total_3.Text = Characters[Gap + stats.Magic1_Total].ToString()));
                            MP2_Current_3.Invoke((MethodInvoker)(() => MP2_Current_3.Text = Characters[Gap + stats.Magic2_Current].ToString()));
                            MP2_Total_3.Invoke((MethodInvoker)(() => MP2_Total_3.Text = Characters[Gap + stats.Magic2_Total].ToString()));
                            MP3_Current_3.Invoke((MethodInvoker)(() => MP3_Current_3.Text = Characters[Gap + stats.Magic3_Current].ToString()));
                            MP3_Total_3.Invoke((MethodInvoker)(() => MP3_Total_3.Text = Characters[Gap + stats.Magic3_Total].ToString()));


                            // Base Stats
                            STR_3.Invoke((MethodInvoker)(() => STR_3.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.STR)).ToString()));
                            VIT_3.Invoke((MethodInvoker)(() => VIT_3.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.VIT)).ToString()));
                            WIT_3.Invoke((MethodInvoker)(() => WIT_3.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.WIT)).ToString()));
                            AGI_3.Invoke((MethodInvoker)(() => AGI_3.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.AGI)).ToString()));

                            Level_3.Invoke((MethodInvoker)(() => Level_3.Text = Characters[Gap + stats.Level].ToString()));


                            // Levels
                            label_Fire_Level_3.Invoke((MethodInvoker)(() => label_Fire_Level_3.Text = Characters[Gap + stats.FireLevel].ToString()));
                            label_Wind_Level_3.Invoke((MethodInvoker)(() => label_Wind_Level_3.Text = Characters[Gap + stats.WindLevel].ToString()));
                            label_Water_Level_3.Invoke((MethodInvoker)(() => label_Water_Level_3.Text = Characters[Gap + stats.WaterLevel].ToString()));
                            label_Earth_Level_3.Invoke((MethodInvoker)(() => label_Earth_Level_3.Text = Characters[Gap + stats.EarthLevel].ToString()));

                            label_Weapon1_Level_3.Invoke((MethodInvoker)(() => label_Weapon1_Level_3.Text = Characters[Gap + stats.Weapon1Level].ToString()));
                            label_Weapon2_Level_3.Invoke((MethodInvoker)(() => label_Weapon2_Level_3.Text = Characters[Gap + stats.Weapon2Level].ToString()));
                            label_Weapon3_Level_3.Invoke((MethodInvoker)(() => label_Weapon3_Level_3.Text = Characters[Gap + stats.Weapon3Level].ToString()));


                            // EXP
                            var FireEXP = Characters[Gap + stats.FireEXP];
                            var WindEXP = Characters[Gap + stats.WindEXP];
                            var WaterEXP = Characters[Gap + stats.WaterEXP];
                            var EarthEXP = Characters[Gap + stats.EarthEXP];

                            var Weapon1EXP = Characters[Gap + stats.Weapon1EXP];
                            var Weapon2EXP = Characters[Gap + stats.Weapon2EXP];
                            var Weapon3EXP = Characters[Gap + stats.Weapon3EXP];

                            label_Fire_EXP_3.Invoke((MethodInvoker)(() => label_Fire_EXP_3.Text = FireEXP.ToString()));
                            label_Wind_EXP_3.Invoke((MethodInvoker)(() => label_Wind_EXP_3.Text = WindEXP.ToString()));
                            label_Water_EXP_3.Invoke((MethodInvoker)(() => label_Water_EXP_3.Text = WaterEXP.ToString()));
                            label_Earth_EXP_3.Invoke((MethodInvoker)(() => label_Earth_EXP_3.Text = EarthEXP.ToString()));

                            label_Weapon1_EXP_3.Invoke((MethodInvoker)(() => label_Weapon1_EXP_3.Text = Weapon1EXP.ToString()));
                            label_Weapon2_EXP_3.Invoke((MethodInvoker)(() => label_Weapon2_EXP_3.Text = Weapon2EXP.ToString()));
                            label_Weapon3_EXP_3.Invoke((MethodInvoker)(() => label_Weapon3_EXP_3.Text = Weapon3EXP.ToString()));

                            /// Progress Bars
                            Fire_EXP_Progressbar_3.Invoke((MethodInvoker)(() => Fire_EXP_Progressbar_3.Value = FireEXP));
                            Wind_EXP_Progressbar_3.Invoke((MethodInvoker)(() => Wind_EXP_Progressbar_3.Value = WindEXP));
                            Water_EXP_Progressbar_3.Invoke((MethodInvoker)(() => Water_EXP_Progressbar_3.Value = WaterEXP));
                            Earth_EXP_Progressbar_3.Invoke((MethodInvoker)(() => Earth_EXP_Progressbar_3.Value = EarthEXP));

                            Weapon1_EXP_Progressbar_3.Invoke((MethodInvoker)(() => Weapon1_EXP_Progressbar_3.Value = Weapon1EXP));
                            Weapon2_EXP_Progressbar_3.Invoke((MethodInvoker)(() => Weapon2_EXP_Progressbar_3.Value = Weapon2EXP));
                            Weapon3_EXP_Progressbar_3.Invoke((MethodInvoker)(() => Weapon3_EXP_Progressbar_3.Value = Weapon3EXP));
                        }
                        else if (i is 3)
                        {
                            // Character Stats
                            HP_Current_4.Invoke((MethodInvoker)(() => HP_Current_4.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.HP_Current)).ToString()));
                            HP_Total_4.Invoke((MethodInvoker)(() => HP_Total_4.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.HP_Max)).ToString()));
                            SP_Current_4.Invoke((MethodInvoker)(() => SP_Current_4.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.SP_Current)).ToString()));
                            SP_Total_4.Invoke((MethodInvoker)(() => SP_Total_4.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.SP_Total)).ToString()));

                            MP1_Current_4.Invoke((MethodInvoker)(() => MP1_Current_4.Text = Characters[Gap + stats.Magic1_Current].ToString()));
                            MP1_Total_4.Invoke((MethodInvoker)(() => MP1_Total_4.Text = Characters[Gap + stats.Magic1_Total].ToString()));
                            MP2_Current_4.Invoke((MethodInvoker)(() => MP2_Current_4.Text = Characters[Gap + stats.Magic2_Current].ToString()));
                            MP2_Total_4.Invoke((MethodInvoker)(() => MP2_Total_4.Text = Characters[Gap + stats.Magic2_Total].ToString()));
                            MP3_Current_4.Invoke((MethodInvoker)(() => MP3_Current_4.Text = Characters[Gap + stats.Magic3_Current].ToString()));
                            MP3_Total_4.Invoke((MethodInvoker)(() => MP3_Total_4.Text = Characters[Gap + stats.Magic3_Total].ToString()));


                            // Base Stats
                            STR_4.Invoke((MethodInvoker)(() => STR_4.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.STR)).ToString()));
                            VIT_4.Invoke((MethodInvoker)(() => VIT_4.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.VIT)).ToString()));
                            WIT_4.Invoke((MethodInvoker)(() => WIT_4.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.WIT)).ToString()));
                            AGI_4.Invoke((MethodInvoker)(() => AGI_4.Text = BitConverter.ToInt16(Characters, (int)(Gap + stats.AGI)).ToString()));

                            Level_4.Invoke((MethodInvoker)(() => Level_4.Text = Characters[Gap + stats.Level].ToString()));


                            // Levels
                            label_Fire_Level_4.Invoke((MethodInvoker)(() => label_Fire_Level_4.Text = Characters[Gap + stats.FireLevel].ToString()));
                            label_Wind_Level_4.Invoke((MethodInvoker)(() => label_Wind_Level_4.Text = Characters[Gap + stats.WindLevel].ToString()));
                            label_Water_Level_4.Invoke((MethodInvoker)(() => label_Water_Level_4.Text = Characters[Gap + stats.WaterLevel].ToString()));
                            label_Earth_Level_4.Invoke((MethodInvoker)(() => label_Earth_Level_4.Text = Characters[Gap + stats.EarthLevel].ToString()));

                            label_Weapon1_Level_4.Invoke((MethodInvoker)(() => label_Weapon1_Level_4.Text = Characters[Gap + stats.Weapon1Level].ToString()));
                            label_Weapon2_Level_4.Invoke((MethodInvoker)(() => label_Weapon2_Level_4.Text = Characters[Gap + stats.Weapon2Level].ToString()));
                            label_Weapon3_Level_4.Invoke((MethodInvoker)(() => label_Weapon3_Level_4.Text = Characters[Gap + stats.Weapon3Level].ToString()));


                            // EXP
                            var FireEXP = Characters[Gap + stats.FireEXP];
                            var WindEXP = Characters[Gap + stats.WindEXP];
                            var WaterEXP = Characters[Gap + stats.WaterEXP];
                            var EarthEXP = Characters[Gap + stats.EarthEXP];

                            var Weapon1EXP = Characters[Gap + stats.Weapon1EXP];
                            var Weapon2EXP = Characters[Gap + stats.Weapon2EXP];
                            var Weapon3EXP = Characters[Gap + stats.Weapon3EXP];

                            label_Fire_EXP_4.Invoke((MethodInvoker)(() => label_Fire_EXP_4.Text = FireEXP.ToString()));
                            label_Wind_EXP_4.Invoke((MethodInvoker)(() => label_Wind_EXP_4.Text = WindEXP.ToString()));
                            label_Water_EXP_4.Invoke((MethodInvoker)(() => label_Water_EXP_4.Text = WaterEXP.ToString()));
                            label_Earth_EXP_4.Invoke((MethodInvoker)(() => label_Earth_EXP_4.Text = EarthEXP.ToString()));

                            label_Weapon1_EXP_4.Invoke((MethodInvoker)(() => label_Weapon1_EXP_4.Text = Weapon1EXP.ToString()));
                            label_Weapon2_EXP_4.Invoke((MethodInvoker)(() => label_Weapon2_EXP_4.Text = Weapon2EXP.ToString()));
                            label_Weapon3_EXP_4.Invoke((MethodInvoker)(() => label_Weapon3_EXP_4.Text = Weapon3EXP.ToString()));

                            /// Progress Bars
                            Fire_EXP_Progressbar_4.Invoke((MethodInvoker)(() => Fire_EXP_Progressbar_4.Value = FireEXP));
                            Wind_EXP_Progressbar_4.Invoke((MethodInvoker)(() => Wind_EXP_Progressbar_4.Value = WindEXP));
                            Water_EXP_Progressbar_4.Invoke((MethodInvoker)(() => Water_EXP_Progressbar_4.Value = WaterEXP));
                            Earth_EXP_Progressbar_4.Invoke((MethodInvoker)(() => Earth_EXP_Progressbar_4.Value = EarthEXP));

                            Weapon1_EXP_Progressbar_4.Invoke((MethodInvoker)(() => Weapon1_EXP_Progressbar_4.Value = Weapon1EXP));
                            Weapon2_EXP_Progressbar_4.Invoke((MethodInvoker)(() => Weapon2_EXP_Progressbar_4.Value = Weapon2EXP));
                            Weapon3_EXP_Progressbar_4.Invoke((MethodInvoker)(() => Weapon3_EXP_Progressbar_4.Value = Weapon3EXP));
                        }
                    }
                    Thread.Sleep(RefreshTime);
                }
                catch { }
            }

            Start.Invoke((MethodInvoker)(() => Start.Enabled = true));
            AllowExitLoop = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("grandia").Length < 1)
            {
                MessageBox.Show("Grandia was not found! please start Grandia 1 first and make sure you started this Program with Admin Privileges!");
                return;
            }
            Start.Enabled = false;
            Stop.Enabled = true;
            new Thread(MemoryWatcher).Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stop.Enabled = false;
            Start.Enabled = true;
            AllowExitLoop = false;
        }
    }
}