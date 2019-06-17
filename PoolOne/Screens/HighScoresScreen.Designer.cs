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
            this.fakeButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backToMenuButton
            // 
            this.backToMenuButton.BackColor = System.Drawing.Color.White;
            this.backToMenuButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.backToMenuButton.FlatAppearance.BorderSize = 0;
            this.backToMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backToMenuButton.Font = new System.Drawing.Font("Impact", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backToMenuButton.ForeColor = System.Drawing.Color.Black;
            this.backToMenuButton.Location = new System.Drawing.Point(377, 329);
            this.backToMenuButton.Margin = new System.Windows.Forms.Padding(4);
            this.backToMenuButton.Name = "backToMenuButton";
            this.backToMenuButton.Size = new System.Drawing.Size(261, 57);
            this.backToMenuButton.TabIndex = 0;
            this.backToMenuButton.Text = "BACK TO MENU";
            this.backToMenuButton.UseVisualStyleBackColor = false;
            this.backToMenuButton.Click += new System.EventHandler(this.backToMenuButton_Click);
            this.backToMenuButton.Enter += new System.EventHandler(this.backToMenuButton_Enter);
            this.backToMenuButton.Leave += new System.EventHandler(this.backToMenuButton_Leave);
            // 
            // fakeButton
            // 
            this.fakeButton.BackColor = System.Drawing.Color.Transparent;
            this.fakeButton.Enabled = false;
            this.fakeButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.fakeButton.FlatAppearance.BorderSize = 0;
            this.fakeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fakeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fakeButton.ForeColor = System.Drawing.Color.Black;
            this.fakeButton.Location = new System.Drawing.Point(0, 0);
            this.fakeButton.Margin = new System.Windows.Forms.Padding(4);
            this.fakeButton.Name = "fakeButton";
            this.fakeButton.Size = new System.Drawing.Size(215, 57);
            this.fakeButton.TabIndex = 1;
            this.fakeButton.UseVisualStyleBackColor = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.titleLabel.Location = new System.Drawing.Point(46, 45);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(531, 98);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "HIGHSCOOORES";
            // 
            // HighScoresScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.fakeButton);
            this.Controls.Add(this.backToMenuButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HighScoresScreen";
            this.Size = new System.Drawing.Size(668, 404);
            this.Load += new System.EventHandler(this.HighScoresScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HighScoresScreen_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backToMenuButton;
        private System.Windows.Forms.Button fakeButton;
        private System.Windows.Forms.Label titleLabel;
    }
}
