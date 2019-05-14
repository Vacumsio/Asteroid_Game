using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class BackGround : BaseObject
    {
        Image newImage = Image.FromFile("nastol.com.ua-275415.jpg");
        public BackGround(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(newImage, new Rectangle(Pos, new Size(Size.Width, Size.Height)));
        }

        public override void Init()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {

        }
    }
}
