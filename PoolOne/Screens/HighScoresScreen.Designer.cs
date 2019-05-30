namespace PoolOne
{
    partial class HighScoresScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backToMenuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backToMenuButton
            // 
            this.backToMenuButton.Location = new System.Drawing.Point(515, 320);
            this.backToMenuButton.Margin = new System.Windows.Forms.Padding(4);
            this.backToMenuButton.Name = "backToMenuButton";
            this.backToMenuButton.Size = new System.Drawing.Size(140, 28);
            this.backToMenuButton.TabIndex = 0;
            this.backToMenuButton.Text = "Back to menu";
            this.backToMenuButton.UseVisualStyleBackColor = true;
            this.backToMenuButton.Click += new System.EventHandler(this.backToMenuButton_Click);
            // 
            // HighScoresScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.backToMenuButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HighScoresScreen";
            this.Size = new System.Drawing.Size(668, 404);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backToMenuButton;
    }
}
