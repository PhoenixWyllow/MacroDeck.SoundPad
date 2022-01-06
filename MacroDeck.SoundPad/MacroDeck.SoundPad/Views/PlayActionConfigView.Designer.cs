namespace PW.MacroDeck.SoundPad.Views
{
    partial class PlayActionConfigView
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
            this.audioIndexLabel = new System.Windows.Forms.Label();
            this.audioIndex = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.audioIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // audioIndexLabel
            // 
            this.audioIndexLabel.AutoSize = true;
            this.audioIndexLabel.Location = new System.Drawing.Point(62, 47);
            this.audioIndexLabel.Name = "audioIndexLabel";
            this.audioIndexLabel.Size = new System.Drawing.Size(108, 23);
            this.audioIndexLabel.TabIndex = 0;
            this.audioIndexLabel.Text = "Audio index";
            this.audioIndexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // audioIndex
            // 
            this.audioIndex.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.audioIndex.Location = new System.Drawing.Point(176, 45);
            this.audioIndex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.audioIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.audioIndex.Name = "audioIndex";
            this.audioIndex.Size = new System.Drawing.Size(68, 27);
            this.audioIndex.TabIndex = 1;
            this.audioIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.audioIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.audioIndex.ValueChanged += new System.EventHandler(this.AudioIndex_ValueChanged);
            // 
            // PlayActionConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.audioIndex);
            this.Controls.Add(this.audioIndexLabel);
            this.Name = "PlayActionConfigView";
            this.Load += new System.EventHandler(this.PlayActionConfigView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.audioIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label audioIndexLabel;
        private System.Windows.Forms.NumericUpDown audioIndex;
    }
}