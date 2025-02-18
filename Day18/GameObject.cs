using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    public class GameObject
    {
        public int X, Y;

        public char Shape;


        public virtual void Update()
        {
            
        }

        public virtual void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Shape);
        }

    }
}
