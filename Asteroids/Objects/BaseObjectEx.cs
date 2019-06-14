using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Objects
{
    class BaseObjectEx
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
