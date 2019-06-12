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
    public partial class PauseScreen : UserControl
    {
        public PauseScreen()
        {
            InitializeComponent();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            GameScreen.RemovePauseScreen(this);
        }

        private void continueButton_Enter(object sender, EventArgs e)
        {
            continueButton.ForeColor = Color.Red;
            continueButton.FlatAppearance.BorderSize = 2;
        }

        private void continueButton_Leave(object sender, EventArgs e)
        {
            continueButton.ForeColor = Color.Black;
            continueButton.FlatAppearance.BorderSize = 0;
        }

        private void PauseScreen_Load(object sender, EventArgs e)
        {
            continueButton.Focus();
        }
    }
}
