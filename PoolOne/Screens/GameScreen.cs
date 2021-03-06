﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Collections.Generic;
using System.Xml;
//using System.IO;

namespace PoolOne
{
    public partial class GameScreen : UserControl
    {
        //update xml file

        const int BALL_NUMBER = 16;

        private const int BORDER_SIZE = 30;
        private const int TABLE_OFFSET = 150;

        const float FRICTION_COEFFICIENT = 0.01f;
        const float SLOW_FRICTION_COEFFICIENT = 0.025f;
        const float BALL_SIZE = 35;
        const float BALL_RADIUS = 17.5f;
        const float POCKET_RADIUS = 30f;
        const float COMPONENT_INCREASE = 0.5f;
        const int MAX_SPEED = 35;

        public static GameScreen thisScreen = new GameScreen();

        Ball[] ballsArray = new Ball[BALL_NUMBER];
        PointF[] startPositionArray = new PointF[16];
        Pocket[] pocketsArray = new Pocket[6];
        public List<HighScore> highScoresList = new List<HighScore>();

        Vector2d velocityInputVector = new Vector2d();

        public Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, enterDown, escapeDown, kDown;
        public Boolean ballsStopped, screenEmpty;

        public int playerNumber, player1Shots, player2Shots = 0;

        //sound players. They work if going slowly and not overlapping each other. which is quite rare
        public SoundPlayer cueBallHitPlayer = new SoundPlayer(Properties.Resources.CueBallHit);
        public SoundPlayer ballToBallHitPlayer = new SoundPlayer(Properties.Resources.BallToBallHit);
        public SoundPlayer sideHitPlayer = new SoundPlayer(Properties.Resources.SideHit);
        public SoundPlayer inPocketPlayer = new SoundPlayer(Properties.Resources.BallInPocket);

        //System.Windows.Media.MediaPlayer cueBallHitPlayer = new System.Windows.Media.MediaPlayer();
        

        public GameScreen()
        {
            InitializeComponent();
            thisScreen = this;
            LoadMenuScreen();
            InitializeValues();

            //SoundPlayer deadSkunkJamPlayer = new SoundPlayer(Properties.Resources.Dead_Skunk_Jam_Arcade_Cabinet_Cut);
            //deadSkunkJamPlayer.PlayLooping();

            //cueBallHitPlayer.Open(new Uri(Application.StartupPath + "/Resources/CueBallHit.wav"));
        }

        public void InitializeValues()
        {
            #region declaring start positions
            startPositionArray[0] = new PointF(this.Width / 2 - 10 * BALL_SIZE, (this.Height - BALL_SIZE) / 2);

            startPositionArray[1] = new PointF(this.Width / 2 + 3 * BALL_SIZE, (this.Height - BALL_SIZE) / 2);


            startPositionArray[2] = new PointF(this.Width / 2 + 4 * BALL_SIZE, (this.Height - 2 * BALL_SIZE) / 2 - 1);
            startPositionArray[3] = new PointF(this.Width / 2 + 4 * BALL_SIZE, this.Height / 2 + 1);

            startPositionArray[4] = new PointF(this.Width / 2 + 5 * BALL_SIZE, (this.Height - 3 * BALL_SIZE) / 2 - 1);
            startPositionArray[5] = new PointF(this.Width / 2 + 5 * BALL_SIZE, (this.Height + BALL_SIZE) / 2 + 1);
            startPositionArray[6] = new PointF(this.Width / 2 + 6 * BALL_SIZE, (this.Height - 4 * BALL_SIZE) / 2 - 2);

            startPositionArray[7] = new PointF(this.Width / 2 + 6 * BALL_SIZE, (this.Height - 2 * BALL_SIZE) / 2 - 1);
            startPositionArray[8] = new PointF(this.Width / 2 + 5 * BALL_SIZE, (this.Height - BALL_SIZE) / 2);
            startPositionArray[9] = new PointF(this.Width / 2 + 6 * BALL_SIZE, (this.Height) / 2 + 1);
            startPositionArray[10] = new PointF(this.Width / 2 + 6 * BALL_SIZE, (this.Height + 2 * BALL_SIZE) / 2 + 2);

            startPositionArray[11] = new PointF(this.Width / 2 + 7 * BALL_SIZE, (this.Height - 5 * BALL_SIZE) / 2 - 2);
            startPositionArray[12] = new PointF(this.Width / 2 + 7 * BALL_SIZE, (this.Height - 3 * BALL_SIZE) / 2 - 1);
            startPositionArray[13] = new PointF(this.Width / 2 + 7 * BALL_SIZE, (this.Height - BALL_SIZE) / 2);
            startPositionArray[14] = new PointF(this.Width / 2 + 7 * BALL_SIZE, (this.Height + BALL_SIZE) / 2 + 1);
            startPositionArray[15] = new PointF(this.Width / 2 + 7 * BALL_SIZE, (this.Height + 3 * BALL_SIZE) / 2 + 2);
            #endregion

            #region declaring pockets
            pocketsArray[0] = new Pocket(BORDER_SIZE - POCKET_RADIUS / 2 + TABLE_OFFSET, BORDER_SIZE - POCKET_RADIUS / 2 +  TABLE_OFFSET, POCKET_RADIUS);
            pocketsArray[1] = new Pocket(this.Width / 2 - POCKET_RADIUS, BORDER_SIZE - POCKET_RADIUS / 2 + TABLE_OFFSET, POCKET_RADIUS);
            pocketsArray[2] = new Pocket(this.Width - BORDER_SIZE - POCKET_RADIUS * 3 / 2 - TABLE_OFFSET, BORDER_SIZE - POCKET_RADIUS / 2 + TABLE_OFFSET, POCKET_RADIUS);
            pocketsArray[3] = new Pocket(BORDER_SIZE - POCKET_RADIUS / 2 + TABLE_OFFSET, this.Height - BORDER_SIZE - POCKET_RADIUS * 3 / 2 - TABLE_OFFSET, POCKET_RADIUS);
            pocketsArray[4] = new Pocket(this.Width / 2 - POCKET_RADIUS, this.Height - BORDER_SIZE - POCKET_RADIUS * 3 / 2 - TABLE_OFFSET, POCKET_RADIUS);
            pocketsArray[5] = new Pocket(this.Width - BORDER_SIZE - POCKET_RADIUS * 3 / 2 - TABLE_OFFSET, this.Height - BORDER_SIZE - POCKET_RADIUS * 3 / 2 - TABLE_OFFSET, POCKET_RADIUS);
            #endregion

            player1Shots = 0;
            player2Shots = 0;

            highScoresList.Clear();

            //reads and saves values from xml
            XmlReader reader = XmlReader.Create("Resources/highScores.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    HighScore s = new HighScore();

                    s.name = reader.ReadString();

                    reader.ReadToNextSibling("shots");
                    s.shots = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("dateTime");
                    s.dateTime = Convert.ToDateTime(reader.ReadString());

                    highScoresList.Add(s);
                }
            }

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
            //Actual ball 
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

