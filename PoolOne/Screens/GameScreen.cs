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
    public partial class GameScreen : UserControl
    {
        const int BORDERSIZE = 30;
        List<Ball> ballList = new List<Ball>();
        public Random randGenerator = new Random();

        public GameScreen()
        {
            InitializeComponent();
            OnScreen();
        }

        public void OnScreen()
        {
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
            ms.BackColor = Color.FromArgb(80, 128, 128, 128);
            ms.BringToFront();

            Ball testBall = new Ball(200, (this.Height - 30) / 2, 0, 0, 30, 0, Color.White);
            ballList.Add(testBall);

            for (int i = 1; i < 16; i++)
            {
                Ball nextBall = new Ball();
                
                //changes colour
                switch (i)
                {
                    case 1:
                        nextBall.colour = Color.Yellow;
                        break;
                    case 2:
                        nextBall.colour = Color.Blue;
                        break;
                    case 3:
                        nextBall.colour = Color.Red;
                        break;
                    case 4:
                        nextBall.colour = Color.Purple;
                        break;
                    case 5:
                        nextBall.colour = Color.Orange;
                        break;
                    case 6:
                        nextBall.colour = Color.LightGreen;
                        break;
                    case 7:
                        nextBall.colour = Color.Maroon;
                        break;
                    case 8:
                        nextBall.colour = Color.Black;
                        break;
                    case 9:
                        nextBall.colour = Color.Yellow;
                        break;
                    case 10:
                        nextBall.colour = Color.Blue;
                        break;
                    case 11:
                        nextBall.colour = Color.Red;
                        break;
                    case 12:
                        nextBall.colour = Color.Purple;
                        break;
                    case 13:
                        nextBall.colour = Color.Orange;
                        break;
                    case 14:
                        nextBall.colour = Color.LightGreen;
                        break;
                    case 15:
                        nextBall.colour = Color.Maroon;
                        break;
                }
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush borderBrush = new SolidBrush(Color.Maroon);
            SolidBrush ballBrush = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(borderBrush, 0, 0, BORDERSIZE, this.Height);
            e.Graphics.FillRectangle(borderBrush, 0, 0, this.Width, BORDERSIZE);
            e.Graphics.FillRectangle(borderBrush, this.Width - BORDERSIZE, 0, BORDERSIZE, this.Height);
            e.Graphics.FillRectangle(borderBrush, 0, this.Height - BORDERSIZE, this.Width, BORDERSIZE);

            foreach(Ball b in ballList)
            {
                ballBrush.Color = b.colour;
                e.Graphics.FillEllipse(ballBrush, b.x, b.y, b.size, b.size);
            }
        }
    }
}
