using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatteryPercentage
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()

        {
            const string appName = "BatteryPercentage";
            bool isAnotherInstanceOpen;
            var mutex = new System.Threading.Mutex(true, appName, out isAnotherInstanceOpen);

            if (!isAnotherInstanceOpen)
            {
                //app is already running! Exiting the application  
                string message = "Only one instance of this app is allowed (App already running).";
                string title = "BatteryPercentage";
               
                MessageBox.Show(message, title);  
                return;
            } 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NotifIcon trayIcon = new NotifIcon();
            Application.Run();
        }
    }
}
