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
            this.labelCategory = new System.Windows.Forms.Label();
            this.categoryNames = new System.Windows.Forms.ComboBox();
            this.audioTitles = new System.Windows.Forms.ComboBox();
            this.labelSoundTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(62, 47);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(84, 23);
            this.labelCategory.TabIndex = 0;
            this.labelCategory.Text = "Category";
            this.labelCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // categoryNames
            // 
            this.categoryNames.FormattingEnabled = true;
            this.categoryNames.Location = new System.Drawing.Point(205, 44);
            this.categoryNames.Name = "categoryNames";
            this.categoryNames.Size = new System.Drawing.Size(276, 31);
            this.categoryNames.TabIndex = 2;
            this.categoryNames.SelectedIndexChanged += new System.EventHandler(this.CategoryNames_SelectedIndexChanged);
            // 
            // audioTitles
            // 
            this.audioTitles.FormattingEnabled = true;
            this.audioTitles.Location = new System.Drawing.Point(205, 81);
            this.audioTitles.Name = "audioTitles";
            this.audioTitles.Size = new System.Drawing.Size(276, 31);
            this.audioTitles.TabIndex = 3;
            this.audioTitles.SelectedIndexChanged += new System.EventHandler(this.AudioTitles_SelectedIndexChanged);
            // 
            // labelSoundTitle
            // 
            this.labelSoundTitle.AutoSize = true;
            this.labelSoundTitle.Location = new System.Drawing.Point(62, 84);
            this.labelSoundTitle.Name = "labelSoundTitle";
            this.labelSoundTitle.Size = new System.Drawing.Size(105, 23);
            this.labelSoundTitle.TabIndex = 5;
            this.labelSoundTitle.Text = "Sound Title";
            this.labelSoundTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayActionConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSoundTitle);
            this.Controls.Add(this.audioTitles);
            this.Controls.Add(this.categoryNames);
            this.Controls.Add(this.labelCategory);
            this.Name = "PlayActionConfigView";
            this.Load += new System.EventHandler(this.PlayActionConfigView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.ComboBox categoryNames;
        private System.Windows.Forms.ComboBox audioTitles;
        private System.Windows.Forms.Label labelSoundTitle;
    }
}