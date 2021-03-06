﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingGame
{
    public class Ball
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Dx { get; set; }
        public int Dy { get; set; }
        public PictureBox Picture { get; set; } = new PictureBox();

        public Ball(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;

            InitializeBall();
        }

        public void InitializeBall()
        {
            Picture.Image = Properties.Resources.Ball_PNG;
            Picture.SizeMode = PictureBoxSizeMode.Zoom;
            Picture.Size = new Size(50, 50);
            Picture.Dock = DockStyle.None;
            Picture.Visible = true;

            Dx = 1;
            Dy = 1;
        }

        public void MoveOneStep()
        {
            if (Dx == 1)
                X++;
            if (Dx == -1)
                X--;
            if (Dy == 1)
                Y++;
            if (Dy == -1)
                Y--;
        }

        public override string ToString()
        {
            return $"X: {X}-{X+50}, Y: {Y}-{Y+50}";
        }
    }
}
