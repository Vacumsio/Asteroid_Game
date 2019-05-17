using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.Windows.Media;
using Color = System.Drawing.Color;
using Brushes = System.Drawing.Brushes;
using FontFamily = System.Drawing.FontFamily;

namespace Asteroids
{
    static class Game
    {
        /// <summary>
        /// Плеййер для снаряда
        /// </summary>
        public static MediaPlayer bul = new MediaPlayer();
        public static string pathToFileBul = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "shot.wav");

        /// <summary>
        /// Плейер для астероида
        /// </summary>
        public static MediaPlayer aster = new MediaPlayer();
        public static string pathToFileAster = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "band.wav");

        /// <summary>
        /// Буфер для вывода изображения
        /// </summary>
        static public BufferedGraphics buffer;
        static BufferedGraphicsContext context;

        /// <summary>
        /// Массив графических объектов
        /// </summary>
        static BaseObject[] _objs;

        /// <summary>
        /// Ширина графического поля
        /// </summary>
        private static int width;

        /// <summary>
        /// Высота игрового пеля
        /// </summary>
        private static int height;

        /// <summary>
        /// Возвращает ширину игрового поля
        /// </summary>
        /// <returns></returns>
        public static int GetWidth()
        {
            return width;
        }

        /// <summary>
        /// Устанавливает ширину игрового поля
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException()">При не верных значениях ширины</exception>
        public static void SetWidth(int value)
        {
            if (value >= 1281 || value <= 0) throw new ArgumentOutOfRangeException("Недопустимая ширина игрового поля");
            width = value;
        }

        /// <summary>
        /// Возвращает высоту графического поля
        /// </summary>
        public static int GetHeight()
        {
            return height;
        }

        /// <summary>
        /// Устанавливает высоту графического поля
        /// </summary>
        public static void SetHeight(int value)
        {
            if (value >= 721 || value <= 0) throw new ArgumentOutOfRangeException("Недопустимая высота игрового поля");
            height = value;
        }

        /// <summary>
        /// Статический конструктор игры
        /// </summary>
        static Game()
        {

        }

        private static Timer _timer = new Timer();
        public static Random Rnd = new Random();





        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        /// <param name="form">главная форма приложения</param>
        static public void Init(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Icon = Properties.Resources.Asteroid01;
            form.Text = "Asteroids";
            SetWidth(form.Width);
            SetHeight(form.Height);
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.MaximumSize = new Size(GetWidth(), GetHeight());
            form.MinimumSize = new Size(GetWidth(), GetHeight());
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.WindowState = FormWindowState.Normal;
            //form.WindowState = FormWindowState.Maximized;             // для полного экрана
            //form.FormBorderStyle = FormBorderStyle.None;              // для полного экрана

            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;

            Graphics g;
            g = form.CreateGraphics();
            context = BufferedGraphicsManager.Current;
            buffer = context.Allocate(g, new Rectangle(0, 0, GetWidth(), GetHeight()));

            Load();            
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }


        /// <summary>
        /// Обработчик события от таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));

        /// <summary>
        /// Снаряд
        /// </summary>
        private static Bullet _bullet;

        /// <summary>
        /// Массив астероидов
        /// </summary>
        private static Asteroid[] _asteroids;
        
        /// <summary>
        /// Загрузка элементов игры
        /// </summary>
        static public void Load()
        {
            int ran, size;
            Random rnd = new Random();
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(15, 1));

            _objs = new BaseObject[200];
            for (int i = 0; i < _objs.Length; i++)
            {
                ran = rnd.Next(1, 6);
                _objs[i] = new Star(new Point(rnd.Next(0, Game.GetWidth()), rnd.Next(0, Game.GetHeight())),
                    new Point(rnd.Next(1, 3), 0), new Size(ran, ran));
            }

            _asteroids = new Asteroid[3];
            for (var i = 0; i < _asteroids.Length; i++)
            {
                ran = rnd.Next(6, 12);
                size = rnd.Next(40, 70);
                _asteroids[i] = new Asteroid(new Point(Game.GetWidth(), rnd.Next(0, Game.GetHeight())), new Point(ran, 0), new Size(size, size), rnd.Next(1, 6));
            }
        }

        /// <summary>
        /// Отрисовывает графику через буфер
        /// </summary>
        static public void Draw()
        {
            buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid a in _asteroids)
            {
                a?.Draw();
            }
            _bullet?.Draw();
            _ship?.Draw();
            if (_ship != null)
                buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            buffer.Render();

        }

        /// <summary>
        /// Обновляет все элементы по событию таймера
        /// </summary>
        static public void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update();
            _bullet?.Update();
            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _asteroids[i] = null;
                    _bullet = null;
                    continue;
                }
                if (!_ship.Collision(_asteroids[i])) continue;
                var rnd = new Random();
                _ship?.EnergyLow(rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship?.Die();
            }

        }
        
        public static void Finish()
        {
            _timer.Stop();
            buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            buffer.Render();
        }

    }
}
