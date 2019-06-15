using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PoolOne
{
    public partial class HighScoresScreen : UserControl
    {
        List<HighScore> highScoresList = new List<HighScore>();

        public HighScoresScreen()
        {
            InitializeComponent();
        }

        private void backToMenuButton_Click(object sender, EventArgs e)
        {
            GameScreen.RemoveHighScoresScreen(this);
            GameScreen.LoadMenuScreen();
        }

        private void backToMenuButton_Enter(object sender, EventArgs e)
        {
            backToMenuButton.ForeColor = Color.Red;
            backToMenuButton.FlatAppearance.BorderSize = 2;
        }

        private void backToMenuButton_Leave(object sender, EventArgs e)
        {
            backToMenuButton.ForeColor = Color.Black;
            backToMenuButton.FlatAppearance.BorderSize = 0;
        }

        private void HighScoresScreen_Load(object sender, EventArgs e)
        {
            backToMenuButton.Focus();

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

            testLabel.Text = "" + highScoresList[2].name;
            //here you put everything in the right place
        }
    }
}
