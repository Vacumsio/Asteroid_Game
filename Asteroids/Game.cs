using System.Windows.Forms;
using System.Drawing;
using System;

namespace Asteroids
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        protected static Star[] _stars;
        protected static Background _background;
        protected static Asteroid[] _asteroids;
        
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
            timer.Start();
            timer.Tick += Timer_Tick;
        }


        /// <summary>
        /// Метод загрузки в память создаваемых объектов
        /// </summary>
        public static void Load()
        {
            Random rnd = new Random();            
            _stars = new Star[60];
            _background = new Background(new Point(0, 0), new Point(0, 0), new Size(0,0));
            _asteroids = new Asteroid[20];

            for (int i = 0; i < _asteroids.Length; i++)
            {
                int s = rnd.Next(1, 12);
                int p = rnd.Next(10, 1060);
                _asteroids[i] = new Asteroid(new Point(1925, p), new Point(s - i, 0), new Size(s, s));
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
