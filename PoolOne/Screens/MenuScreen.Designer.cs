﻿namespace PoolOne
{
    partial class MenuScreen
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
            this.onePlayerButton = new System.Windows.Forms.Button();
            this.twoPlayersButton = new System.Windows.Forms.Button();
            this.highScoresButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // onePlayerButton
            // 
            this.onePlayerButton.Location = new System.Drawing.Point(63, 256);
            this.onePlayerButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.onePlayerButton.Name = "onePlayerButton";
            this.onePlayerButton.Size = new System.Drawing.Size(100, 28);
            this.onePlayerButton.TabIndex = 0;
            this.onePlayerButton.Text = "One player";
            this.onePlayerButton.UseVisualStyleBackColor = true;
            this.onePlayerButton.Click += new System.EventHandler(this.onePlayerButton_Click);
            // 
            // twoPlayersButton
            // 
            this.twoPlayersButton.Location = new System.Drawing.Point(195, 320);
            this.twoPlayersButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.twoPlayersButton.Name = "twoPlayersButton";
            this.twoPlayersButton.Size = new System.Drawing.Size(100, 28);
            this.twoPlayersButton.TabIndex = 1;
            this.twoPlayersButton.Text = "Two players";
            this.twoPlayersButton.UseVisualStyleBackColor = true;
            this.twoPlayersButton.Click += new System.EventHandler(this.twoPlayersButton_Click);
            // 
            // highScoresButton
            // 
            this.highScoresButton.Location = new System.Drawing.Point(345, 256);
            this.highScoresButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.highScoresButton.Name = "highScoresButton";
            this.highScoresButton.Size = new System.Drawing.Size(100, 28);
            this.highScoresButton.TabIndex = 2;
            this.highScoresButton.Text = "Highscores";
            this.highScoresButton.UseVisualStyleBackColor = true;
            this.highScoresButton.Click += new System.EventHandler(this.highScoresButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(515, 320);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(100, 28);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Quit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.highScoresButton);
            this.Controls.Add(this.twoPlayersButton);
            this.Controls.Add(this.onePlayerButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(668, 404);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button onePlayerButton;
        private System.Windows.Forms.Button twoPlayersButton;
        private System.Windows.Forms.Button highScoresButton;
        private System.Windows.Forms.Button exitButton;
    }
}
