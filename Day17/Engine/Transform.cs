using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
     public class Transform : Component
    {
        public int X;
        public int Y;


        public override void Update()
        {

        }

        public void Translate(int addX, int addY) {
            X += addX;
            Y += addY;
        }

    }
}
