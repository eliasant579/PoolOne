using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace PoolOne
{
    public partial class EnterScore : UserControl
    {
        int currentIndex;
        int charSelect = 1;
        Label[] labels = new Label[30];
        
        string newName = "";
        int newScore;
        DateTime newDateTime;

        Color textColor, formColor;

        public EnterScore(int _newScore, Color _textColor, Color _formColor, Color _titleColor)
        {
            InitializeComponent();

            newScore = _newScore;
            textColor = _textColor;
            formColor = _formColor;

            newDateTime = DateTime.Now;


            #region place buttons in List

            currentIndex = 0;
            labels[0] = aChar;
            labels[1] = bChar;
            labels[2] = cChar;
            labels[3] = dChar;
            labels[4] = eChar;
            labels[5] = fChar;
            labels[6] = gChar;
            labels[7] = hChar;
            labels[8] = iChar;
            labels[9] = jChar;
            labels[10] = kChar;
            labels[11] = lChar;
            labels[12] = mChar;
            labels[13] = nChar;
            labels[14] = oChar;
            labels[15] = pChar;
            labels[16] = qChar;
            labels[17] = rChar;
            labels[18] = sChar;
            labels[19] = tChar;
            labels[20] = uChar;
            labels[21] = vChar;
            labels[22] = wChar;
            labels[23] = xChar;
            labels[24] = yChar;
            labels[25] = zChar;
            labels[26] = extraChar;
            labels[27] = extra2Char;
            labels[28] = extra3Char;
            labels[29] = extra4Char;

            #endregion

            #region set colors

            for (int i = 0; i < labels.Count(); i++)
            {
                labels[i].BackColor = formColor;
                labels[i].ForeColor = textColor;
            }

            nameChar1.BackColor = formColor;
            nameChar2.BackColor = formColor;
            nameChar3.BackColor = formColor;

            nameChar1.ForeColor = textColor;
            nameChar2.ForeColor = textColor;
            nameChar3.ForeColor = textColor;

            scoreLabel.ForeColor = _titleColor;
            enterLabel.ForeColor = _titleColor;

            this.BackColor = formColor;

            currentIndex = 0;
            labels[currentIndex].BackColor = textColor;
            labels[currentIndex].ForeColor = formColor;

            #endregion

            this.Focus();
        }

        private void EnterScore_KeyUp(object sender, KeyEventArgs e)
        {
            if (newName.Length < 3)
            {
                labels[currentIndex].BackColor = formColor;
                labels[currentIndex].ForeColor = textColor;

                #region set active button or select letter

                switch (e.KeyCode)
                {
                    case Keys.Down:
                        if (currentIndex > 19)
                        {
                            currentIndex -= 20;
                        }
                        else
                        {
                            currentIndex += 10;
                        }
                        break;
                    case Keys.Up:
                        if (currentIndex < 10)
                        {
                            currentIndex += 20;
                        }
                        else
                        {
                            currentIndex -= 10;
                        }
                        break;
                    case Keys.Right:
                        if (currentIndex == 9 || currentIndex == 19 || currentIndex == 29)
                        {
                            currentIndex -= 9;
                        }
                        else
                        {
                            currentIndex++;
                        }
                        break;
                    case Keys.Left:
                        if (currentIndex == 0 || currentIndex == 10 || currentIndex == 20)
                        {
                            currentIndex += 9;
                        }
                        else
                        {
                            currentIndex--;
                        }
                        break;
                    case Keys.Space:
                        if (charSelect == 1)
                        {
                            nameChar1.Text = labels[currentIndex].Text;
                            newName += labels[currentIndex].Text;
                            charSelect++;
                        }
                        else if (charSelect == 2)
                        {
                            nameChar2.Text = labels[currentIndex].Text;
                            newName += labels[currentIndex].Text;
                            charSelect++;
                        }
                        else
                        {
                            nameChar3.Text = labels[currentIndex].Text;
                            newName += labels[currentIndex].Text;
                            //Close();
                        }
                        break;
                    default:
                        break;
                }

                #endregion

                labels[currentIndex].BackColor = textColor;
                labels[currentIndex].ForeColor = formColor;
            }
            else
            {
                GameScreen.RemoveThis(this);
                GameScreen.LoadMenuScreen();
            }
        }

        private void EnterScore_Paint(object sender, PaintEventArgs e)
        {
            Pen drawPen = new Pen(textColor, 2);
            e.Graphics.DrawRectangle(drawPen, 5, 5, this.Width - 10, this.Height - 10);

            if (newName.Length >= 3)
            {
                //Thanks for playing, your score has been stored! Press any key to go back to menu.
            }
        }

        private void EnterScore_Enter(object sender, EventArgs e)
        {

        }

        private void EnterScore_Leave(object sender, EventArgs e)
        {
            XmlWriter writer = XmlWriter.Create("Resources/highScores.xml");
            //Write the root element 
            writer.WriteStartElement("Highscores");
            //Start an element 
            writer.WriteStartElement("Highscore");
            //Write sub-elements 
            writer.WriteElementString("name", newName);
            writer.WriteElementString("shots", newScore.ToString());
            writer.WriteElementString("dateTime", newDateTime.ToString());
            // end the element 
            writer.WriteEndElement();
            // end the root element 
            writer.WriteEndElement();
            //Write the XML to file and close the writer 
            writer.Close();
        }

        private void EnterScore_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
