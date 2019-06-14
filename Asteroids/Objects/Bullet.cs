using System;
using System.Drawing;

namespace Asteroids.Objects
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            this.Pos.X = this.Pos.X + 35;
            if (this.Pos.X >= Game.GetWidth())
            {
                this.Init();
            }
        }

        public override void Init()
        {
            this.Play();
            Random rnd = new Random();
            this.Pos.X = 0;
            this.Pos.Y = rnd.Next(10, Game.GetHeight() - 10);
        }

        public void Play()
        {
            Game.bul.Open(new Uri(Game.pathToFileBul));
            Game.bul.Play();
        }
    }
}
