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
        protected static BaseObject[] _stars;

        static Game()
        {
        }

        public static void Load()
        {
            Random rnd = new Random();
            _objs = new BaseObject[100];
            _stars = new BaseObject[60];

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

        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = 50 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Load();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (BaseObject obj in _stars)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (BaseObject obj in _stars)
                obj.Update();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
