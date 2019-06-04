using System;
using System.Windows.Forms;

namespace Asteroids
{
    class MainClass
    {
        static void Main(string[] args)
        {
            using (Form form = new Form())
            {
                try
                {
                    form.Width = 1920;
                    form.Height = 1080;
                    Game.Init(form);
                    form.Show();
                    Game.Draw();
                    Application.Run(form);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }            
        }
    }
}
