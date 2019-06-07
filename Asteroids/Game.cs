using System.Windows.Forms;
using System.Drawing;
using System;
using Asteroids.Objects;
using System.Media;

namespace Asteroids
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        protected static Star[] _stars;
        protected static Background _background;
        protected static Asteroid[] _asteroids;
        protected static Planets[] _planets;
        private static Bullet _bullet;

        public static int width;
        public static int height;

        public static int GetWidth() => width;
        public static int GetHeight() => height;

        public static void SetWidth(int value)
        {
            //if (value >= 1920 || value < 0) throw new ArgumentOutOfRangeException("Выход за пределы игрового поля");
            width = value;
        }
        public static void SetHeight(int value)
        {
            //if (value >= 1080 || value < 0) throw new ArgumentOutOfRangeException("Выход за пределы игрового поля");
            height = value;
        }

        static Game()
        {
        }

        /// <summary>
        /// Инициализация формы
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Asteroids";
            SetWidth(form.Width);
            SetHeight(form.Height);
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.MaximumSize = new Size(GetWidth(), GetHeight());
            form.MinimumSize = new Size(GetWidth(), GetHeight());
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.WindowState = FormWindowState.Normal;
            form.WindowState = FormWindowState.Maximized;//полный экран
            form.FormBorderStyle = FormBorderStyle.None;//полный экран


            Graphics g;
            g = form.CreateGraphics();
            _context = BufferedGraphicsManager.Current;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, GetWidth(), GetHeight()));

            Load();

            Timer timer = new Timer { Interval = 50 };
            timer.Tick += Timer_Tick;
            timer.Start();
        }


        /// <summary>
        /// Метод загрузки в память создаваемых объектов
        /// </summary>
        public static void Load()
        {
            Random rnd = new Random();            
            _stars = new Star[100];
            _background = new Background(new Point(0, 0), new Point(0, 0), new Size(0,0));
            _asteroids = new Asteroid[14];
            _planets = new Planets[2];
            _bullet = new Bullet(new Point(0,1080), new Point(15,0), new Size(20,5));
            
            for (int i = 0; i < _asteroids.Length; i++)
            {
                int s = rnd.Next(1, 12);
                int p = rnd.Next(50, 980);
                _asteroids[i] = new Asteroid(new Point(1925, p), new Point(s - i, 0), new Size(s, s));
            }

            for (int i = 0; i < _stars.Length; i++)
            {
                int s = rnd.Next(1, 2);
                int p = rnd.Next(0, 1080);
                _stars[i] = new Star(new Point(1925, p), new Point(s - i, s), new Size(s, s));
            }

            for (int i = 0; i < _planets.Length; i++)
            {
                int s = rnd.Next(0, 2);
                int p = rnd.Next(100, 800);
                _planets[i] = new Planets(new Point(1925, p), new Point(s-i*4, s), new Size(s, s));
            }
        }

        /// <summary>
        /// Метод отрисовки объектов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            _background.Draw();
            foreach (Star obj in _stars)
                obj.Draw();
            foreach (Asteroid obj in _asteroids)
                obj.Draw();
            foreach (Planets obj in _planets)
                obj.Draw();
            _bullet.Draw();
            Buffer.Render();
        }

        /// <summary>
        /// Метод обновления отрисованных объектов из памяти
        /// </summary>
        public static void Update()
        {
            _background.Update();
            foreach (Star obj in _stars)
                obj.Update();
            foreach (Asteroid a in _asteroids)
            {
                a.Update();
                if (a.Collision(_bullet)) { SystemSounds.Beep.Play(); }
            }
            foreach (Planets obj in _planets)
                obj.Update();
            _bullet.Update();
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
