using System.Drawing;

namespace Asteroids.Objects
{
    class Background : BaseObject
    {

        Image image = Image.FromFile("Fon.jpg");

        public Background(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image,this.Pos);
        }

        public override void Update()
        {
        }

        public override void Init()
        {

        }
    }
}
