using System;
using System.Drawing;

namespace MyGame
{
    class Star:BaseObject
    {
        public Star(Point pos, Point dir, Size size):base(pos, dir, size)
        {
            if (Size.Width < 3 || Size.Height < 3 || Size.Height > 3|| Size.Width > 3) throw new GameObjectException("Неправильные размеры Астеройда");
            if (Dir.X < 5 || Dir.X > 50) throw new GameObjectException("Неправильная скорость Астеройда");

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
