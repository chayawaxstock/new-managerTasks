using System;
using System.Windows.Forms;


namespace manageTask
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Main main = new Main();
            main.Visible=false; 
            Application.Run(main);

        }
    }
}
