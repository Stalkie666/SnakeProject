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

        bool    goLeft = false,
                goRight = false, 
                goDown = false, 
                goUp = false;


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
            if (e.KeyCode == Keys.Left )
            {
                goLeft = false;
            }
            else if (e.KeyCode == Keys.Right )
            {
                goRight = false;
            }
            else if (e.KeyCode == Keys.Up )
            {
                goUp = false;
            }
            else if (e.KeyCode == Keys.Down )
            {
                goDown = false;
            }
            else
            {
                //do nothing
            }
        }

        private void btnStartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void takeSnapShot(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            //setting direction
            if (goLeft)
            {
                Settings.direction = "left";
            }
            if (goRight)
            {
                Settings.direction = "right";
            }
            if (goUp)
            {
                Settings.direction = "up";
            }
            if (goDown)
            {
                Settings.direction = "down";
            }


            for(int i = Snake.Count; i >= 0; --i)
            {
                if(i == 0)
                {
                    switch (Settings.direction)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                    }
                }

                if(Snake[i].X < 0)
                {
                    Snake[i].X = maxWidth;
                }
                if(Snake[i].X > maxWidth)
                {
                    Snake[i].X = 0;
                }

                if (Snake[i].Y < 0)
                {
                    Snake[i].Y = maxHeight;
                }
                if (Snake[i].Y > maxHeight)
                {
                    Snake[i].Y = 0;
                }

            }

        }

        private void UpdatePictureBoxGraphic(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColor;

            for(int i = 0; i < Snake.Count; ++i)
            {
                if(i == 0)
                {
                    snakeColor = Brushes.Black;
                }
                else
                {
                    snakeColor = Brushes.DarkGreen;
                }

                canvas.FillEllipse( snakeColor, 
                                    new Rectangle(  Snake[i].X * Settings.Width,
                                                    Snake[i].Y  * Settings.Height,
                                                    Settings.Width,Settings.Height
                                                )
                                    );
            }

            canvas.FillEllipse( Brushes.DarkRed,
                                new Rectangle(  food[i].X * Settings.Width,
                                                food[i].Y * Settings.Height,
                                                Settings.Width, Settings.Height
                                                )
                             );




        }


        //custom functions
        private void RestartGame()
        {
            maxWidth = picCanvas.Width / Settings.Width - 1;
            maxHeight = picCanvas.Height / Settings.Height - 1;

            Snake.Clear();

            btnStart.Enabled = false;
            btnSnap.Enabled = false;

            score = 0;

            txtScore.Text = "Score: " + score;

            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head); // snakes' head is first on the list

            for(int i = 0; i < 10; ++i)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

            gameTimer.Start();

        }

        private void EatFood()
        {

        }

        private void GameOver()
        {

        }
    }
}
