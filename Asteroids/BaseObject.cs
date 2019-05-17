using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Делегат
    /// </summary>
    public delegate void Message();
    /// <summary>
    /// Базовый абстрактный класс для всех графических елементов
    /// </summary>
    abstract class BaseObject : ICollision
    {
        /// <summary>
        /// Содержит положение объекта на поле
        /// </summary>
        protected Point Pos;

        /// <summary>
        /// Содержит размер объекта
        /// </summary>
        protected Size Size;

        /// <summary>
        /// Содержит дельту перемежения объекта
        /// </summary>
        protected Point Dir;

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        /// <param name="pos">Положение на поле</param>
        /// <param name="dir">Дельта перемещения</param>
        /// <param name="size">Размер</param>
        /// <exception cref="GameObjectException"></exception>
        public BaseObject(Point pos, Point dir, Size size)
        {
            
            if (pos.X < 0 || pos.X > Game.GetWidth()) throw new GameObjectException(this.GetType().ToString()+"\nНедопустимое положение по оси Х");
            if (pos.Y < 0 || pos.Y > Game.GetHeight()) throw new GameObjectException(this.GetType().ToString() + "\nНедопустимое положение по оси Y");
            if (dir.X > 30) throw new GameObjectException(this.GetType().ToString() + "\nНедопустимая скорость по оси Х");
            if (dir.Y > 30) throw new GameObjectException(this.GetType().ToString() + "\nНедопустимая скорость по оси Y");
            if (size.Width <= 0 || size.Height <= 0) throw new GameObjectException(this.GetType().ToString() + "\nРазмер элемента <= 0");
            if (size.Width > 100 || size.Height > 100) throw new GameObjectException(this.GetType().ToString() + "\nСлишком большой размер элемента");

            this.Pos = pos;
            this.Dir = dir;
            this.Size = size;
        }

        /// <summary>
        /// Базовый абстрактный метод отрисовки в буфер
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Базовый метод обновления
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Базовый метод инициализации
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// Проверяет на предмет столкновения
        /// </summary>
        /// <param name="o">объект с интерфейсом ICollision</param>
        /// <returns><see langword="true"/>При определении столкновения</returns>
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);

        /// <summary>
        /// Прямоугольная область для определения столкновеения
        /// </summary>
        public Rectangle Rect => new Rectangle(this.Pos, this.Size);
    }
}
