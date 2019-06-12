namespace PoolOne
{
    partial class PauseScreen
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
            this.continueButton = new System.Windows.Forms.Button();
            this.fakeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.White;
            this.continueButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.continueButton.FlatAppearance.BorderSize = 0;
            this.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueButton.Font = new System.Drawing.Font("Machine BT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(320, 234);
            this.continueButton.Name = "exitButton";
            this.continueButton.Size = new System.Drawing.Size(116, 45);
            this.continueButton.TabIndex = 4;
            this.continueButton.Text = "CONTINUE";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            this.continueButton.Enter += new System.EventHandler(this.continueButton_Enter);
            this.continueButton.Leave += new System.EventHandler(this.continueButton_Leave);
            // 
            // fakeButton
            // 
            this.fakeButton.BackColor = System.Drawing.Color.Transparent;
            this.fakeButton.Enabled = false;
            this.fakeButton.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.fakeButton.FlatAppearance.BorderSize = 0;
            this.fakeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fakeButton.Font = new System.Drawing.Font("Machine BT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fakeButton.Location = new System.Drawing.Point(3, 3);
            this.fakeButton.Name = "fakeButton";
            this.fakeButton.Size = new System.Drawing.Size(116, 45);
            this.fakeButton.TabIndex = 5;
            this.fakeButton.UseVisualStyleBackColor = false;
            // 
            // PauseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.fakeButton);
            this.Controls.Add(this.continueButton);
            this.Name = "PauseScreen";
            this.Size = new System.Drawing.Size(501, 328);
            this.Load += new System.EventHandler(this.PauseScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button fakeButton;
    }
}
