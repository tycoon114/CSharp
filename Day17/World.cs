using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public  class World
    {
        public GameObject[] gameObjects =  new GameObject[100];
        protected int useGameObjectCount = 0;


        public void Instanciate(GameObject gameObject) {
            gameObjects[useGameObjectCount] = gameObject;
            useGameObjectCount++;
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
