using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    public class Monster : GameObject
    {

        private Random rand = new Random();
        public Monster(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
        }

        public override void Update() {
            int monsterPosition = rand.Next(0, 4);

            if (monsterPosition == 0) {
                if (Y != 1)
                {
                    Y--;
                }
            }
            if (monsterPosition == 1)
            {
                if (X != 1)
                {
                    X--;
                }
            }
            if (monsterPosition == 2)
            {
                if (Y != 8)
                {
                    Y++;
                }
            }
            if (monsterPosition == 3)
            {
                if (X != 8)
                {
                    X++;
                }
            }

        }

    }
}
