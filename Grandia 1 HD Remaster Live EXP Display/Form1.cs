using Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Grandia_1_HD_Remaster_Live_EXP_Display
{
    public partial class Form1 : Form
    {
        private static bool AllowExitLoop = true;

        public Form1()
        {
            InitializeComponent();
            button3.Enabled = false;

            this.FormClosing += Form1_Close;
        }

        private void Form1_Close(object sender, FormClosingEventArgs e)
        {
            AllowExitLoop = true;
            Environment.Exit(0);
        }

        private void MemoryWatcher()
        {
            var memory = new Mem();
            memory.OpenProcess("grandia");

            Thread.Sleep(100);
            while (AllowExitLoop)
            {
                try
                {
                    byte[] Characters = memory.ReadBytes(GameOffsets.P1_Fight_Status, 2000);
                    int RefreshTime = 100;

                    textBox1.Invoke((MethodInvoker)(() => int.TryParse(textBox1.Text, out RefreshTime)));

                    var stats = new CharacterOffsets.CharacterStats();

                    if (Characters is null)
                    {
                        MessageBox.Show("Unable to read Data!\n\n Make sure you were in a Battle atleast once!");
                        button1.Invoke((MethodInvoker)(() => button1.Enabled = true));
                        AllowExitLoop = false;
                        return;
                    }
                    var chars = new List<CharacterOffsets.CharacterStats>();

                    for (int i = 0; i < 4; i++)
                    {
                        if (i is 0)
                        {
                            // Levels
                            label_Fire_Level_1.Invoke((MethodInvoker)(() => label_Fire_Level_1.Text = Characters[(i * stats.SlotGap) + stats.FireLevel].ToString()));
                            label_Wind_Level_1.Invoke((MethodInvoker)(() => label_Wind_Level_1.Text = Characters[(i * stats.SlotGap) + stats.WindLevel].ToString()));
                            label_Water_Level_1.Invoke((MethodInvoker)(() => label_Water_Level_1.Text = Characters[(i * stats.SlotGap) + stats.WaterLevel].ToString()));
                            label_Earth_Level_1.Invoke((MethodInvoker)(() => label_Earth_Level_1.Text = Characters[(i * stats.SlotGap) + stats.EarthLevel].ToString()));

                            label_Weapon1_Level_1.Invoke((MethodInvoker)(() => label_Weapon1_Level_1.Text = Characters[(i * stats.SlotGap) + stats.Weapon1Level].ToString()));
                            label_Weapon2_Level_1.Invoke((MethodInvoker)(() => label_Weapon2_Level_1.Text = Characters[(i * stats.SlotGap) + stats.Weapon2Level].ToString()));
                            label_Weapon3_Level_1.Invoke((MethodInvoker)(() => label_Weapon3_Level_1.Text = Characters[(i * stats.SlotGap) + stats.Weapon3Level].ToString()));


                            // EXP
                            var FireEXP = Characters[(i * stats.SlotGap) + stats.FireEXP];
                            var WindEXP = Characters[(i * stats.SlotGap) + stats.WindEXP];
                            var WaterEXP = Characters[(i * stats.SlotGap) + stats.WaterEXP];
                            var EarthEXP = Characters[(i * stats.SlotGap) + stats.EarthEXP];

                            var Weapon1EXP = Characters[(i * stats.SlotGap) + stats.Weapon1EXP];
                            var Weapon2EXP = Characters[(i * stats.SlotGap) + stats.Weapon2EXP];
                            var Weapon3EXP = Characters[(i * stats.SlotGap) + stats.Weapon3EXP];

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
                            // Levels
                            label_Fire_Level_2.Invoke((MethodInvoker)(() => label_Fire_Level_2.Text = Characters[(i * stats.SlotGap) + stats.FireLevel].ToString()));
                            label_Wind_Level_2.Invoke((MethodInvoker)(() => label_Wind_Level_2.Text = Characters[(i * stats.SlotGap) + stats.WindLevel].ToString()));
                            label_Water_Level_2.Invoke((MethodInvoker)(() => label_Water_Level_2.Text = Characters[(i * stats.SlotGap) + stats.WaterLevel].ToString()));
                            label_Earth_Level_2.Invoke((MethodInvoker)(() => label_Earth_Level_2.Text = Characters[(i * stats.SlotGap) + stats.EarthLevel].ToString()));

                            label_Weapon1_Level_2.Invoke((MethodInvoker)(() => label_Weapon1_Level_2.Text = Characters[(i * stats.SlotGap) + stats.Weapon1Level].ToString()));
                            label_Weapon2_Level_2.Invoke((MethodInvoker)(() => label_Weapon2_Level_2.Text = Characters[(i * stats.SlotGap) + stats.Weapon2Level].ToString()));
                            label_Weapon3_Level_2.Invoke((MethodInvoker)(() => label_Weapon3_Level_2.Text = Characters[(i * stats.SlotGap) + stats.Weapon3Level].ToString()));


                            // EXP
                            var FireEXP = Characters[(i * stats.SlotGap) + stats.FireEXP];
                            var WindEXP = Characters[(i * stats.SlotGap) + stats.WindEXP];
                            var WaterEXP = Characters[(i * stats.SlotGap) + stats.WaterEXP];
                            var EarthEXP = Characters[(i * stats.SlotGap) + stats.EarthEXP];

                            var Weapon1EXP = Characters[(i * stats.SlotGap) + stats.Weapon1EXP];
                            var Weapon2EXP = Characters[(i * stats.SlotGap) + stats.Weapon2EXP];
                            var Weapon3EXP = Characters[(i * stats.SlotGap) + stats.Weapon3EXP];

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
                            // Levels
                            label_Fire_Level_3.Invoke((MethodInvoker)(() => label_Fire_Level_3.Text = Characters[(i * stats.SlotGap) + stats.FireLevel].ToString()));
                            label_Wind_Level_3.Invoke((MethodInvoker)(() => label_Wind_Level_3.Text = Characters[(i * stats.SlotGap) + stats.WindLevel].ToString()));
                            label_Water_Level_3.Invoke((MethodInvoker)(() => label_Water_Level_3.Text = Characters[(i * stats.SlotGap) + stats.WaterLevel].ToString()));
                            label_Earth_Level_3.Invoke((MethodInvoker)(() => label_Earth_Level_3.Text = Characters[(i * stats.SlotGap) + stats.EarthLevel].ToString()));

                            label_Weapon1_Level_3.Invoke((MethodInvoker)(() => label_Weapon1_Level_3.Text = Characters[(i * stats.SlotGap) + stats.Weapon1Level].ToString()));
                            label_Weapon2_Level_3.Invoke((MethodInvoker)(() => label_Weapon2_Level_3.Text = Characters[(i * stats.SlotGap) + stats.Weapon2Level].ToString()));
                            label_Weapon3_Level_3.Invoke((MethodInvoker)(() => label_Weapon3_Level_3.Text = Characters[(i * stats.SlotGap) + stats.Weapon3Level].ToString()));


                            // EXP
                            var FireEXP = Characters[(i * stats.SlotGap) + stats.FireEXP];
                            var WindEXP = Characters[(i * stats.SlotGap) + stats.WindEXP];
                            var WaterEXP = Characters[(i * stats.SlotGap) + stats.WaterEXP];
                            var EarthEXP = Characters[(i * stats.SlotGap) + stats.EarthEXP];

                            var Weapon1EXP = Characters[(i * stats.SlotGap) + stats.Weapon1EXP];
                            var Weapon2EXP = Characters[(i * stats.SlotGap) + stats.Weapon2EXP];
                            var Weapon3EXP = Characters[(i * stats.SlotGap) + stats.Weapon3EXP];

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
                            // Levels
                            label_Fire_Level_4.Invoke((MethodInvoker)(() => label_Fire_Level_4.Text = Characters[(i * stats.SlotGap) + stats.FireLevel].ToString()));
                            label_Wind_Level_4.Invoke((MethodInvoker)(() => label_Wind_Level_4.Text = Characters[(i * stats.SlotGap) + stats.WindLevel].ToString()));
                            label_Water_Level_4.Invoke((MethodInvoker)(() => label_Water_Level_4.Text = Characters[(i * stats.SlotGap) + stats.WaterLevel].ToString()));
                            label_Earth_Level_4.Invoke((MethodInvoker)(() => label_Earth_Level_4.Text = Characters[(i * stats.SlotGap) + stats.EarthLevel].ToString()));

                            label_Weapon1_Level_4.Invoke((MethodInvoker)(() => label_Weapon1_Level_4.Text = Characters[(i * stats.SlotGap) + stats.Weapon1Level].ToString()));
                            label_Weapon2_Level_4.Invoke((MethodInvoker)(() => label_Weapon2_Level_4.Text = Characters[(i * stats.SlotGap) + stats.Weapon2Level].ToString()));
                            label_Weapon3_Level_4.Invoke((MethodInvoker)(() => label_Weapon3_Level_4.Text = Characters[(i * stats.SlotGap) + stats.Weapon3Level].ToString()));


                            // EXP
                            var FireEXP = Characters[(i * stats.SlotGap) + stats.FireEXP];
                            var WindEXP = Characters[(i * stats.SlotGap) + stats.WindEXP];
                            var WaterEXP = Characters[(i * stats.SlotGap) + stats.WaterEXP];
                            var EarthEXP = Characters[(i * stats.SlotGap) + stats.EarthEXP];

                            var Weapon1EXP = Characters[(i * stats.SlotGap) + stats.Weapon1EXP];
                            var Weapon2EXP = Characters[(i * stats.SlotGap) + stats.Weapon2EXP];
                            var Weapon3EXP = Characters[(i * stats.SlotGap) + stats.Weapon3EXP];

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

            button1.Invoke((MethodInvoker)(() => button1.Enabled = true));
            AllowExitLoop = false;
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
            button1.Enabled = false;
            button3.Enabled = true;
            new Thread(MemoryWatcher).Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            AllowExitLoop = true;
            button3.Enabled = false;
        }
    }
}
