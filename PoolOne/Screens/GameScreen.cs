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
        const float FRICTION_COEFFICIENT = 0.015f;
        const int BALL_SIZE = 30;
        const int BALL_RADIUS = 15;

        public static GameScreen thisScreen = new GameScreen();

        Ball[] ballsArray = new Ball[16];
        PointF[] startPositionArray = new PointF[16];
        public Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown = false;
        public Boolean ballsStopped;
        //public SolidBrush borderBrush = new SolidBrush(Color.Maroon);
        //public Random randGenerator = new Random();

        public int playerNumber, player1Shots, player2Shots = 0;

        public GameScreen()
        {
            InitializeComponent();
            thisScreen = this;
            InitializeValues();
        }

        public void InitializeValues()
        {
            LoadMenuScreen();

            //Still needs randomization
            #region declaring start positions
            startPositionArray[0] = new Point(200, (this.Height - BALL_SIZE) / 2);

            startPositionArray[1] = new Point(this.Width / 2 + 3 * BALL_SIZE, (this.Height - BALL_SIZE) / 2);


            startPositionArray[2] = new Point(this.Width / 2 + 4 * BALL_SIZE, (this.Height - 2 * BALL_SIZE) / 2 - 1);
            startPositionArray[3] = new Point(this.Width / 2 + 4 * BALL_SIZE, this.Height / 2 + 1);

            startPositionArray[4] = new Point(this.Width / 2 + 5 * BALL_SIZE, (this.Height - 3 * BALL_SIZE) / 2 - 1);
            startPositionArray[5] = new Point(this.Width / 2 + 5 * BALL_SIZE, (this.Height + BALL_SIZE) / 2 + 1);
            startPositionArray[6] = new Point(this.Width / 2 + 6 * BALL_SIZE, (this.Height - 4 * BALL_SIZE) / 2 - 2);

            //*
            startPositionArray[7] = new Point(this.Width / 2 + 6 * BALL_SIZE, (this.Height - 2 * BALL_SIZE) / 2 - 1);
            startPositionArray[8] = new Point(this.Width / 2 + 5 * BALL_SIZE, (this.Height - BALL_SIZE) / 2);
            startPositionArray[9] = new Point(this.Width / 2 + 6 * BALL_SIZE, (this.Height) / 2 + 1);
            startPositionArray[10] = new Point(this.Width / 2 + 6 * BALL_SIZE, (this.Height + 2 * BALL_SIZE) / 2 + 2);

            startPositionArray[11] = new Point(this.Width / 2 + 7 * BALL_SIZE, (this.Height - 5 * BALL_SIZE) / 2 - 2);
            startPositionArray[12] = new Point(this.Width / 2 + 7 * BALL_SIZE, (this.Height - 3 * BALL_SIZE) / 2 - 1);
            startPositionArray[13] = new Point(this.Width / 2 + 7 * BALL_SIZE, (this.Height - BALL_SIZE) / 2);
            startPositionArray[14] = new Point(this.Width / 2 + 7 * BALL_SIZE, (this.Height + BALL_SIZE) / 2 + 1);
            startPositionArray[15] = new Point(this.Width / 2 + 7 * BALL_SIZE, (this.Height + 3 * BALL_SIZE) / 2 + 2);
            //*/

            #endregion

            //generate balls
            for (int i = 0; i < 16; i++)
            {
                Ball nextBall = new Ball(startPositionArray[i].X, startPositionArray[i].Y, BALL_RADIUS, Color.Beige);

                //changes colour
                switch (i)
                {
                    case 0:
                        nextBall.colour = Color.White;
                        break;
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
                        nextBall.colour = Color.GreenYellow;
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
                        nextBall.colour = Color.GreenYellow;
                        break;
                    case 15:
                        nextBall.colour = Color.Maroon;
                        break;
                }

                #region Maybe scramble?
                /*to use only if I do scramble balls
                //gets positions
                switch (i)
                {
                    case 0:
                        nextBall.x = new Point(200, (this.Height - BALL_SIZE) / 2).X;
                        nextBall.y = new Point(200, (this.Height - BALL_SIZE) / 2).Y;
                        break;
                    case 8:
                        nextBall.x = new Point(this.Width / 2 + 5 * BALL_SIZE, (this.Height - BALL_SIZE) / 2).X;
                        nextBall.y = new Point(this.Width / 2 + 5 * BALL_SIZE, (this.Height - BALL_SIZE) / 2).Y;
                        break;
                    default:                       
                        nextBall.x = startPositionArray[i].X;
                        nextBall.y = startPositionArray[i].Y;
                        break;
                }
                */
                #endregion 
                ballsArray[i] = nextBall;
            }

            ballsArray[0].velocity.x = 13;
            ballsArray[0].velocity.y = 1;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //*Ball for testing
            if (downArrowDown)
            {
                ballsArray[0].velocity.y += 1;
            }
            else if (upArrowDown)
            {
                ballsArray[0].velocity.y -= 1;
            }

            if (leftArrowDown)
            {
                ballsArray[0].velocity.x -= 1;
            }
            else if (rightArrowDown)
            {
                ballsArray[0].velocity.x += 1;
            }
            //*/

            /*/
            if (downArrowDown)
            {
                ballsArray[0].velocity.y = 8;
            }
            else if (upArrowDown)
            {
                ballsArray[0].velocity.y = -8;
            }
            else
            {
                ballsArray[0].velocity.y = 0;
            }

            if (leftArrowDown)
            {
                ballsArray[0].velocity.x = -8;
            }
            else if (rightArrowDown)
            {
                ballsArray[0].velocity.x = 8;
            }
            else
            {
                ballsArray[0].velocity.x = 0;
            }
            //*/

            ProcessCollisions();

            //move balls by their speed
            for (int i = 0; i < 16; i++)
            {
                ballsArray[i].position.x += ballsArray[i].velocity.x;
                ballsArray[i].position.y += ballsArray[i].velocity.y;
            }

            //slow balls down
            for (int i = 0; i < 16; i++)
            {
                if (ballsArray[i].velocity.getLength() >= 0.2)
                {
                    ballsArray[i].velocity = ballsArray[i].velocity.multiply(1 - FRICTION_COEFFICIENT);
                }
                else
                {
                    ballsArray[i].velocity = new Vector2d(0, 0);
                }
            }

            //save if there is motion on screen
            ballsStopped = true;
            for (int i = 0; i < 16; i++)
            {
                if (ballsArray[i].inPocket == false && ballsArray[i].velocity.getLength() != 0)
                {
                    ballsStopped = false;
                }
            }

            Refresh();
        }

        private void ProcessCollisions()
        {
            for (int i = 0; i < 16; i++)
            {
                if (ballsArray[i].inPocket == false)
                {
                    ballsArray[i].SidesCollsion(this);

                    for (int j = i; j < 16; j++)
                    {
                        if (ballsArray[i] != ballsArray[j])
                        {
                            if (ballsArray[i].Colliding(ballsArray[j]))
                            {
                                ballsArray[i].ResolveCollision(ballsArray[j]);
                            }
                        }
                    }
                }
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Brushes
            SolidBrush borderBrush = new SolidBrush(Color.Maroon);
            SolidBrush ballBrush = new SolidBrush(Color.White);
            SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(80, 150, 150, 150));
            SolidBrush whiteBrush = new SolidBrush(Color.Wheat);

            Pen numberPen = new Pen(Color.Black, 2);

            //draw borders
            e.Graphics.FillRectangle(borderBrush, 0, 0, BORDERSIZE, this.Height);
            e.Graphics.FillRectangle(borderBrush, 0, 0, this.Width, BORDERSIZE);
            e.Graphics.FillRectangle(borderBrush, this.Width - BORDERSIZE, 0, BORDERSIZE, this.Height);
            e.Graphics.FillRectangle(borderBrush, 0, this.Height - BORDERSIZE, this.Width, BORDERSIZE);

            //draw shadows
            for (int i = 0; i < 16; i++)
            {
                if (ballsArray[i].inPocket == false)
                {
                    Ball b = ballsArray[i];
                    e.Graphics.FillEllipse(shadowBrush, b.position.x + 3, b.position.y + 2, b.radius * 2, b.radius * 2);
                }
            }

            //draw balls
            for (int i = 0; i < 16; i++)
            {
                if (ballsArray[i].inPocket == false)
                {
                    Ball b = ballsArray[i];
                    ballBrush.Color = b.colour;
                    if (i < 9)
                    {                       
                        e.Graphics.FillEllipse(ballBrush, b.position.x, b.position.y, b.radius * 2, b.radius * 2);
                    }
                    else
                    {
                        e.Graphics.FillEllipse(whiteBrush, b.position.x, b.position.y, b.radius * 2, b.radius * 2);
                        e.Graphics.FillRectangle(ballBrush, b.position.x + 4, b.position.y + 5, b.radius * 2 - 8, b.radius * 2 - 10);
                    }
                }
            }
        }

        #region Screens management

        public static void LoadMenuScreen()
        {
            MenuScreen ms = new MenuScreen();

            ms.Location = new Point((thisScreen.Width - ms.Width) / 2, (thisScreen.Height - ms.Height) / 2);
            ms.BackColor = Color.FromArgb(80, 128, 128, 128);

            thisScreen.Controls.Add(ms);
            ms.BringToFront();
        }

        public static void RemoveMenuScreen(MenuScreen ms, int n)
        {
            thisScreen.Controls.Remove(ms);
            StartGame(n);
        }

        public static void LoadHighScoresScreen(MenuScreen ms)
        {
            thisScreen.Controls.Remove(ms);

            Form form = thisScreen.FindForm();

            HighScoresScreen hs = new HighScoresScreen();

            hs.Location = new Point((thisScreen.Width - hs.Width) / 2, (thisScreen.Height - hs.Height) / 2);
            hs.BackColor = Color.FromArgb(80, 128, 128, 128);

            thisScreen.Controls.Add(hs);
            hs.BringToFront();
        }

        public static void RemoveHighScoresScreen(HighScoresScreen hss)
        {
            thisScreen.Controls.Remove(hss);
        }

        public static void StartGame(int playersNumber)
        {
            thisScreen.gameTimer.Enabled = true;
            thisScreen.playerNumber = playersNumber;
            thisScreen.Focus();
        }

        #endregion

        #region Key press
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (ballsStopped)
            {
                if (e.KeyCode == Keys.Down)
                {
                    downArrowDown = true;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    upArrowDown = true;
                }

                if (e.KeyCode == Keys.Left)
                {
                    leftArrowDown = true;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    rightArrowDown = true;
                }
            }          
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                downArrowDown = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                upArrowDown = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                leftArrowDown = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                rightArrowDown = false;
            }
        }
        #endregion
    }
}