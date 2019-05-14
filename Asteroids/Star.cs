using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Класс векторных графических звезд 
    /// </summary>
    class Star : BaseObject
    {
        /// <summary>
        /// Экземплярный конструктор
        /// </summary>
        /// <param name="pos">Координаты</param>
        /// <param name="dir">Дельта перемещения</param>
        /// <param name="size">Размер</param>
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        /// <summary>
        /// Перегруженный метод отрисовки
        /// </summary>
        public override void Draw()
        {
            Game.buffer.Graphics.FillEllipse(Brushes.CornflowerBlue, this.Pos.X, this.Pos.Y, this.Size.Width, this.Size.Height);
        }


        public override void Update()
        {
            this.Pos.X -= this.Dir.X;
            if (this.Pos.X + this.Size.Width <= 0)
            {
                this.Init();
            }
        }

        public override void Init()
        {
            Random rnd = new Random();
            this.Pos.X = Game.GetWidth();
            this.Pos.Y = rnd.Next(Game.GetHeight() - this.Size.Height);
        }
    }
}
