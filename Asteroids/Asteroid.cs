using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Media;

namespace Asteroids
{
    /// <summary>
     /// Объект игры Астероид
     /// </summary>
    class Asteroid : BaseObject
    {

        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        /// <summary>
        /// Содержит картинку объекта
        /// </summary>
        public Bitmap Image { get; private set; }
        
        /// <summary>
        /// Содержит текущий тип картинки
        /// </summary>
        public int ObjType { get; private set; }

        /// <summary>
        /// Хранит разные реализации картинок объектов из ресурсов
        /// </summary>
        internal static Dictionary<int, Image> ObjTypes = new Dictionary<int, Image>();

        /// <summary>
        /// статический конструктор для наполнения словаря для всех экземпляров
        /// </summary>
        static Asteroid()
        {
            ObjTypes.Add(1, Properties.Resources.Asteroid1);
            ObjTypes.Add(2, Properties.Resources.Asteroid2);
            ObjTypes.Add(3, Properties.Resources.Asteroid3);
            ObjTypes.Add(4, Properties.Resources.Asteroid4);
            ObjTypes.Add(5, Properties.Resources.Asteroid5);
            ObjTypes.Add(6, Properties.Resources.Asteroid6);
        }

        /// <summary>
        /// Экземплярный конструктор
        /// </summary>
        /// <param name="pos">Положение на поле</param>
        /// <param name="dir">дельта перемещения</param>
        /// <param name="size">Размер</param>
        public Asteroid(Point pos, Point dir, Size size, int type) : base(pos, dir, size)
        {
            this.Image = new Bitmap(ObjTypes.ElementAt(type).Value);
        }


        /// <summary>
        /// Перекрытый метод отрисовки
        /// </summary>
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(this.Image, this.Pos.X, this.Pos.Y, this.Size.Width, this.Size.Height);
        }

        /// <summary>
        /// Перекрытый метод обновления 
        /// </summary>
        public override void Update()
        {
            this.Pos.X -= this.Dir.X;
            if (this.Pos.X + this.Size.Width <= 0)
            {
                this.Init();
            }
        }

        /// <summary>
        /// Перекрытый метод инициализации
        /// </summary>
        public override void Init()
        {
            Random rnd = new Random();
            this.Pos.X = Game.GetWidth();
            this.Pos.Y = rnd.Next(this.Size.Height, Game.GetHeight() - this.Size.Height);
            this.ObjType = rnd.Next(1, ObjTypes.Count);
            this.Image = (Bitmap)ObjTypes.ElementAt(this.ObjType).Value;
        }

        /// <summary>
        /// Воспроизводит звук взрыва
        /// </summary>
        public void Play()
        {
            Game.aster.Open(new Uri(Game.pathToFileAster));
            Game.aster.Play();
        }
    }
}
