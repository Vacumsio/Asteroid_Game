using System;

using System.Windows.Forms;

// Резяпкин Владимир
// Урок №2

//+2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.

//+3. Сделать так, чтобы при столкновении пули с астероидом они регенерировались в разных концах экрана.

//+4. Сделать проверку на задание размера экрана в классе Game.Если высота или ширина(Width, Height) 
//больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().

//+5.* Создать собственное исключение GameObjectException, которое появляется при попытке  создать объект с 
//неправильными характеристиками(например, отрицательные размеры, слишком большая скорость или неверная позиция).
namespace MyGame
{
    static class Program
    {

        static void Main()
        {


            Form form = new Form();
            form.Width = 800;
            form.Height = 600;

            if (form.Width > 1000 || form.Width < 800) throw new ArgumentOutOfRangeException("Ширина должна быть в пределах от 800 до 1000");
            if (form.Height > 1000 || form.Height < 600) throw new ArgumentOutOfRangeException("Высота должна быть в пределах от 600 до 1000");


            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }

    }
}
