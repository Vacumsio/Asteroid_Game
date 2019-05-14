using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    //form.Width = Screen.PrimaryScreen.Bounds.Width;       // для полного экрана
                    //form.Height = Screen.PrimaryScreen.Bounds.Height;     // для полного экрана
                    form.Width = 1280;
                    form.Height = 720;
                    Game.Init(form);
                    form.Show();
                    Game.Load();
                    Game.Draw();
                    Application.Run(form);
                }
                catch (GameObjectException ex)
                {
                    MessageBox.Show(ex.ToString() + "\nРабота программы будет завершена.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.ToString() + "\nРабота программы будет завершена.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }
    }
}
