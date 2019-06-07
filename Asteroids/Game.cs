using System.Windows.Forms;
using System.Drawing;
using System;

namespace Asteroids
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        protected static BaseObject[] _objs;
        protected static Star[] _stars;
        protected static Background _background;
        protected static Asteroid[] _asteroids;

        static Game()
        {
        }


        /// <summary>
        /// Инициализация формы
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Timer timer = new Timer { Interval = 50 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Load();

        }


        /// <summary>
        /// Метод загрузки в память создаваемых объектов
        /// </summary>
        public static void Load()
        {
            Random rnd = new Random();
            _objs = new BaseObject[100];
            _stars = new Star[60];
            _background = new Background(new Point(0, 0), new Point(0, 0), new Size(1000,1000));
            _asteroids = new Asteroid[20];

            for (int i = 0; i < _asteroids.Length; i++)
            {
                int s = rnd.Next(1, 12);
                int p = rnd.Next(0, 1080);
                _asteroids[i] = new Asteroid(new Point(1925, p), new Point(s - i, 0), new Size(s, s));
            }

            for (int i = 0; i < _objs.Length; i++)
            {
                int s = rnd.Next(3, 4);
                int p = rnd.Next(0, 1080);
                _objs[i] = new BaseObject(new Point(1925, p), new Point(s - i, 0), new Size(s, s));
            }

            for (int i = 0; i < _stars.Length; i++)
            {
                int s = rnd.Next(1, 2);
                int p = rnd.Next(0, 1080);
                _stars[i] = new Star(new Point(1925, p), new Point(s-i, s), new Size(s, s));
            }
        }

        /// <summary>
        /// Метод отрисовки объектов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            _background.Draw();
            foreach (Asteroid obj in _asteroids)
                obj.Draw();
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Star obj in _stars)
                obj.Draw();
            Buffer.Render();
        }

        /// <summary>
        /// Метод обновления отрисованных объектов из памяти
        /// </summary>
        public static void Update()
        {
            _background.Update();
            foreach (Asteroid obj in _asteroids)
                obj.Update();
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (Star obj in _stars)
                obj.Update();
        }

        /// <summary>
        /// Метод задающий временной интервал во время отрисовки объектов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {            
            Draw();
            Update();
        }
    }
}
