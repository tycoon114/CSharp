using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    public class Player : GameObject
    {
        public Player(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
        }

        public override void Update()
        {
            if (Input.GetKeyDown(ConsoleKey.W) || Input.GetKeyDown(ConsoleKey.UpArrow))
            {
                if (Y != 1)
                {
                    Y--;
                }
            }
            if (Input.GetKeyDown(ConsoleKey.A) || Input.GetKeyDown(ConsoleKey.LeftArrow))
            {
                if (X != 1)
                {
                    X--;
                }

            }
            if (Input.GetKeyDown(ConsoleKey.S) || Input.GetKeyDown(ConsoleKey.DownArrow))
            {
                if (Y != 8)
                {
                    Y++;
                }
            }
            if (Input.GetKeyDown(ConsoleKey.D) || Input.GetKeyDown(ConsoleKey.RightArrow))
            {
                if (X != 8)
                {
                    X++;
                }
            }
        }
    }
}