                if (enterDown && velocityInputVector.getLength() != 0)
                {
                    ballsStopped = false;
                    ballsArray[0].velocity = velocityInputVector.multiply(-1);
                    velocityInputVector = new Vector2d();
                    player1Shots++;
                    cueBallHitPlayer.Play();
                }

            }

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

                                inPocketPlayer.Play();
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
            }

            //if no balls other than the cue ball are on the screen
            if (screenEmpty || kDown)
            {
                gameTimer.Enabled = false;

                //see if score is lower than past scores or not
                int i = 0;
                foreach (HighScore hs in highScoresList)
                {
                    i++;
                    if (player1Shots <= hs.shots)
                    {
                        LoadEnterScore();
                        break;
                    }
                    else if (i == 3)
                    {
                        LoadThanksScreen();
                    }
                }

                InitializeValues();
            }

            if (escapeDown)
            {
                gameTimer.Enabled = false;
                escapeDown = false;
                LoadPauseScreen();
            }

            Refresh();
        }

        private void ProcessCollisions()
        {
            for (int i = 0; i < ballsArray.Length; i++)
            {
                if (ballsArray[i].inPocket == false)
                {
                    if (ballsArray[i].SidesCollsion(this))
                    {
                        sideHitPlayer.Play();
                    }

                    for (int j = i + 1; j < ballsArray.Length; j++)
                    {
                        if (ballsArray[j].inPocket == false)
                        {
                            if (ballsArray[i].Colliding(ballsArray[j]))
                            {
                                ballsArray[i].ResolveCollision(ballsArray[j]);

                                float impactVel = ballsArray[i].velocity.add(ballsArray[j].velocity).getLength();

                                //this tries to play sound but is messy
                                //ballToBallHitPlayer.Play();

                                //var dingPlayer = new System.Windows.Media.MediaPlayer();
                                //dingPlayer.Open(new Uri(Application.StartupPath + "/Resources/BallToBallHit.wav"));
                                //dingPlayer.Play();
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

            Pen arrowPen = new Pen(Color.FromArgb(255, 150, 70, 0), BALL_RADIUS * 2 / 5);
            Pen shadowPen = new Pen(shadowBrush, BALL_RADIUS * 2 / 5);

            //Draw playground
            e.Graphics.FillRectangle(greenBrush, TABLE_OFFSET, TABLE_OFFSET, this.Width - 2 * TABLE_OFFSET, this.Height - 2 * TABLE_OFFSET);

            //draw borders' shadows
            e.Graphics.DrawLine(shadowPen, BORDER_SIZE + TABLE_OFFSET, this.Height - (BORDER_SIZE + TABLE_OFFSET), this.Width - (BORDER_SIZE + TABLE_OFFSET), this.Height - BORDER_SIZE - TABLE_OFFSET);
            e.Graphics.DrawLine(shadowPen, this.Width - (BORDER_SIZE + TABLE_OFFSET) - 2, BORDER_SIZE + TABLE_OFFSET, this.Width - BORDER_SIZE - TABLE_OFFSET - 2, this.Height - (BORDER_SIZE + TABLE_OFFSET));

            e.Graphics.DrawLine(shadowPen, BORDER_SIZE + TABLE_OFFSET, BORDER_SIZE + TABLE_OFFSET - 1, this.Width - (BORDER_SIZE + TABLE_OFFSET), BORDER_SIZE + TABLE_OFFSET - 1);
            e.Graphics.DrawLine(shadowPen, BORDER_SIZE + TABLE_OFFSET - 1, BORDER_SIZE + TABLE_OFFSET, BORDER_SIZE + TABLE_OFFSET - 1, this.Height - (BORDER_SIZE + TABLE_OFFSET));

            //draw shadows
            for (int i = 0; i < ballsArray.Length; i++)
            {
                if (ballsArray[i].inPocket == false)
                {
                    Ball b = ballsArray[i];
                    e.Graphics.FillEllipse(shadowBrush, b.position.x - 3, b.position.y - 3, b.radius * 2, b.radius * 2);
                }
            }

            //draw borders
            e.Graphics.FillRectangle(borderBrush, TABLE_OFFSET, TABLE_OFFSET, BORDER_SIZE, this.Height - 2 * TABLE_OFFSET);
            e.Graphics.FillRectangle(borderBrush, TABLE_OFFSET, TABLE_OFFSET, this.Width - 2 * TABLE_OFFSET, BORDER_SIZE);
            e.Graphics.FillRectangle(borderBrush, this.Width - BORDER_SIZE - TABLE_OFFSET, TABLE_OFFSET, BORDER_SIZE, this.Height - 2 * TABLE_OFFSET);
            e.Graphics.FillRectangle(borderBrush, TABLE_OFFSET, this.Height - BORDER_SIZE - TABLE_OFFSET, this.Width - 2 * TABLE_OFFSET, BORDER_SIZE);

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

                e.Graphics.DrawLine(shadowPen, cueBallPosition.X - BALL_RADIUS / 15, cueBallPosition.Y - BALL_RADIUS / 15, arrowPosition.X - BALL_RADIUS / 15, arrowPosition.Y - BALL_RADIUS / 15);
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

        public static void LoadHighScoresScreen()
        {
            HighScoresScreen hs = new HighScoresScreen();

            hs.Location = new Point((thisScreen.Width - hs.Width) / 2, (thisScreen.Height - hs.Height) / 2);
            hs.BackColor = Color.FromArgb(80, 128, 128, 128);

            thisScreen.Controls.Add(hs);
            hs.BringToFront();
        }

        public static void LoadPauseScreen()
        {
            PauseScreen ps = new PauseScreen();

            ps.Location = new Point((thisScreen.Width - ps.Width) / 2, (thisScreen.Height - ps.Height) / 2);
            ps.BackColor = Color.FromArgb(80, 128, 128, 128);
            thisScreen.Controls.Add(ps);
        }

        public static void LoadEnterScore()
        {
            EnterScore es = new EnterScore(thisScreen.player1Shots);
            es.Location = new Point((thisScreen.Width - es.Width) / 2, (thisScreen.Height - es.Height) / 2);
            thisScreen.Controls.Add(es);
        }

        public static void LoadThanksScreen()
        {
            ThanksScreen ts = new ThanksScreen();
            ts.Location = new Point((thisScreen.Width - ts.Width) / 2, (thisScreen.Height - ts.Height) / 2);
            thisScreen.Controls.Add(ts);

            ts.Focus();
        }

        public static void RemoveThis(UserControl UC)
        {
            thisScreen.Controls.Remove(UC);
        }

        public static void StartGame(int playersNumber)
        {
            thisScreen.gameTimer.Enabled = true;
            //recall player number
            thisScreen.playerNumber = playersNumber;
            //set/reset values
            thisScreen.InitializeValues();

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


            if (e.KeyCode == Keys.Space)
            {
                enterDown = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                escapeDown = true;
            }

            if (e.KeyCode == Keys.K)
            {
                kDown = true;
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

            if (e.KeyCode == Keys.Space)
            {
                enterDown = false;
            }

            if (e.KeyCode == Keys.Escape)
            {
                escapeDown = false;
            }

            if (e.KeyCode == Keys.K)
            {
                kDown = false;
            }
        }
        #endregion
    }
}