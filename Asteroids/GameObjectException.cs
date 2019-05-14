using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Внутренние исключения игры Астероиды
    /// </summary>
    class GameObjectException : Exception
    {
        /// <summary>
        /// Сбой игры
        /// </summary>
        /// <param name="message">Сообщение</param>
        public GameObjectException(string message) : base(message)
        {

        }
    }
}
