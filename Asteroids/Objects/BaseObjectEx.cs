using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
