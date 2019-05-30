using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoolOne
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GameScreen gs = new GameScreen();
            this.Controls.Add(gs);

            gs.Location = new Point((this.Width - gs.Width) / 2, (this.Height - gs.Height) / 2);
            gs.BringToFront();
        }

    }
}
