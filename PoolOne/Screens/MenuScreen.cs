﻿using System;
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
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void onePlayerButton_Click(object sender, EventArgs e)
        {
            GameScreen.RemoveMenuScreen(this, 1);
        }

        private void twoPlayersButton_Click(object sender, EventArgs e)
        {
            GameScreen.RemoveMenuScreen(this, 2);
        }

        private void highScoresButton_Click(object sender, EventArgs e)
        {
            GameScreen.LoadHighScoresScreen(this);
        }
    }
}
