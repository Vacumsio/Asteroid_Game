﻿using System.Drawing;

namespace Asteroids
{
    class Ship : BaseObject
    {
        private int _energy = 100;
        public int Energy => _energy;

        public static event Message MessageDie;


        public void EnergyLow(int n)
        {
            _energy -= n;
        }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
        }

        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y < Game.GetHeight()) Pos.Y = Pos.Y + Dir.Y;
        }

        public void Die()
        {
            MessageDie?.Invoke();
        }

        public override void Init()
        {
            this.Pos.X = 0;
            this.Pos.Y = 0;
        }

    }
}
