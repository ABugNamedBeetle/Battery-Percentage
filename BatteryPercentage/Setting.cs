using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatteryPercentage
{
    public partial class setting : Form
    {
        INI setINI = new INI("Settings.ini");
        public setting()
        {
            InitializeComponent();
            lowbatValue.Text = setINI.Read("LowBatteryLevel");
            alertValue.Checked = (setINI.Read("LowBatteryAlert") == "False") ? false : true;
        }

        

        private void lowbatValue_TextChanged(object sender, EventArgs e)
        {
            setINI.Write("LowBatteryLevel", lowbatValue.Text);

        }

        private void alertValue_CheckedChanged(object sender, EventArgs e)
        {
            setINI.Write("LowBatteryAlert", alertValue.Checked.ToString());
        }

        private void settingChanged_Click(object sender, EventArgs e)
        {
            NotifIcon.setSetting(lowbatValue.Text, alertValue.Checked);
            this.Hide();
        }
    }
}
