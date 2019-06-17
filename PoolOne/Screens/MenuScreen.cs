using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoolOne
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();

            titleLabel.BackColor = Color.FromArgb(150, 0, 0, 0);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void onePlayerButton_Click(object sender, EventArgs e)
        {
            GameScreen.RemoveThis(this);
            GameScreen.StartGame(1);
        }

        private void twoPlayersButton_Click(object sender, EventArgs e)
        {
            GameScreen.RemoveThis(this);
            GameScreen.StartGame(2);
        }

        private void highScoresButton_Click(object sender, EventArgs e)
        {
            GameScreen.RemoveThis(this);
            GameScreen.LoadHighScoresScreen();
        }

        private void onePlayerButton_Enter(object sender, EventArgs e)
        {
            onePlayerButton.ForeColor = Color.Red;
            onePlayerButton.FlatAppearance.BorderSize = 2;
        }

        private void onePlayerButton_Leave(object sender, EventArgs e)
        {
            onePlayerButton.ForeColor = Color.Black;
            onePlayerButton.FlatAppearance.BorderSize = 0;
        }

        private void twoPlayersButton_Enter(object sender, EventArgs e)
        {
            twoPlayersButton.ForeColor = Color.Red;
            twoPlayersButton.FlatAppearance.BorderSize = 2;
        }

        private void twoPlayersButton_Leave(object sender, EventArgs e)
        {
            twoPlayersButton.ForeColor = Color.Black;
            twoPlayersButton.FlatAppearance.BorderSize = 0;
        }

        private void highScoresButton_Enter(object sender, EventArgs e)
        {
            highScoresButton.ForeColor = Color.Red;
            highScoresButton.FlatAppearance.BorderSize = 2;
        }

        private void highScoresButton_Leave(object sender, EventArgs e)
        {
            highScoresButton.ForeColor = Color.Black;
            highScoresButton.FlatAppearance.BorderSize = 0;
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            exitButton.ForeColor = Color.Red;
            exitButton.FlatAppearance.BorderSize = 2;
        }

        private void exitButton_Leave(object sender, EventArgs e)
        {
            exitButton.ForeColor = Color.Black;
            exitButton.FlatAppearance.BorderSize = 0;
        }
    }
}
