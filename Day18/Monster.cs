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
                Y--;
            }
            if (monsterPosition == 1)
            {
                X--;
            }
            if (monsterPosition == 2)
            {
                Y++;
            }
            if (monsterPosition == 3)
            {
                X++;
            }

        }

    }
}
