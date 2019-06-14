using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace PoolOne
{
    public partial class GameScreen : UserControl
    {
        const int BALL_NUMBER = 16;

        private const int BORDER_SIZE = 30;
        private const int TABLE_OFFSET = 150;

        const float FRICTION_COEFFICIENT = 0.01f;
        const float SLOW_FRICTION_COEFFICIENT = 0.025f;
        const int BALL_SIZE = 30;
        const int BALL_RADIUS = 15;
        const float COMPONENT_INCREASE = 0.5f;
        const int MAX_SPEED = 35;

        public static GameScreen thisScreen = new GameScreen();

        Ball[] ballsArray = new Ball[BALL_NUMBER];
        PointF[] startPositionArray = new PointF[16];
        Pocket[] pocketsArray = new Pocket[6];
        HighScore[] highScoresArray = new HighScore[4];

        Vector2d velocityInputVector = new Vector2d();

        public Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, enterDown, escapeDown;
        public Boolean ballsStopped, screenEmpty;

        public int playerNumber, player1Shots, player2Shots = 0;

        public GameScreen()
        {
            InitializeComponent();
            thisScreen = this;
            LoadMenuScreen();
            InitializeValues();

            SoundPlayer deadSkunkJamPlayer = new SoundPlayer(Properties.Resources.Dead_Skunk_Jam_Arcade_Cabinet_Cut);
            deadSkunkJamPlayer.PlayLooping();
        }

        public void InitializeValues()
        {
            #region declaring start positions
            startPositionArray[0] = new Point(this.Width / 2 - 10 * BALL_SIZE, (this.Height - BALL_SIZE) / 2);

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

            #region declaring pockets
            pocketsArray[0] = new Pocket(BORDER_SIZE - BALL_RADIUS / 2 + TABLE_OFFSET, BORDER_SIZE - BALL_RADIUS / 2 +  TABLE_OFFSET, BALL_RADIUS);
            pocketsArray[1] = new Pocket(this.Width / 2 - BALL_RADIUS, BORDER_SIZE - BALL_RADIUS / 2 + TABLE_OFFSET, BALL_RADIUS);
            pocketsArray[2] = new Pocket(this.Width - BORDER_SIZE - BALL_RADIUS * 3 / 2 - TABLE_OFFSET, BORDER_SIZE - BALL_RADIUS / 2 + TABLE_OFFSET, BALL_RADIUS);
            pocketsArray[3] = new Pocket(BORDER_SIZE - BALL_RADIUS / 2 + TABLE_OFFSET, this.Height - BORDER_SIZE - BALL_RADIUS * 3 / 2 - TABLE_OFFSET, BALL_RADIUS);
            pocketsArray[4] = new Pocket(this.Width / 2 - BALL_RADIUS, this.Height - BORDER_SIZE - BALL_RADIUS * 3 / 2 - TABLE_OFFSET, BALL_RADIUS);
            pocketsArray[5] = new Pocket(this.Width - BORDER_SIZE - BALL_RADIUS * 3 / 2 - TABLE_OFFSET, this.Height - BORDER_SIZE - BALL_RADIUS * 3 / 2 - TABLE_OFFSET, BALL_RADIUS);
            #endregion

            //generate balls
            for (int i = 0; i < ballsArray.Length; i++)
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

                //if you have time to scramble them do it here

                ballsArray[i] = nextBall;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {          
            //*Actual ball 
            if (ballsStopped)
            {
                if (ballsArray[0].inPocket)
                {
                    ballsArray[0].inPocket = false;
                    ballsArray[0].position = new Vector2d(startPositionArray[0].X, startPositionArray[0].Y);
                }

                Vector2d tempVelocity = new Vector2d(velocityInputVector.x, velocityInputVector.y);

                if (downArrowDown)
                {
                    velocityInputVector.y += COMPONENT_INCREASE;
                }
                else if (upArrowDown)
                {
                    velocityInputVector.y -= COMPONENT_INCREASE;
                }

                if (leftArrowDown)
                {
                    velocityInputVector.x -= COMPONENT_INCREASE;
                }
                else if (rightArrowDown)
                {
                    velocityInputVector.x += COMPONENT_INCREASE;
                }

                if (velocityInputVector.getLength() >= MAX_SPEED)
                {
                    velocityInputVector = tempVelocity;
                }

                if (enterDown)
                {
                    ballsArray[0].velocity = velocityInputVector.multiply(-1);
                    velocityInputVector = new Vector2d(0, 0);
                    ballsStopped = false;
                }
            }
            /*/

            /*
            //Testing
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

            else
            {
                //well. Guess what this one does
                ProcessCollisions();

                ballsStopped = true;
                screenEmpty = true;
                for (int i = 0; i < ballsArray.Length; i++)
                {
                    if (ballsArray[i].inPocket == false)
                    {
                        //move ball
                        ballsArray[i].position.x += ballsArray[i].velocity.x;
                        ballsArray[i].position.y += ballsArray[i].velocity.y;

                        //slow balls down
                        if (ballsArray[i].velocity.getLength() >= 3)
                        {
                            ballsArray[i].velocity = ballsArray[i].velocity.multiply(1 - FRICTION_COEFFICIENT);
                        }
                        else if (ballsArray[i].velocity.getLength() >= 0.4)
                        {
                            ballsArray[i].velocity = ballsArray[i].velocity.multiply(1 - SLOW_FRICTION_COEFFICIENT);
                        }
                        else
                        {
                            ballsArray[i].velocity = new Vector2d(0, 0);
                        }

                        //collision with pocket
                        PointF ballCentre = new PointF(ballsArray[i].position.x + BALL_RADIUS, ballsArray[i].position.y + BALL_RADIUS);
                        for (int j = 0; j < pocketsArray.Length; j++)
                        {
                            if (pocketsArray[j].PocketCollsion(ballCentre))
                            {
                                ballsArray[i].inPocket = true;
                                ballsArray[i].velocity = new Vector2d(0, 0);
                                break;
                            }
                        }
                    }

                    //save if there is motion on screen
                    if (ballsArray[i].inPocket == false && ballsArray[i].velocity.getLength() != 0)
                    {
                        ballsStopped = false;
                    }

                    if (ballsArray[i].inPocket == false && i != 0)
                    {
                        screenEmpty = false;
                    }
                }

                if (screenEmpty)
                {
                    gameTimer.Enabled = false;
                    InitializeValues();
                    LoadMenuScreen();
                }
            }


            if (escapeDown)
            {
                //gameTimer.Enabled = false;
                //escapeDown = false;
                //LoadPauseScreen();
            }

            Refresh();
        }

        private void ProcessCollisions()
        {
            for (int i = 0; i < ballsArray.Length; i++)
            {
                if (ballsArray[i].inPocket == false)
                {
                    ballsArray[i].SidesCollsion(this);

                    for (int j = i; j < ballsArray.Length; j++)
                    {
                        if (ballsArray[i] != ballsArray[j] && ballsArray[j].inPocket == false)
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

        public int getBorder()
        {
            return BORDER_SIZE;
        }

        public int getOffset()
        {
            return TABLE_OFFSET;
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Brushes and pens
            SolidBrush borderBrush = new SolidBrush(Color.Maroon);
            SolidBrush ballBrush = new SolidBrush(Color.White);
            SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
            SolidBrush whiteBrush = new SolidBrush(Color.Wheat);
            SolidBrush blackBrush = new SolidBrush(Color.FromArgb(255, 20, 20, 20));
            SolidBrush greenBrush = new SolidBrush(Color.DarkGreen);

            Pen arrowPen = new Pen(Color.FromArgb(255, 150, 70, 0), 6);
            Pen arrowShadowPen = new Pen(shadowBrush, 8);

            //Draw playground
            e.Graphics.FillRectangle(greenBrush, TABLE_OFFSET, TABLE_OFFSET, this.Width - 2 * TABLE_OFFSET, this.Height - 2 * TABLE_OFFSET);

            //draw borders' shadows
            e.Graphics.DrawLine(arrowShadowPen, BORDER_SIZE + TABLE_OFFSET, this.Height - (BORDER_SIZE + TABLE_OFFSET), this.Width - (BORDER_SIZE + TABLE_OFFSET), this.Height - BORDER_SIZE - TABLE_OFFSET);
            e.Graphics.DrawLine(arrowShadowPen, this.Width - (BORDER_SIZE + TABLE_OFFSET) - 2, BORDER_SIZE + TABLE_OFFSET, this.Width - BORDER_SIZE - TABLE_OFFSET - 2, this.Height - (BORDER_SIZE + TABLE_OFFSET));

            //draw borders
            e.Graphics.FillRectangle(borderBrush, TABLE_OFFSET, TABLE_OFFSET, BORDER_SIZE, this.Height - 2 * TABLE_OFFSET);
            e.Graphics.FillRectangle(borderBrush, TABLE_OFFSET, TABLE_OFFSET, this.Width - 2 * TABLE_OFFSET, BORDER_SIZE);
            e.Graphics.FillRectangle(borderBrush, this.Width - BORDER_SIZE - TABLE_OFFSET, TABLE_OFFSET, BORDER_SIZE, this.Height - 2 * TABLE_OFFSET);
            e.Graphics.FillRectangle(borderBrush, TABLE_OFFSET, this.Height - BORDER_SIZE - TABLE_OFFSET, this.Width - 2 * TABLE_OFFSET, BORDER_SIZE);

            //draw shadows
            for (int i = 0; i < ballsArray.Length; i++)
            {
                if (ballsArray[i].inPocket == false)
                {
                    Ball b = ballsArray[i];
                    e.Graphics.FillEllipse(shadowBrush, b.position.x - 3, b.position.y - 3, b.radius * 2, b.radius * 2);
                }
            }

            //draw pockets
            for (int i = 0; i < pocketsArray.Length; i++)
            {
                Pocket p = pocketsArray[i];
                e.Graphics.FillEllipse(blackBrush, p.position.X, p.position.Y, p.radius * 2, p.radius * 2);
            }

            //draw balls
            for (int i = 0; i < ballsArray.Length; i++)
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

            //aiming arrow
            if (ballsStopped)
            {
                PointF cueBallPosition = new PointF(ballsArray[0].position.x + BALL_RADIUS, ballsArray[0].position.y + BALL_RADIUS);
                PointF arrowPosition = new PointF(ballsArray[0].position.add(velocityInputVector.multiply(6)).x + BALL_RADIUS, ballsArray[0].position.add(velocityInputVector.multiply(6)).y + BALL_RADIUS);

                e.Graphics.DrawLine(arrowShadowPen, cueBallPosition.X - 1, cueBallPosition.Y - 1, arrowPosition.X - 1, arrowPosition.Y - 1);
                e.Graphics.DrawLine(arrowPen, cueBallPosition, arrowPosition);
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
            ms.Focus();
        }

        public static void RemoveMenuScreen(MenuScreen ms, int n)
        {
            thisScreen.Controls.Remove(ms);
            StartGame(n);
        }

        public static void LoadHighScoresScreen(MenuScreen ms)
        {
            thisScreen.Controls.Remove(ms);

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

        public static void LoadPauseScreen()
        {
            PauseScreen ps = new PauseScreen();

            ps.Location = new Point((thisScreen.Width - ps.Width) / 2, (thisScreen.Height - ps.Height) / 2);
            ps.BackColor = Color.FromArgb(80, 128, 128, 128);
            thisScreen.Controls.Add(ps);


        }

        public static void RemovePauseScreen(PauseScreen ps)
        {
            thisScreen.Controls.Remove(ps);
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


            if (e.KeyCode == Keys.Enter)
            {
                enterDown = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                //escapeDown = true;
                gameTimer.Enabled = false;
               //escapeDown = false;
                LoadPauseScreen();
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

            if (e.KeyCode == Keys.Enter)
            {
                enterDown = false;
            }

            if (e.KeyCode == Keys.Escape)
            {
                escapeDown = false;
            }
        }
        #endregion
    }
}