﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public class GameObject
    {
        public int X;
        public int Y;

        public char Shape;  //Mesh, Sprite

        public int orderLayer;

        public bool isTrigger = false;
        public bool isCollide = false;

        public bool PredictCollision(int newX, int newY)
        {

            for (int i = 0; i < Engine.Instance.world.GetAllGameObjects.Count; ++i)
            {
                if (Engine.Instance.world.GetAllGameObjects[i].isCollide == true &&
                        Engine.Instance.world.GetAllGameObjects[i].X == newX &&
                        Engine.Instance.world.GetAllGameObjects[i].Y == newY)
                {
                    return true;
                }
            }
            return false;
        }

        public virtual void Update()
        { 
            
        }


        public virtual void Render()
        { 
            //x y 위치에 Shape 출력
            //Console.SetCursorPosition(X, Y);
            //Console.Write(Shape);

            Engine.backBuffer[Y,X] = Shape;

        }

    }
}
