namespace PoolOne
{
    partial class GameScreen
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
            this.components = new System.ComponentModel.Container();
            this.clothPlaceHolderLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // clothPlaceHolderLabel
            // 
            this.clothPlaceHolderLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.clothPlaceHolderLabel.Location = new System.Drawing.Point(30, 30);
            this.clothPlaceHolderLabel.Name = "clothPlaceHolderLabel";
            this.clothPlaceHolderLabel.Size = new System.Drawing.Size(740, 440);
            this.clothPlaceHolderLabel.TabIndex = 0;
            this.clothPlaceHolderLabel.Text = "clothPlaceHolderLabel";
            this.clothPlaceHolderLabel.Visible = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 80;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.Controls.Add(this.clothPlaceHolderLabel);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(800, 500);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label clothPlaceHolderLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer timer1;
    }
}
