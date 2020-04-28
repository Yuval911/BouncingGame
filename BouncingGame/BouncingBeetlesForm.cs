using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingGame
{
    public partial class BouncingBeetlesForm : Form
    {
        public List<Beetle> Beetles { get; set; } = new List<Beetle>();

        CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken cancelToken;

        public BouncingBeetlesForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            StartGame();
        }

        /// <summary>
        /// Initializes the game and starts it.
        /// </summary>
        private void StartGame()
        {
            MessageBox.Show("Welcome to the bouncing beetles game! Kill all the beetles (by clicking on them) to win the game.");

            Beetles.Clear();

            for (int i = 1; i <= 5; i++)
                AddNewBeetle();

            cancelToken = tokenSource.Token;

            Task.Run(() =>
            {
                while (true)
                {
                    MakeGameStep();
                    Thread.Sleep(5);
                    cancelToken.ThrowIfCancellationRequested();
                }

            }, cancelToken);

            Task.Run(() =>
            {
                while (true)
                {
                    RenewBeetles();
                }
            }, cancelToken);
        }

        /// <summary>
        /// Adds new beetle to the screen.
        /// </summary>
        private void AddNewBeetle()
        {
            Beetle beetle = new Beetle(GetClearedPoint());

            beetle.Picture.Location = new Point(beetle.X, beetle.Y);
            beetle.Picture.Click += new EventHandler(beetle_Click);

            Controls.Add(beetle.Picture);
            Beetles.Add(beetle);          
        }

        /// <summary>
        /// Returns a Point on the screen which doesn't contain another beetle.
        /// </summary>
        private Point GetClearedPoint()
        {
            Random random = new Random();
            Point point = new Point();

            do
            {
                point = new Point(random.Next(5, 700), random.Next(5, 400));
            }
            while (!CheckPoint(point));

            return point;
        }

        /// <summary>
        /// Checks if the point is clear of any other beetles or not.
        /// </summary>
        private bool CheckPoint(Point point)
        {
            foreach (Beetle beetle in Beetles)
            {
                //Checks if the given point is "inside" an existing ball

                if (point.X > beetle.X - 50 && point.X < beetle.X + 50)
                    if (point.Y > beetle.Y - 50 && point.Y < beetle.Y + 50)
                        return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the given beetle has collided with another, and returns the collision type.
        /// </summary>
        private Collision CheckCollision(Beetle beetle)
        {
            if (beetle.X < 2)
                return Collision.Left;
            if (beetle.X > 735)
                return Collision.Right;
            if (beetle.Y < 2)
                return Collision.Up;
            if (beetle.Y > 412)
                return Collision.Down;


            foreach (Beetle beetle2 in Beetles)
            {
                // can be possible only if 'beetle' and 'beetle2' are the same ball.
                if (beetle.X == beetle2.X && beetle.Y == beetle2.Y)
                    continue;

                if (beetle.X + 50 > beetle2.X && beetle.X + 50 < beetle2.X + 25 && beetle.Y == beetle2.Y)
                {
                    return Collision.Right;
                }

                if (beetle.X < beetle2.X + 50 && beetle.X > beetle2.X + 25 && beetle.Y == beetle2.Y)
                {
                    return Collision.Left;
                }

                if ((beetle.X + 50 > beetle2.X && beetle.X + 50 < beetle2.X + 25) && (beetle.Y + 50 > beetle2.Y && beetle.Y + 50 < beetle2.Y + 50))
                {
                    return Collision.RightDown;
                }

                if ((beetle.X + 50 > beetle2.X && beetle.X + 50 < beetle2.X + 25) && (beetle.Y >= beetle2.Y && beetle.Y < beetle2.Y + 50))
                {
                    return Collision.RightUp;
                }

                if ((beetle.X < beetle2.X + 50 && beetle.X >= beetle2.X + 25) && (beetle.Y + 50 > beetle2.Y && beetle.Y + 50 < beetle2.Y + 50))
                {
                    return Collision.LeftDown;
                }
                if ((beetle.X < beetle2.X + 50 && beetle.X >= beetle2.X + 25) && (beetle.Y >= beetle2.Y && beetle.Y < beetle2.Y + 50))
                {
                    return Collision.LeftUp;
                }
            }

            return Collision.NoCollision;
        }

        /// <summary>
        /// Runs on loop to animate the balls on the screen and make them interact.
        /// </summary>
        private void MakeGameStep()
        {
            foreach (Beetle beetle in Beetles)
            {
                if (beetle.isDead)
                    continue;

                Collision collision = CheckCollision(beetle);
                switch (collision)
                {
                    case Collision.Left:
                        beetle.Dx = 1;
                        break;
                    case Collision.LeftUp:
                        beetle.Dx = 1;
                        beetle.Dy = 1;
                        break;
                    case Collision.Up:
                        beetle.Dy = 1;
                        break;
                    case Collision.RightUp:
                        beetle.Dx = -1;
                        beetle.Dy = 1;
                        break;
                    case Collision.Right:
                        beetle.Dx = -1;
                        break;
                    case Collision.RightDown:
                        beetle.Dx = -1;
                        beetle.Dy = -1;
                        break;
                    case Collision.Down:
                        beetle.Dy = -1;
                        break;
                    case Collision.LeftDown:
                        beetle.Dx = 1;
                        beetle.Dy = -1;
                        break;
                }
            }

            foreach (Beetle beetle in Beetles)
            {
                if (beetle.isDead)
                    continue;

                beetle.MoveOneStep();
                Action action = () => beetle.Picture.Location = new Point(beetle.X, beetle.Y);
                this.BeginInvoke(action);
            }

            if (Beetles.Count == 0)
            {
                tokenSource.Cancel();
                MessageBox.Show("You Won!");
                this.Dispose();
            }
        }

        /// <summary>
        /// Adds new beetles every few seconds, to make the game challenging :)
        /// </summary>
        private void RenewBeetles()
        {
            if (Beetles.Count <= 3 )
            {
                Thread.Sleep(new Random().Next(1500, 3000));
                cancelToken.ThrowIfCancellationRequested();
                Action action = () => AddNewBeetle();
                BeginInvoke(action);
            }
        }

        /// <summary>
        /// Makes the beetle crush after clicking it
        /// </summary>
        private void BeetleExplode(Beetle beetle)
        {
            beetle.isDead = true;

            Action action = () => { beetle.Picture.Image = Properties.Resources.dead_beetle; };
            BeginInvoke(action);

            Thread.Sleep(400);

            action = () => {
                beetle.Picture.Dispose();
                Beetles.Remove(beetle);
            };
            BeginInvoke(action);
        }

        private void beetle_Click(object sender, EventArgs e)
        {
            Beetle hittedBeetle = new Beetle(new Point());

            foreach(Beetle beetle in Beetles)
            {
                if (beetle.Picture.Name == (sender as PictureBox).Name)
                {
                    hittedBeetle = beetle;
                    break;
                }
            }

            Task.Run(() => BeetleExplode(hittedBeetle));
        }

        private void exitGameButton_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
            this.Dispose();
        }
    }
}
