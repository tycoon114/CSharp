using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public class World
    {
        //public GameObject[] gameObjects =  new GameObject[100];
        //protected int useGameObjectCount = 0;

        List<GameObject> gameObjects = new List<GameObject>();

        public List<GameObject> GetAllGameObjects
        {
            get
            {
                return gameObjects;
            }
        }


        public void Instanciate(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }


        public void Render()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                SpriteRenderer spriteRenderer = gameObjects[i].GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.Render();
                }

            }
        }

        public void Sort()
        {
            //for (int i = 0; i < gameObjects.Count; i++) {
            //    for (int j = i+1; j < gameObjects.Count; j++) {
            //        if (gameObjects[i].orderLayer - gameObjects[j].orderLayer > 0) { 
            //            GameObject temp = gameObjects[i];
            //            gameObjects[i] = gameObjects[j];
            //            gameObjects[j] = temp;
            //        }
            //    }
            //}

        }


        public void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                foreach (Component component in gameObjects[i].components)
                {
                    component.Update();
                }
            }
        }
    }
}
