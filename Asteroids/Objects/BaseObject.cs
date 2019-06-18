using System.Drawing;

namespace Asteroids.Objects
{
    abstract class BaseObject : ICollision
    {
        public Point Pos;
        public Point Dir;
        public Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            if (pos.X < 0 || pos.X > Game.GetWidth()) throw new BaseObjectEx(this.GetType().ToString() + "\nНедопустимое положение по оси Х");
            if (pos.Y < 0 || pos.Y > Game.GetHeight()) throw new BaseObjectEx(this.GetType().ToString() + "\nНедопустимое положение по оси Y");
            if (dir.X > 60) throw new BaseObjectEx(this.GetType().ToString() + "\nНедопустимая скорость по оси Х");
            if (dir.Y > 60) throw new BaseObjectEx(this.GetType().ToString() + "\nНедопустимая скорость по оси Y");
            if (size.Width < 0 || size.Height < 0) throw new BaseObjectEx(this.GetType().ToString() + "\nРазмер элемента < 0");
            if (size.Width > 300 || size.Height > 300) throw new BaseObjectEx(this.GetType().ToString() + "\nСлишком большой размер элемента");

            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();

        public abstract void Update();

        public abstract void Init();

        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);

        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}
