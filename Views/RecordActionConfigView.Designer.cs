namespace PW.MacroDeck.SoundPad.Views
{
    partial class RecordActionConfigView
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
            this.labelRecordingDevice = new System.Windows.Forms.Label();
            this.deviceSelection = new SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox();
            this.SuspendLayout();
            // 
            // labelRecordingDevice
            // 
            this.labelRecordingDevice.AutoSize = true;
            this.labelRecordingDevice.Location = new System.Drawing.Point(62, 47);
            this.labelRecordingDevice.Name = "labelRecordingDevice";
            this.labelRecordingDevice.Size = new System.Drawing.Size(154, 23);
            this.labelRecordingDevice.TabIndex = 0;
            this.labelRecordingDevice.Text = "Recording device";
            this.labelRecordingDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deviceSelection
            // 
            this.deviceSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.deviceSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceSelection.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deviceSelection.Icon = null;
            this.deviceSelection.Location = new System.Drawing.Point(254, 45);
            this.deviceSelection.Name = "deviceSelection";
            this.deviceSelection.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.deviceSelection.SelectedIndex = -1;
            this.deviceSelection.SelectedItem = null;
            this.deviceSelection.Size = new System.Drawing.Size(276, 26);
            this.deviceSelection.TabIndex = 2;
            this.deviceSelection.SelectedIndexChanged += new System.EventHandler(this.DeviceSelection_SelectedIndexChanged);
            // 
            // RecordActionConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deviceSelection);
            this.Controls.Add(this.labelRecordingDevice);
            this.Name = "RecordActionConfigView";
            this.Load += new System.EventHandler(this.PlayActionConfigView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRecordingDevice;
        private SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox deviceSelection;
    }
}