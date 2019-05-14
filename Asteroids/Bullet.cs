using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Сняряд
    /// </summary>
    class Bullet : BaseObject, ICollision
    {
        /// <summary>
        /// Экземплярный конструктор
        /// </summary>
        /// <param name="pos">Положение на поле</param>
        /// <param name="dir">Дельта перемещения</param>
        /// <param name="size">Размер</param>
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            this.Init();
        }

        /// <summary>
        /// Перекрытый метод отрисовки
        /// </summary>
        public override void Draw()
        {
            Game.buffer.Graphics.DrawRectangle(Pens.OrangeRed, this.Pos.X, this.Pos.Y, this.Size.Width, this.Size.Height);
        }

        /// <summary>
        /// Перекрытый метод обновления
        /// </summary>
        public override void Update()
        {
            this.Pos.X = this.Pos.X + 15;
            if (this.Pos.X >= Game.GetWidth())
            {
                this.Init();
            }
        }

        /// <summary>
        /// Устанавливает новое положение объекта
        /// </summary>
        public override void Init()
        {
            Random rnd = new Random();
            this.Pos.X = 0;
            this.Pos.Y = rnd.Next(10, Game.GetHeight() - 10);
            this.Play();
        }

        /// <summary>
        /// Воспроизводит звук выстрела
        /// </summary>
        public void Play()
        {
            Game.bul.Open(new Uri(Game.pathToFileBul));
            Game.bul.Play();
        }
    }
}
