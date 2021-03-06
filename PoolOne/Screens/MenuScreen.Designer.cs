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
            this.titleLabel = new System.Windows.Forms.Label();
            this.comingSoonLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // onePlayerButton
            // 
            this.onePlayerButton.BackColor = System.Drawing.Color.White;
            this.onePlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.onePlayerButton.FlatAppearance.BorderSize = 0;
            this.onePlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onePlayerButton.Font = new System.Drawing.Font("Impact", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onePlayerButton.ForeColor = System.Drawing.Color.Black;
            this.onePlayerButton.Location = new System.Drawing.Point(47, 242);
            this.onePlayerButton.Margin = new System.Windows.Forms.Padding(4);
            this.onePlayerButton.Name = "onePlayerButton";
            this.onePlayerButton.Size = new System.Drawing.Size(207, 55);
            this.onePlayerButton.TabIndex = 0;
            this.onePlayerButton.Text = "ONE PLAYER";
            this.onePlayerButton.UseVisualStyleBackColor = false;
            this.onePlayerButton.Click += new System.EventHandler(this.onePlayerButton_Click);
            this.onePlayerButton.Enter += new System.EventHandler(this.onePlayerButton_Enter);
            this.onePlayerButton.Leave += new System.EventHandler(this.onePlayerButton_Leave);
            // 
            // twoPlayersButton
            // 
            this.twoPlayersButton.BackColor = System.Drawing.Color.White;
            this.twoPlayersButton.Enabled = false;
            this.twoPlayersButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.twoPlayersButton.FlatAppearance.BorderSize = 0;
            this.twoPlayersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twoPlayersButton.Font = new System.Drawing.Font("Impact", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoPlayersButton.ForeColor = System.Drawing.Color.Black;
            this.twoPlayersButton.Location = new System.Drawing.Point(149, 329);
            this.twoPlayersButton.Margin = new System.Windows.Forms.Padding(4);
            this.twoPlayersButton.Name = "twoPlayersButton";
            this.twoPlayersButton.Size = new System.Drawing.Size(229, 55);
            this.twoPlayersButton.TabIndex = 1;
            this.twoPlayersButton.Text = "TWO PLAYERS";
            this.twoPlayersButton.UseVisualStyleBackColor = false;
            this.twoPlayersButton.Click += new System.EventHandler(this.twoPlayersButton_Click);
            this.twoPlayersButton.Enter += new System.EventHandler(this.twoPlayersButton_Enter);
            this.twoPlayersButton.Leave += new System.EventHandler(this.twoPlayersButton_Leave);
            // 
            // highScoresButton
            // 
            this.highScoresButton.BackColor = System.Drawing.Color.White;
            this.highScoresButton.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.highScoresButton.FlatAppearance.BorderSize = 0;
            this.highScoresButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.highScoresButton.Font = new System.Drawing.Font("Impact", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoresButton.ForeColor = System.Drawing.Color.Black;
            this.highScoresButton.Location = new System.Drawing.Point(301, 242);
            this.highScoresButton.Margin = new System.Windows.Forms.Padding(4);
            this.highScoresButton.Name = "highScoresButton";
            this.highScoresButton.Size = new System.Drawing.Size(222, 55);
            this.highScoresButton.TabIndex = 2;
            this.highScoresButton.Text = "HIGHSCORES";
            this.highScoresButton.UseVisualStyleBackColor = false;
            this.highScoresButton.Click += new System.EventHandler(this.highScoresButton_Click);
            this.highScoresButton.Enter += new System.EventHandler(this.highScoresButton_Enter);
            this.highScoresButton.Leave += new System.EventHandler(this.highScoresButton_Leave);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.White;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Impact", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(469, 329);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(143, 55);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "QUIT";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.Enter += new System.EventHandler(this.exitButton_Enter);
            this.exitButton.Leave += new System.EventHandler(this.exitButton_Leave);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Impact", 72F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Maroon;
            this.titleLabel.Location = new System.Drawing.Point(3, 29);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(498, 145);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "POOOOOL";
            // 
            // comingSoonLabel
            // 
            this.comingSoonLabel.AutoSize = true;
            this.comingSoonLabel.BackColor = System.Drawing.Color.White;
            this.comingSoonLabel.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comingSoonLabel.ForeColor = System.Drawing.Color.Red;
            this.comingSoonLabel.Location = new System.Drawing.Point(258, 363);
            this.comingSoonLabel.Name = "comingSoonLabel";
            this.comingSoonLabel.Size = new System.Drawing.Size(120, 21);
            this.comingSoonLabel.TabIndex = 5;
            this.comingSoonLabel.Text = "Coming soooon";
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.comingSoonLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.highScoresButton);
            this.Controls.Add(this.twoPlayersButton);
            this.Controls.Add(this.onePlayerButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(668, 404);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button onePlayerButton;
        private System.Windows.Forms.Button twoPlayersButton;
        private System.Windows.Forms.Button highScoresButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label comingSoonLabel;
    }
}
