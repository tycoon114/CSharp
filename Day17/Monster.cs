﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public class Monster : GameObject
    {


        //private static elapsedTime;

        private float elapsedTime = 0;
        private Random rand = new Random(); 
        public Monster(int inX, int inY, char inShape)
        {
            //X = inX;
            //Y = inY;
            //Shape = inShape;
            //orderLayer = 5;
            //isTrigger = true;

            //color.r = 155;
            //color.g = 22;
            //color.b = 0;
            //color.a = 0;

            //LoadBmp("data/monster.bmp");
        }




        public override void Update()
        {
            //    if (elapsedTime >= 500.0f)
            //    {
            //        int Direction = rand.Next(0, 4);

            //        if (Direction == 0)
            //        {
            //            if (!PredictCollision(X, Y - 1))
            //            {
            //                Y--;
            //            }
            //        }
            //        if (Direction == 1)
            //        {
            //            if (!PredictCollision(X, Y + 1))
            //            {
            //                Y++;
            //            }
            //        }
            //        if (Direction == 2)
            //        {
            //            if (!PredictCollision(X - 1, Y))
            //            {
            //                X--;
            //            }
            //        }
            //        if (Direction == 3)
            //        {
            //            if (!PredictCollision(X + 1, Y))
            //            {
            //                X++;
            //            }
            //        }
            //        elapsedTime = 0;
            //    }
            //    else {
            //        elapsedTime += Time.deltaTime;
            //    }
            //    Console.SetCursorPosition(30, 10);
            //    Console.Write(Time.deltaTime);
        }

    }
}
