using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Bullet : BaseObject, IMoveStartPosition
    {
        Random rnd = new Random();

        /// <summary>
        /// Конструктор класса наследованный  от  BaseObject
        /// </summary>
        /// <param name="pos">Точка, для определения позиции объекта</param>
        /// <param name="dir">Точка, для определения перемещения объекта</param>
        /// <param name="size">Размеры объекта</param>
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            if (Size.Width < 5 || Size.Height < 1 || Size.Height > 4 || Size.Width > 10) throw new GameObjectException("Неправильные размеры Пули");
            if (Dir.X < 5 || Dir.X > 10) throw new GameObjectException("Неправильная скорость Пули");
        }

        /// <summary>
        /// НАследованый метод. Рисует объект
        /// </summary
        public override void Draw()
        {
            Game.Buffer.Graphics.FillRectangle(Brushes.OrangeRed, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
            //Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Логика движение объекта
        /// </summary>
        public override void Update()
        {
            
            Pos.X = Pos.X + 5;
            if (Pos.X > Game.Width)
            {
                Pos.X = 0;
               Pos.Y = rnd.Next(Size.Height, Game.Height);
            }
        }

        public void MoveStartPosition()
        {
            Pos.X = Game.Width + Size.Width;
            Pos.Y = rnd.Next(0, Game.Height);
        }
    }

}
