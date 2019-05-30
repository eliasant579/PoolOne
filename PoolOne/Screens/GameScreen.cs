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
        Ball[] ballsArray = new Ball[16];
        public Random randGenerator = new Random();
        public static GameScreen thisScreen = new GameScreen();
        public static HighScoresScreen hs = new HighScoresScreen();

        public GameScreen()
        {
            InitializeComponent();
            InitializeValues();
            thisScreen = this;
        }

        public void InitializeValues()
        {
            //put menu on top of this game screen
            MenuScreen ms = new MenuScreen();
            LoadMenuScreen(ms);

            //whiteball
            Ball cueBall = new Ball(200, (this.Height - 30) / 2, 0, 0, 30, Color.White, "solid");
            ballsArray[0] = cueBall;

            //generate balls 1 - 15
            for (int i = 1; i < 16; i++)
            {
                Ball nextBall = new Ball();

                nextBall.size = 30; 
                
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
                
                //Set if solid or stripes
                if (i < 9)
                {
                    nextBall.solidTrue = true;
                }
                else if (i < 16)
                {
                    nextBall.solidTrue = false;
                }

                ballsArray[i] = nextBall;
            }

            //assign to balls from 1 to 15 exept 8 random positions from position list
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Brushes
            SolidBrush borderBrush = new SolidBrush(Color.Maroon);
            SolidBrush ballBrush = new SolidBrush(Color.White);

            //draw borders
            e.Graphics.FillRectangle(borderBrush, 0, 0, BORDERSIZE, this.Height);
            e.Graphics.FillRectangle(borderBrush, 0, 0, this.Width, BORDERSIZE);
            e.Graphics.FillRectangle(borderBrush, this.Width - BORDERSIZE, 0, BORDERSIZE, this.Height);
            e.Graphics.FillRectangle(borderBrush, 0, this.Height - BORDERSIZE, this.Width, BORDERSIZE);

            //draw balls
            for (int i = 0; i < 16; i++)
            {
                Ball b = ballsArray[i];
                ballBrush.Color = b.colour;
                e.Graphics.FillEllipse(ballBrush, b.x, b.y, b.size, b.size);
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if(true)
            {
                ballsArray[0].x += 2;
            }
            Refresh();
        }

        public static void LoadMenuScreen(MenuScreen ms)
        {
            thisScreen.Controls.Add(ms);

            ms.Location = new Point((thisScreen.Width - ms.Width) / 2, (thisScreen.Height - ms.Height) / 2);
            ms.BackColor = Color.FromArgb(80, 128, 128, 128);
            ms.BringToFront();
        }

        public static void RemoveMenuScreen(MenuScreen ms)
        {
            thisScreen.Controls.Remove(ms);
            thisScreen.gameTimer.Enabled = true;
        }

        public static void LoadHighScoresScreen(MenuScreen ms)
        {
            thisScreen.Controls.Remove(ms);

            Form form = thisScreen.FindForm();

            hs.Location = new Point((form.Width - hs.Width) / 2, (form.Height - hs.Height) / 2);

            thisScreen.Controls.Add(hs);
            hs.BringToFront();
        }

        public static void RemoveHighScoresScreen()
        {
            thisScreen.Controls.Remove(hs);

            MenuScreen ms = new MenuScreen();
            LoadMenuScreen(ms);
        }

    }
}
