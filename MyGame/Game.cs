using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {

        }
        /// <summary>
        /// Основной метод вывода графики
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

            Load();
            Timer timer = new Timer { Interval = 50 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        /// <summary>
        /// Метод Отрисовки объектов в форме
        /// </summary>
        public static void Draw()
        {


            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objc)
                obj.Draw();
            
            foreach (Asteroid a in _asteroids)
            {
                a.Draw();
            }
                
            
            _bullet.Draw();
            Buffer.Render();
        }
        /// <summary>
        /// Описывает движение объектов на экране
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objc)
                obj.Update();
            foreach (Asteroid a in _asteroids)
            {
                a.Update();
                if (a.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _bullet.MoveStartPosition();
                    a.MoveStartPosition();
                }
            }
            _bullet.Update();
                
        }

        /// <summary>
        /// Бесконечный цикл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static BaseObject[] _objc;
        private static Asteroid[] _asteroids;
        private static Bullet _bullet;


        /// <summary>
        /// Загрузка объектов
        /// </summary>
        public static void Load()
        {
            var rnd = new Random();
            _objc = new BaseObject[31];
            _bullet = new Bullet(new Point(0, rnd.Next(0, Game.Height)), new Point(5, 0), new Size(10, 3));
            _asteroids = new Asteroid[5];
            
            //Загрузка Звезд
            for(var i = 0; i < _objc.Length-1; i++)
            {
                int r = rnd.Next(5, 50);
                
                _objc[i] = new Star(new Point(1000, rnd.Next(0, Game.Height)), new Point(r, r), new Size(3, 3));
            
            }
            //загрузка планыты
            _objc[_objc.Length - 1] = new BigPlanet_HW(new Point(600, rnd.Next(0, Game.Height)), new Point(5, 0), new Size(20, 20));

            //Загрузка астеройдов
            for (int i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                int randSize = rnd.Next(10, 30);
                _asteroids[i] = new Asteroid(new Point(1000, rnd.Next(0, Game.Height)), new Point(r/5, r), new Size(randSize, randSize));
            }
            

        }

    }
}
