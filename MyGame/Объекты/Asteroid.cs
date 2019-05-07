using System;
using System.Drawing;


namespace MyGame
{
    class Asteroid:BaseObject, IMoveStartPosition
    {
        Random rnd = new Random();
        /// <summary>
        /// Свойство описывающие жизни
        /// </summary>
        public int Power { get; set; }
        /// <summary>
        /// Конструктор класса наследованный  от  BaseObject
        /// </summary>
        /// <param name="pos">Точка, для определения позиции объекта</param>
        /// <param name="dir">Точка, для определения перемещения объекта</param>
        /// <param name="size">Размеры объекта</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
            if (Size.Width < 10 || Size.Height < 10 || Size.Height > 30 || Size.Width > 30) throw new GameObjectException("Неправильные размеры Астеройда");
            if (Dir.X < 1 || Dir.X > 15) throw new GameObjectException("Неправильная скорость Астеройда");
        }
        /// <summary>
        /// Наследованый метод. Рисует объект
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
        }
        /// <summary>
        /// Наследованый метод. Логика движения объекта
        /// </summary>
        public override void Update()
        {
            
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = rnd.Next(0, Game.Height);

            }
        }

        public void MoveStartPosition()
        {
            Pos.X = Game.Width + Size.Width;
            Pos.Y = rnd.Next(0, Game.Height);
        }
    }
}
