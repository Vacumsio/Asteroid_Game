using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Background : BaseObject
    {

        Image image = Image.FromFile("Fon.jpg");

        public Background(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, 1920, 1080);
        }

        public override void Update()
        {
            Pos.X = 0;
            Pos.Y = 0;
        }
    }
}
