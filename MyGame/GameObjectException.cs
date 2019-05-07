using System;

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
