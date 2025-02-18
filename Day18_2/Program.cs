using Day18_2;

namespace Day18_2
{
    class DynamicArray
    {
        public DynamicArray()
        {
        }

        ~DynamicArray()
        {
        }
        protected Object[] objects = new Object[10];

        protected int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public Object this[int index]
        {
            get
            {
                return objects[index];
            }
            set
            {
                if (index < objects.Length)
                {
                    objects[index] = value;
                }
            }
        }
    }


}


internal class Program
{

    static public void Print<T>(T[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            Console.WriteLine(data[i]);
        }
    }

    class A : IComparable
    {
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }

    static void Main(string[] args)
    {
        TDynamicArray<int> a = new TDynamicArray<int>();
        for (int i = 0; i < 10; ++i)
        {
            a.Add(i +1);
        }

        a[1] = 11;
        a[9] = 29;

        //a.RemoveAt(9);
        //a.RemoveAt(1);
        a.RemoveAt(3);
        a.Insert(2, 11);

        a.Remove(7);

        a.Insert(9, 14);

        //TDynamicArray<GameObject> gameObjects = new TDynamicArray<GameObject>();

        //GameObject testObject = new GameObject();
        //gameObjects.Add(testObject);
        //Console.WriteLine(gameObjects.Count);

        //gameObjects.Remove(testObject);
        //Console.WriteLine(gameObjects.Count);

        for (int i = 0; i < a.Count; ++i)
        {
            Console.Write(a[i] + ", ");
        }

    }
}

