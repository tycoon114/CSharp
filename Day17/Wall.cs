using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public class Wall : GameObject
    {
        public Wall(int inX, int inY, char inShape) { 
            X = inX;
            Y = inY;
            Shape = inShape;
            orderLayer = 2;
            isCollide = true;


            color.r = 20;
            color.g = 0;
            color.b = 255;
            color.a = 0;    

        }
    }
}
