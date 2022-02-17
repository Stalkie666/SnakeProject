using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_CSharp
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        int maxWidth;
        int maxHeight;

        int score;
        int hightScore;

        Random rand = new Random();

        bool goLeft, goRight, goDown, goUp;


        public Form1()
        {
            InitializeComponent();

            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.direction != "right")
            {
                goLeft = true;
            }
            else if(e.KeyCode == Keys.Right && Settings.direction != "left")
            {
                goRight = true;
            }
            else if(e.KeyCode == Keys.Up && Settings.direction != "down")
            {
                goUp = true;
            }
            else if(e.KeyCode == Keys.Down && Settings.direction != "up")
            {
                goDown = true;
            }
            else
            {
                //do nothing
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

        }

        private void btnStartGame(object sender, EventArgs e)
        {

        }

        private void takeSnapShot(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {

        }

        private void UpdatePictureBoxGraphic(object sender, PaintEventArgs e)
        {

        }


        //custom functions
        private void RestartGame()
        {

        }

        private void EatFood()
        {

        }

        private void GameOver()
        {

        }
    }
}
