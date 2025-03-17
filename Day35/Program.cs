using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Day35
{
    class GameObject
    {
        public GameObject(int inGold = 100, int inMp = 100, int inHp = 100)
        {
            Gold = inGold;
            MP = inMp;
            HP = inHp;
        }
        public int Gold;
        public int MP;
        public int HP;


    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<GameObject> gameObjects = new List<GameObject>();
            gameObjects.Add(new GameObject(10, 20, 30));
            gameObjects.Add(new GameObject(100, 200, 300));
            gameObjects.Add(new GameObject(50, 60, 3));
            gameObjects.Add(new GameObject(1, 2, 3));
            gameObjects.Add(new GameObject(5, 6, 7));

            string jsonData = JsonConvert.SerializeObject(gameObjects);

            Console.WriteLine(jsonData);

            List<GameObject> gameObjects2 = JsonConvert.DeserializeObject<List<GameObject>>(jsonData);


            foreach (var go in gameObjects2)
            {
                Console.WriteLine(go.Gold);
            }

        }
    }
}
