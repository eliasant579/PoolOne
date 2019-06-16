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
    public partial class ThanksScreen : UserControl
    {
        public ThanksScreen()
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(200, 200, 200, 200);
        }

        private void ThanksScreen_KeyDown(object sender, KeyEventArgs e)
        {
            GameScreen.RemoveThis(this);
            GameScreen.LoadMenuScreen();
        }
    }
}
