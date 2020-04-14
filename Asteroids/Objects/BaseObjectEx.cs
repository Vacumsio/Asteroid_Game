using System;

namespace Asteroids.Objects
{
    class BaseObjectEx: Exception
    {
        /// <summary>
        /// Сбой игры
        /// </summary>
        /// <param name="message">Сообщение</param>
        public BaseObjectEx(string message) : base(message)
        {

        }
    }
}
