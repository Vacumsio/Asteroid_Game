using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Интерфейс для определения столкновения
    /// </summary>
    interface ICollision
    {
        /// <summary>
        /// Признак столкновения
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Collision(ICollision obj);

        /// <summary>
        /// Поле для определения столкновения
        /// </summary>
        Rectangle Rect { get; }
    }
}
