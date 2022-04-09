using System;
using System.Windows.Forms;

namespace Grandia_1_HD_Remaster_Live_EXP_Display
{
    public static class Program
    {
        public static int RefreshTime { get; set; } = 100;
        public static bool Grandia1_Running { get; set; } = false;
        public static bool Grandia2_Running { get; set; } = false;

        public static Form1 Form { get; private set; }

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form = new Form1();
            Application.Run(Form);
        }
    }
}
