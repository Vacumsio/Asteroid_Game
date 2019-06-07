﻿using System;
using System.Drawing;

namespace Asteroids.Objects
{
    class Asteroid : BaseObject
    {
        public int Power { get; set; }
        public Image _img;
        public Random rnd;
        string[] _imgages = new string[]
        {
            "asteroids/asteroid1.png",
            "asteroids/asteroid2.png",
            "asteroids/asteroid3.png",
            "asteroids/asteroid4.png",
            "asteroids/asteroid5.png"
        };

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
            rnd = new Random();
            _img = Image.FromFile(_imgages[rnd.Next(0, _imgages.Length - 1)]);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_img, this.Pos);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.GetWidth() + Size.Width;
        }
    }
}