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
            this.clothPlaceHolderLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clothPlaceHolderLabel
            // 
            this.clothPlaceHolderLabel.BackColor = System.Drawing.Color.DarkGreen;
            this.clothPlaceHolderLabel.Location = new System.Drawing.Point(30, 30);
            this.clothPlaceHolderLabel.Name = "clothPlaceHolderLabel";
            this.clothPlaceHolderLabel.Size = new System.Drawing.Size(740, 440);
            this.clothPlaceHolderLabel.TabIndex = 0;
            this.clothPlaceHolderLabel.Text = "clothPlaceHolderLabel";
            this.clothPlaceHolderLabel.Visible = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.Controls.Add(this.clothPlaceHolderLabel);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(800, 500);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label clothPlaceHolderLabel;
    }
}
