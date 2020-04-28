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
    public partial class BouncingBallsForm : Form
    {
        public List<Ball> Balls { get; set; } = new List<Ball>();

        public BouncingBallsForm()
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
            Balls.Clear();

            AddNewBall();

            Task.Run(() =>
            {
                while (true)
                {
                    MakeGameStep();
                    Thread.Sleep(5);
                }

            });
        }

        /// <summary>
        /// Adds new ball to the screen.
        /// </summary>
        private void AddNewBall()
        {
            Ball ball = new Ball(GetClearedPoint());

            ball.Picture.Location = new Point(ball.X, ball.Y);

            Controls.Add(ball.Picture);
            Balls.Add(ball);
        }

        /// <summary>
        /// Returns a Point on the screen which doesn't contain another ball.
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
        /// Checks if the point is clear of any other balls or not.
        /// </summary>
        private bool CheckPoint(Point point)
        {
            foreach(Ball ball in Balls)
            {
                //Checks if the given point is "inside" an existing ball

                if (point.X > ball.X - 50 && point.X < ball.X + 50)
                    if (point.Y > ball.Y - 50 && point.Y < ball.Y + 50)
                        return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the given ball has collided with another, and returns the collision type.
        /// </summary>
        private Collision CheckCollision(Ball ball)
        {
            if (ball.X < 2)
                return Collision.Left;
            if (ball.X > 735)
                return Collision.Right;
            if (ball.Y < 2)
                return Collision.Up;
            if (ball.Y > 412)
                return Collision.Down;

            foreach(Ball ball2 in Balls)
            {
                // can be possible only if 'ball' and 'ball2' are the same ball.
                if (ball.X == ball2.X && ball.Y == ball2.Y)
                    continue;

                if (ball.X + 50 > ball2.X && ball.X + 50 < ball2.X + 25 && ball.Y == ball2.Y)
                {
                    return Collision.Right;
                }

                if (ball.X < ball2.X + 50 && ball.X > ball2.X + 25 && ball.Y == ball2.Y)
                {
                    return Collision.Left;
                }

                if ((ball.X + 50 > ball2.X && ball.X + 50 < ball2.X + 25) && (ball.Y + 50 > ball2.Y && ball.Y + 50 < ball2.Y + 50))
                {
                    return Collision.RightDown;
                }

                if ((ball.X + 50 > ball2.X && ball.X + 50 < ball2.X + 25) && (ball.Y >= ball2.Y && ball.Y < ball2.Y + 50))
                {
                    return Collision.RightUp;
                }

                if ((ball.X < ball2.X + 50 && ball.X >= ball2.X + 25) && (ball.Y + 50 > ball2.Y && ball.Y + 50 < ball2.Y + 50))
                {
                    return Collision.LeftDown;
                }
                if ((ball.X < ball2.X + 50 && ball.X >= ball2.X + 25) && (ball.Y >= ball2.Y && ball.Y < ball2.Y + 50))
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
            foreach (Ball ball in Balls)
            {
                Collision collision = CheckCollision(ball);
                switch (collision)
                {
                    case Collision.Left:
                        ball.Dx = 1;
                        break;
                    case Collision.LeftUp:
                        ball.Dx = 1;
                        ball.Dy = 1;
                        break;
                    case Collision.Up:
                        ball.Dy = 1;
                        break;
                    case Collision.RightUp:
                        ball.Dx = -1;
                        ball.Dy = 1;
                        break;
                    case Collision.Right:
                        ball.Dx = -1;
                        break;
                    case Collision.RightDown:
                        ball.Dx = -1;
                        ball.Dy = -1;
                        break;
                    case Collision.Down:
                        ball.Dy = -1;
                        break;
                    case Collision.LeftDown:
                        ball.Dx = 1;
                        ball.Dy = -1;
                        break;
                }
            }

            foreach (Ball ball in Balls)
            {
                ball.MoveOneStep();
                Action action = () => ball.Picture.Location = new Point(ball.X, ball.Y);
                this.BeginInvoke(action);
            }
        }

        //Buttons:

        private void exitGameButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void addBallButton_Click(object sender, EventArgs e)
        {
            AddNewBall();
        }

    }

    enum Collision
    {
        NoCollision,
        Left,
        LeftUp,
        Up,
        RightUp,
        Right,
        RightDown,
        Down,
        LeftDown
    }
}
