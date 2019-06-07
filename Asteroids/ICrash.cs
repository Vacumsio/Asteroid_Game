using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    interface ICrash
    {
        
        bool Collision(ICrash obj);

        Rectangle Rect { get; }
    }
}
