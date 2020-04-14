using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Asteroids.Objects
{
    class Aids: BaseObject
    {

        /// <summary>
        /// Содержит картинку объекта
        /// </summary>
        public Bitmap Image { get; private set; }

        /// <summary>
        /// Здоровье
        /// </summary>
        public int Struct { get; private set; } = 5;

        /// <summary>
        /// Содержит текущую тип картинки
        /// </summary>
        public int ObjType { get; private set; }

        /// <summary>
        /// Хранит разные реализации картинок объектов из ресурсов
        /// </summary>
        internal static Dictionary<int, Image> ObjTypes = new Dictionary<int, Image>();

        /// <summary>
        /// статический конструктор для наполнения словаря для всех экземпляров
        /// </summary>
        static Aids()
        {
            ObjTypes.Add(1, Properties.Resource1.Health);
        }

        /// <summary>
        /// Экземплярный конструктор
        /// </summary>
        /// <param name="pos">Положение на поле</param>
        /// <param name="dir">дельта перемещения</param>
        /// <param name="size">Размер</param>
        public Aids(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            this.Image = new Bitmap(ObjTypes.ElementAt(0).Value);
        }

        /// <summary>
        /// Перекрытый метод отрисовки
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(this.Image, this.Pos.X, this.Pos.Y, this.Size.Width, this.Size.Height);
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
            this.ObjType = rnd.Next(1);
            this.Image = (Bitmap)ObjTypes.ElementAt(this.ObjType).Value;
        }

        public void Play()
        {
            Game.aster.Open(new Uri(Game.pathToHeal));
            Game.aster.Play();
        }

        public void Dispose()
        {

        }
    }
}
