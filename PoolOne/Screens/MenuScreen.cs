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
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void onePlayerButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void twoPlayersButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void highScoresButton_Click(object sender, EventArgs e)
        {
            Form form = this.FindForm();
            this.Parent.Controls.Remove(this);

            HighScoresScreen hs = new HighScoresScreen();
            form.Controls.Add(hs);

            hs.Location = new Point((form.Width - hs.Width) / 2, (form.Height - hs.Height) / 2);
            hs.BringToFront();

        }
    }
}
