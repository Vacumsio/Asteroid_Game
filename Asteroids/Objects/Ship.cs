using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Asteroids.Objects
{
    class Ship : BaseObject
    {
        /// <summary>
        /// Содержит картинку объекта
        /// </summary>
        public Bitmap Image { get; private set; }

        /// <summary>
        /// Содержит текущую тип картинки
        /// </summary>
        public int ObjType { get; private set; }

        /// <summary>
        /// Хранит разные реализации картинок объектов из ресурсов
        /// </summary>
        internal static Dictionary<int, Image> ObjTypes = new Dictionary<int, Image>();

        /// <summary>
        /// статический конструктор для наполнения словаря изобрадениями
        /// </summary>
        static Ship()
        {
            ObjTypes.Add(0, Properties.Resource1.ship2);
        }

        /// <summary>
        /// Сумма повреждений до наступления смерти
        /// </summary>
        public int Energy { get; set; } = 100;

        /// <summary>
        /// Защита поглощающая урон. После 0 - урон наносится по Energy
        /// </summary>
        public int Shield { get; set; } = 100;


        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            this.Image = new Bitmap(ObjTypes.ElementAt(0).Value);
        }

        public override void Draw()
        {

            Game.Buffer.Graphics.DrawImage(this.Image, this.Pos.X, this.Pos.Y, this.Size.Width, this.Size.Height);
        }

        public override void Update()
        {
        }


        public override void Init()
        {
        }


        /// <summary>
        /// Метод движения вверх
        /// </summary>
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        /// <summary>
        /// Метод движения вниз
        /// </summary>
        public void Down()
        {
            if (Pos.Y < Game.GetHeight()) Pos.Y = Pos.Y + Dir.Y;
        }

        /// <summary>
        /// Метод движения влево
        /// </summary>
        public void Left()
        {
            if (Pos.X > 0) Pos.X = Pos.X - Dir.X;
        }

        /// <summary>
        /// Метод движения вправо
        /// </summary>
        public void Right()
        {
            if (Pos.X < Game.GetWidth()) Pos.X = Pos.X + Dir.X;
        }

        public void Die()
        {
            Environment.Exit(0);
        }
    }
}
