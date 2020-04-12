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
        Bitmap bmp ;
        private string batteryPercentage = null;
        private NotifyIcon notifyIcon =new NotifyIcon();
        
        public NotifIcon()
        {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItem = new MenuItem();

    

            // initialize contextMenu
            contextMenu.MenuItems.AddRange(new MenuItem[] { menuItem });

            // initialize menuItem
            menuItem.Index = 0;
            menuItem.Text = "E&xit";
            menuItem.Click += new System.EventHandler(menuItem_Click);

            notifyIcon.ContextMenu = contextMenu;
            notifyIcon.Visible = true;

            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000; // in miliseconds
            timer.Start();
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
                g.Dispose();
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
                    bmpPtr = IntPtr.Zero;
                }
            }
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            bmp.Dispose();
            Application.Exit();
        }

       
    }
}  

           
        


        

