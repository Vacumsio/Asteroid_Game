using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Asteroids.Objects
{
    /// <summary>
    /// Объект игры Планеты
    /// </summary>
    class Planets : BaseObject
    {
        /// <summary>
        /// Содержит картинку объекта
        /// </summary>
        public Bitmap Image { get; private set; }

        /// <summary>
        /// Пока не понятно для чего это свойство в классе!
        /// </summary>
        public int Power { get; set; }

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
        static Planets()
        {
            ObjTypes.Add(1, Properties.Resource1.planet1);
            ObjTypes.Add(2, Properties.Resource1.planet2);
        }

        /// <summary>
        /// Экземплярный конструктор
        /// </summary>
        /// <param name="pos">Положение на поле</param>
        /// <param name="dir">дельта перемещения</param>
        /// <param name="size">Размер</param>
        public Planets(Point pos, Point dir, Size size, int type) : base(pos, dir, size)
        {
            this.Power = 1000000;
            this.Image = new Bitmap(ObjTypes.ElementAt(type).Value);
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
