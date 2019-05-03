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
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 1000;
            form.Height = 800;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
