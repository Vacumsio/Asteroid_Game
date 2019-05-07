using System;
using System.Drawing;

namespace MyGame
{
    abstract class BaseObject : ICollision
    {

        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="pos">Точка, для определения позиции объекта</param>
        /// <param name="dir">Точка, для определения перемещения объекта</param>
        /// <param name="size">Размеры объекта</param>
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            
        }



        /// <summary>
        /// Абстактный метод для рисования объекта
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Логика движение объекта
        /// </summary>
        public abstract void Update();


        public Rectangle Rect => new Rectangle(Pos, Size);
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
  
       
    }
}
