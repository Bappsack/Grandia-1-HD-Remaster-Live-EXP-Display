using Grandia_HD_Remaster_Live_EXP_Display;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grandia_1_HD_Remaster_Live_EXP_Display
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_Close;
        }

        private void Form1_Close(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Grandia1_Start_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("grandia").Length < 1)
            {
                MessageBox.Show(null, "Grandia was not found! please start Grandia first and make sure you started this Program with Admin Privileges!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Program.Grandia1_Running)
            {
                Grandia1_Start.Text = "Stop Reading";
                Program.Grandia1_Running = !Program.Grandia1_Running;
                new Thread(Grandia1_Worker.Loop).Start();
            }
            else
            {
                Grandia1_Start.Text = "Start Reading";
                Program.Grandia1_Running = !Program.Grandia1_Running;
            }
        }

        private void Grandia2_Start_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("grandia2").Length < 1)
            {
                MessageBox.Show(null, "Grandia 2 was not found! please start Grandia 2 first and make sure you started this Program with Admin Privileges!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Program.Grandia2_Running)
            {
                Grandia2_Start.Text = "Stop Reading";
                Program.Grandia2_Running = !Program.Grandia2_Running;
                new Thread(Grandia2_Worker.Loop).Start();
            }
            else
            {
                Grandia2_Start.Text = "Start Reading";
                Program.Grandia2_Running = !Program.Grandia2_Running;
            }
        }

        #region GUI_Changes
        public async Task Update_Grandia1_Stats(List<Structures.Grandia1.Character> characters)
        {
            Invoke(new MethodInvoker(delegate
            {
                for (int i = 0; i < characters.Count; i++)
                {
                    int controlid = (i + 1);

                    /// Base Stats
                    Controls.Find($"STR_{controlid}", true).FirstOrDefault().Text = characters[i].STR.ToString();
                    Controls.Find($"VIT_{controlid}", true).FirstOrDefault().Text = characters[i].VIT.ToString();
                    Controls.Find($"WIT_{controlid}", true).FirstOrDefault().Text = characters[i].WIT.ToString();
                    Controls.Find($"AGI_{controlid}", true).FirstOrDefault().Text = characters[i].AGI.ToString();
                    Controls.Find($"Level_{controlid}", true).FirstOrDefault().Text = characters[i].Level.ToString();


                    /// Character Stats
                    Controls.Find($"Name_{controlid}", true).FirstOrDefault().Text = characters[i].Name.ToString();

                    Controls.Find($"EXP_Current_{controlid}", true).FirstOrDefault().Text = characters[i].Current_EXP.ToString();
                    Controls.Find($"EXP_Total_{controlid}", true).FirstOrDefault().Text = characters[i].Total_EXP.ToString();

                    Controls.Find($"HP_Current_{controlid}", true).FirstOrDefault().Text = characters[i].HP_Current.ToString();
                    Controls.Find($"HP_Total_{controlid}", true).FirstOrDefault().Text = characters[i].HP_Max.ToString();

                    Controls.Find($"SP_Current_{controlid}", true).FirstOrDefault().Text = characters[i].SP_Current.ToString();
                    Controls.Find($"SP_Total_{controlid}", true).FirstOrDefault().Text = characters[i].SP_Total.ToString();

                    Controls.Find($"MP1_Current_{controlid}", true).FirstOrDefault().Text = characters[i].Magic1_Current.ToString();
                    Controls.Find($"MP1_Total_{controlid}", true).FirstOrDefault().Text = characters[i].Magic1_Total.ToString();

                    Controls.Find($"MP2_Current_{controlid}", true).FirstOrDefault().Text = characters[i].Magic2_Current.ToString();
                    Controls.Find($"MP2_Total_{controlid}", true).FirstOrDefault().Text = characters[i].Magic2_Total.ToString();

                    Controls.Find($"MP3_Current_{controlid}", true).FirstOrDefault().Text = characters[i].Magic3_Current.ToString();
                    Controls.Find($"MP3_Total_{controlid}", true).FirstOrDefault().Text = characters[i].Magic3_Total.ToString();


                    // Levels
                    Controls.Find($"label_Fire_Level_{controlid}", true).FirstOrDefault().Text = characters[i].FireLevel.ToString();
                    Controls.Find($"label_Wind_Level_{controlid}", true).FirstOrDefault().Text = characters[i].WindLevel.ToString();
                    Controls.Find($"label_Water_Level_{controlid}", true).FirstOrDefault().Text = characters[i].WaterLevel.ToString();
                    Controls.Find($"label_Earth_Level_{controlid}", true).FirstOrDefault().Text = characters[i].EarthLevel.ToString();

                    Controls.Find($"label_Weapon1_Level_{controlid}", true).FirstOrDefault().Text = characters[i].Weapon1Level.ToString();
                    Controls.Find($"label_Weapon2_Level_{controlid}", true).FirstOrDefault().Text = characters[i].Weapon2Level.ToString();
                    Controls.Find($"label_Weapon3_Level_{controlid}", true).FirstOrDefault().Text = characters[i].Weapon3Level.ToString();


                    /// EXP
                    Controls.Find($"label_Fire_EXP_{controlid}", true).FirstOrDefault().Text = characters[i].FireEXP.ToString();
                    Controls.Find($"label_Wind_EXP_{controlid}", true).FirstOrDefault().Text = characters[i].WindEXP.ToString();
                    Controls.Find($"label_Water_EXP_{controlid}", true).FirstOrDefault().Text = characters[i].WaterEXP.ToString();
                    Controls.Find($"label_Earth_EXP_{controlid}", true).FirstOrDefault().Text = characters[i].EarthEXP.ToString();

                    Controls.Find($"label_Weapon1_EXP_{controlid}", true).FirstOrDefault().Text = characters[i].Weapon1EXP.ToString();
                    Controls.Find($"label_Weapon2_EXP_{controlid}", true).FirstOrDefault().Text = characters[i].Weapon2EXP.ToString();
                    Controls.Find($"label_Weapon3_EXP_{controlid}", true).FirstOrDefault().Text = characters[i].Weapon3EXP.ToString();


                    /// Progress Bars
                    (Controls.Find($"Fire_EXP_Progressbar_{controlid}", true).FirstOrDefault() as ProgressBar).Value = characters[i].FireEXP > 100 ? 100 : characters[i].FireEXP;
                    (Controls.Find($"Wind_EXP_Progressbar_{controlid}", true).FirstOrDefault() as ProgressBar).Value = characters[i].WindEXP > 100 ? 100 : characters[i].WindEXP;
                    (Controls.Find($"Water_EXP_Progressbar_{controlid}", true).FirstOrDefault() as ProgressBar).Value = characters[i].WaterEXP > 100 ? 100 : characters[i].WaterEXP;
                    (Controls.Find($"Earth_EXP_Progressbar_{controlid}", true).FirstOrDefault() as ProgressBar).Value = characters[i].EarthEXP > 100 ? 100 : characters[i].EarthEXP;

                    (Controls.Find($"Weapon1_EXP_Progressbar_{controlid}", true).FirstOrDefault() as ProgressBar).Value = characters[i].Weapon1EXP > 100 ? 100 : characters[i].Weapon1EXP;
                    (Controls.Find($"Weapon2_EXP_Progressbar_{controlid}", true).FirstOrDefault() as ProgressBar).Value = characters[i].Weapon2EXP > 100 ? 100 : characters[i].Weapon2EXP;
                    (Controls.Find($"Weapon3_EXP_Progressbar_{controlid}", true).FirstOrDefault() as ProgressBar).Value = characters[i].Weapon3EXP > 100 ? 100 : characters[i].Weapon3EXP;
                }
            }));
            await Task.Delay(Program.RefreshTime);
        }

        public async Task Update_Grandia2_Stats(Structures.Grandia2.BattleRewards battle_Rewards, List<Structures.Grandia2.Character> characters)
        {
            Invoke(new MethodInvoker(delegate
            {

                // Battle Rewards
                SP_Coins.Text = battle_Rewards.SP_Coins.ToString();
                SP_Coins_Total.Text = battle_Rewards.SP_Total.ToString();

                MP_Coins.Text = battle_Rewards.MP_Coins.ToString();
                MP_Coins_Total.Text = battle_Rewards.MP_Total.ToString();

                Gold.Text = battle_Rewards.Gold.ToString();
                Gold_Total.Text = battle_Rewards.Gold_Total.ToString();

                EXP.Text = battle_Rewards.EXP.ToString();

                // Character Stats

                for (int i = 0; i < characters.Count; i++)
                {
                    int controlID = (i + 1);

                }

            }));
            await Task.Delay(Program.RefreshTime);
        }
        #endregion
    }
}