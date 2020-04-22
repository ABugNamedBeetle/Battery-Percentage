namespace BatteryPercentage
{
    partial class setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(setting));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lowbatValue = new System.Windows.Forms.TextBox();
            this.alertValue = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.settingChanged = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Low Battery Level";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.settingChanged);
            this.groupBox1.Controls.Add(this.lowbatValue);
            this.groupBox1.Controls.Add(this.alertValue);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 118);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // lowbatValue
            // 
            this.lowbatValue.Location = new System.Drawing.Point(139, 29);
            this.lowbatValue.Name = "lowbatValue";
            this.lowbatValue.Size = new System.Drawing.Size(39, 20);
            this.lowbatValue.TabIndex = 3;
            this.lowbatValue.TextChanged += new System.EventHandler(this.lowbatValue_TextChanged);
            // 
            // alertValue
            // 
            this.alertValue.AutoSize = true;
            this.alertValue.Location = new System.Drawing.Point(139, 64);
            this.alertValue.Name = "alertValue";
            this.alertValue.Size = new System.Drawing.Size(15, 14);
            this.alertValue.TabIndex = 2;
            this.alertValue.UseVisualStyleBackColor = true;
            this.alertValue.CheckedChanged += new System.EventHandler(this.alertValue_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Low Battery Alert";
            // 
            // settingChanged
            // 
            this.settingChanged.Location = new System.Drawing.Point(205, 89);
            this.settingChanged.Name = "settingChanged";
            this.settingChanged.Size = new System.Drawing.Size(49, 23);
            this.settingChanged.TabIndex = 4;
            this.settingChanged.Text = "OK";
            this.settingChanged.UseVisualStyleBackColor = true;
            this.settingChanged.Click += new System.EventHandler(this.settingChanged_Click);
            // 
            // setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 142);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "setting";
            this.Text = "Setting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox lowbatValue;
        public System.Windows.Forms.CheckBox alertValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button settingChanged;


    }
}