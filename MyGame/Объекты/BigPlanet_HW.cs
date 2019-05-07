using System;
using System.Drawing;
//Резяпкин владимир

namespace MyGame
{
    class BigPlanet_HW : BaseObject
    {
        Random rnd = new Random();

        public BigPlanet_HW(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            if (Size.Width < 20 || Size.Height < 20 || Size.Height > 100 || Size.Width > 100) throw new GameObjectException("Неправильные размеры Астеройда");
            if (Dir.X < 5 || Dir.X > 50) throw new GameObjectException("Неправильная скорость Астеройда");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Blue, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
            
        }
        public override void Update()
        {
            

            Pos.X = Pos.X - Dir.X;
            if (Pos.X < (-Size.Width))
            {
                int randSize = rnd.Next(20, 100);
                Pos.X = Game.Width + Size.Width;
                Pos.Y = rnd.Next(Size.Height / 2, Game.Height - (Size.Height / 2));
                Size.Width = randSize;
                Size.Height = randSize;
            }
        }

    }
}
