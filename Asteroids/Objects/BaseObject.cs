using System.Drawing;

namespace Asteroids
{
    abstract class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();

        public virtual void Update()
        {
            Pos.X = Pos.X - Dir.X*2;

            if (Pos.X < 0)
                Pos.X = Game.GetWidth() + Size.Width;

            //Pos.X = Pos.X + Dir.X;
            //Pos.Y = Pos.Y + Dir.Y;
            //if (Pos.X < 0) Dir.X = -Dir.X;
            //if (Pos.X > Game.Width) Dir.X = -Dir.X;
            //if (Pos.Y < 0) Dir.Y = -Dir.Y;
            //if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}
