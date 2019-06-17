using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace PoolOne
{
    public partial class HighScoresScreen : UserControl
    {
        public HighScoresScreen()
        {
            InitializeComponent();
        }

        private void backToMenuButton_Click(object sender, EventArgs e)
        {
            GameScreen.RemoveThis(this);
            GameScreen.LoadMenuScreen();
        }

        private void backToMenuButton_Enter(object sender, EventArgs e)
        {
            backToMenuButton.ForeColor = Color.Red;
            backToMenuButton.FlatAppearance.BorderSize = 2;
        }

        private void backToMenuButton_Leave(object sender, EventArgs e)
        {
            backToMenuButton.ForeColor = Color.Black;
            backToMenuButton.FlatAppearance.BorderSize = 0;
        }

        private void HighScoresScreen_Load(object sender, EventArgs e)
        {
            backToMenuButton.Focus();
        }

        private void HighScoresScreen_Paint(object sender, PaintEventArgs e)
        {
            Font impactFont = new Font("Impact", 20);
            SolidBrush redBrush = new SolidBrush(Color.Maroon);
            SolidBrush whiteBrush = new SolidBrush(Color.FromArgb(200, 255, 255, 255));

            e.Graphics.FillRectangle(whiteBrush, 40, 30, 425, 230);

            for (int i = 0; i < GameScreen.thisScreen.highScoresList.Count; i++)
            {
                HighScore hs = GameScreen.thisScreen.highScoresList[i];

                e.Graphics.DrawString((i + 1) + "     " + hs.name + "     " + hs.shots + "     " + hs.dateTime.Day + "-" + hs.dateTime.Month + "-" + hs.dateTime.Year, impactFont, redBrush, 50, i*40 + 130);
            }
        }
    }
}
