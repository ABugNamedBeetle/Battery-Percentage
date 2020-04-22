using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BatteryPercentage
{
    class NotifIcon
    {
        Bitmap bmp = null ;
        private string batteryPercentage = null;
        private NotifyIcon notifyIcon =new NotifyIcon();
        Timer timer = new Timer();
        setting settingForm = new setting();
        INI setINI = new INI("Settings.ini");
       static String LBL = null; // low battery level
        static bool alertValue = false;

        
        public NotifIcon()
        {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem itemExit = new MenuItem();
            MenuItem itemSetting = new MenuItem();
    

            // initialize contextMenu
            contextMenu.MenuItems.AddRange(new MenuItem[] { itemExit,itemSetting });

            // initialize menuItem
            itemSetting.Index = 0;
            itemSetting.Text = "Setting";
            itemSetting.Click += new System.EventHandler(itemSetting_Click);
           
            itemExit.Index = 1;
            itemExit.Text = "E&xit";
            itemExit.Click += new System.EventHandler(itemExit_Click);
            
            notifyIcon.ContextMenu = contextMenu;
            notifyIcon.Visible = true;

            
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000; // in miliseconds
            timer.Start();
            loadSetting();
            
        }
        private void loadSetting ()
        {
            LBL =         setINI.Read("LowBatteryLevel");
            alertValue = (setINI.Read("LowBatteryAlert")=="False")?false:true;


        }
        public static void setSetting(string lbl , bool lba)
        {
            LBL = lbl;
            alertValue = lba; 
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            PowerStatus powerStatus = SystemInformation.PowerStatus;
            batteryPercentage = (powerStatus.BatteryLifePercent * 100).ToString();
            if (powerStatus.BatteryLifePercent != 1)
            {

                //Bitmap bmp = new Bitmap(@"D:/green.png");
                bmp = new Bitmap(16, 16);
                RectangleF rectf = new RectangleF(0, 0, 16, 16);
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                StringFormat format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                };

                // Draw the text onto the image
                g.DrawString(batteryPercentage, new Font("Calibra", 8), Brushes.White, rectf, format);

                // Flush all graphics changes to the bitmap
                g.Flush();
                
            }
            else
            {
                bmp = Properties.Resources.Full;
                
            }
           
            using (bmp)
            {


                IntPtr bmpPtr = bmp.GetHicon();
                try
                {
                    using (Icon icon = Icon.FromHandle(bmpPtr))
                    {
                        notifyIcon.Icon = icon;
                        notifyIcon.Text = batteryPercentage + "%";
                    }
                }
                finally
                {
                    DestroyIcon(bmpPtr);
                }
                        
                
            }
            if (powerStatus.BatteryLifePercent * 100f < Convert.ToInt32(LBL) && alertValue && powerStatus.PowerLineStatus.Equals(PowerLineStatus.Offline))
            {
                using (var soundPlayer = new System.Media.SoundPlayer(Properties.Resources.Beep))
                {
                    float temp = powerStatus.BatteryLifePercent * 100f * (80f) / Convert.ToInt32(LBL) + 20f;
                    timer.Interval = (int)(temp * 10);
                    soundPlayer.Play();
                }

            }
            else
            {
                
                timer.Interval = 1000;  // return back to original frequency
            }

            
        }

        
        private void itemExit_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            bmp.Dispose();
            Application.Exit();
        }
        private void itemSetting_Click(object sender, EventArgs e)
        {
            setting settingForm = new setting();
            settingForm.Show();
            
          
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);
        
       
    }


}  

           
        


        

