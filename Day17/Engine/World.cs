using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public class World
    {
        public delegate int SortCompare(GameObject first, GameObject second);
        public SortCompare sortCompare;



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
            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int j = i + 1; j < gameObjects.Count; j++)
                {

                    if (sortCompare(gameObjects[i], gameObjects[j]) > 0)
                    {
                        GameObject temp = gameObjects[i];
                        gameObjects[i] = gameObjects[j];
                        gameObjects[j] = temp;
                    }
                }
            }

        }

        public void Awake() {
            foreach (var choiceObject in gameObjects) {
                foreach (Component component in choiceObject.components)
                {
                    component.Awake();
                }
            }
            
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
