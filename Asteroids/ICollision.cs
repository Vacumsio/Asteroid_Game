using System.Drawing;


/// <summary>
/// Игра "Астероид".
/// Гагарский Петр Е., 2 курс С#.
/// </summary>
namespace Asteroids
{
    interface ICollision
    {        
        bool Collision(ICollision obj);

        Rectangle Rect { get; }
    }
}
