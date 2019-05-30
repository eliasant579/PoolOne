﻿namespace PoolOne
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
            this.singlePalyerTimer = new System.Windows.Forms.Timer(this.components);
            this.twoPlayersTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // singlePalyerTimer
            // 
            this.singlePalyerTimer.Interval = 80;
            this.singlePalyerTimer.Tick += new System.EventHandler(this.singlePlayerTimer_Tick);
            // 
            // twoPlayersTimer
            // 
            this.twoPlayersTimer.Interval = 80;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(800, 500);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer singlePalyerTimer;
        private System.Windows.Forms.Timer twoPlayersTimer;
    }
}
