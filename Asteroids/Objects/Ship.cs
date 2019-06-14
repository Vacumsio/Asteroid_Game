using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// статический конструктор для наполнения словаря для всех экземпляров
        /// </summary>
        
        static Ship()
        {
            ObjTypes.Add(0, Properties.Resource1.ship2);
        }

        public int Energy { get; set; } = 100;

        public void EnergyLow(int n)
        {
            Energy -= n;
        }

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

        public void Attack()
        {

        }

        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.GetHeight()) Pos.Y = Pos.Y + Dir.Y;
        }
        public void Left()
        {
            if (Dir.X < 0) Dir.X -= Dir.X;
        }

        public void Right()
        {
            if (Dir.X > Game.GetWidth()) Dir.X += Dir.X;
        }

        public void Die()
        {
            Environment.Exit(0);
        }
    }
}
