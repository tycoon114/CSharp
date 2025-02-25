using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public class Floor : GameObject
    {
        public Floor(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
            orderLayer = 1;
        }

        //public override void Render() { 
        
        //}
    }
}
