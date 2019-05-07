using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    /// <summary>
    /// Класс исключения
    /// </summary>
    class GameObjectException :Exception
    {
        /// <summary>
        /// Выводит сообщение об ошибке
        /// </summary>
        /// <param name="message"></param>
        public GameObjectException(string message) : base(message)
        {

        }

    }
}
