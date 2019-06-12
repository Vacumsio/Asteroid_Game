using System;
using System.Drawing;

namespace Asteroids.Objects
{
    /// <summary>
    /// Объект игры Планеты
    /// </summary>
    class Planets : BaseObject
    {
        private Image _img;
        private Random rnd;
        string[] _imgages = new string[]
        {
            "planets/planet1.png",
            "planets/planet2.png"
        };

        public Planets(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            rnd = new Random();
            _img = Image.FromFile(_imgages[rnd.Next(0, _imgages.Length - 1)]);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_img, this.Pos);
        }

        public override void Update()
        {

            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.GetWidth() + Size.Width;
        }

        public override void Init()
        {

        }
    }
}
