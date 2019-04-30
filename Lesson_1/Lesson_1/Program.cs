using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson_1
{
    class Program
    {
        class Vector
        {
            // Теперь поля приватные
            private double _x;
            private double _y;
            // Переопределим конструктор по умолчанию        
            public Vector()
            {
                _x = _y = 0;
            }
            // Конструктор, который будет заполнять поля объекта
            public Vector(double x, double y)
            {
                _x = x;
                _y = y;
            }
            // Свойство X для доступа к полю x
            public double X
            {
                get => _x;
                set => _x = value;
            }
            // Свойство Y для доступа к полю y
            public double Y
            {
                get => _y;
                set => _y = value;
            }
        }

        static void Main(string[] args)
        {
            //Form form = new Form();
            //form.Width = 800;
            //form.Height = 600;
            //Game.Init(form);
            //form.Show();
            //Game.Draw();
            //Application.Run(form);

            Vector v1 = new Vector(10, 5);
            Vector v2;
            v2 = new Vector(-5, -10);
            // Доступ к полям стал более логичным при записи
            v1.Y = 10;
            v2.X = -10;
            Console.WriteLine($"v1: X={v1.X} Y={v1.Y}"); // и при чтении
            Console.WriteLine($"v2: X={v2.X} Y={v2.Y}"); // и при чтении
            Console.ReadKey();
        }
    }
}
