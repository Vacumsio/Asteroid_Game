using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.Windows.Media;
using Color = System.Drawing.Color;

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
        static BaseObject[] objs;

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

        /// <summary>
        /// Bнициализация компонентов
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



            Graphics g;
            g = form.CreateGraphics();
            context = BufferedGraphicsManager.Current;
            buffer = context.Allocate(g, new Rectangle(0, 0, GetWidth(), GetHeight()));

            Load();

            Timer timer = new Timer
            {
                Interval = 35
            };
            timer.Tick += Timer_Tick;
            timer.Start();
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

        /// <summary>
        /// Снаряд
        /// </summary>
        private static Bullet bullet;

        /// <summary>
        /// Массив астероидов
        /// </summary>
        private static Asteroid[] asteroids;

        /// <summary>
        /// Загрузка элементов игры
        /// </summary>
        static public void Load()
        {
            int ran, size;
            Random rnd = new Random();
            bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            objs = new BaseObject[200];
            for (int i = 0; i < objs.Length; i++)
            {
                ran = rnd.Next(1, 6);
                objs[i] = new Star(new Point(rnd.Next(0, Game.GetWidth()), rnd.Next(0, Game.GetHeight())),
                    new Point(rnd.Next(1, 3), 0), new Size(ran, ran));
            }

            asteroids = new Asteroid[3];
            for (var i = 0; i < asteroids.Length; i++)
            {
                ran = rnd.Next(6, 12);
                size = rnd.Next(40, 70);
                asteroids[i] = new Asteroid(new Point(Game.GetWidth(), rnd.Next(0, Game.GetHeight())), new Point(ran, 0), new Size(size, size), rnd.Next(1, 6));
            }
        }

        /// <summary>
        /// Отрисовывает графику через буфер
        /// </summary>
        static public void Draw()
        {
            buffer.Graphics.Clear(Color.Black);
            foreach (var item in objs)
            {
                item.Draw();
            }

            foreach (Asteroid item in asteroids)
            {
                item.Draw();
            }
            bullet.Draw();
            buffer.Render();
        }

        /// <summary>
        /// Обновляет все элементы по событию таймера
        /// </summary>
        static public void Update()
        {
            foreach (var item in objs)
            {
                item.Update();
            }

            foreach (Asteroid a in asteroids)
            {
                a.Update();
                if (a.Collision(bullet))
                {
                    a.Play();
                    a.Init();
                    bullet.Init();
                }
            }
            bullet.Update();
        }
    }
}
