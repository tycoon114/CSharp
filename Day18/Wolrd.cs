using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    public class World
    {
        public GameObject[] gameObjects = new GameObject[100];
        protected int useGameObjCnt = 0;

        public void Instanciate(GameObject gameObject)
        {
            gameObjects[useGameObjCnt] = gameObject;
            useGameObjCnt++;
        }

        public void Render()
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].Render();
            }
        }

        public void Update()
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].Update();
            }
        }


    }

}

