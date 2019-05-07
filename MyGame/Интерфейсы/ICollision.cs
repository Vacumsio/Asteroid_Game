using System.Drawing;

namespace MyGame
{
    /// <summary>
    /// Интерфейс для определения столкновения
    /// </summary>
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }

    }
}
