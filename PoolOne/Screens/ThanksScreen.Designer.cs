namespace PoolOne
{
    partial class ThanksScreen
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
            this.thanksLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // thanksLabel
            // 
            this.thanksLabel.AutoSize = true;
            this.thanksLabel.BackColor = System.Drawing.Color.Transparent;
            this.thanksLabel.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thanksLabel.ForeColor = System.Drawing.Color.Red;
            this.thanksLabel.Location = new System.Drawing.Point(49, 144);
            this.thanksLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.thanksLabel.Name = "thanksLabel";
            this.thanksLabel.Size = new System.Drawing.Size(548, 46);
            this.thanksLabel.TabIndex = 37;
            this.thanksLabel.Text = "Thank you for playing!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(86, 203);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(439, 31);
            this.label1.TabIndex = 38;
            this.label1.Text = "Press any key to continue";
            // 
            // ThanksScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.thanksLabel);
            this.DoubleBuffered = true;
            this.Name = "ThanksScreen";
            this.Size = new System.Drawing.Size(645, 430);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ThanksScreen_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label thanksLabel;
        private System.Windows.Forms.Label label1;
    }
}
