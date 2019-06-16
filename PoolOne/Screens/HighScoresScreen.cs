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

            testLabel.Text = "" + GameScreen.thisScreen.highScoresList[0].name;
            //here you put everything in the right place
        }
    }
}
