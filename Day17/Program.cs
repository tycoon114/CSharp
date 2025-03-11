using System;
using System.Net.Sockets;
using System.Text;

namespace Day17
{
    internal class Program
    {

        public static int Compare(GameObject first, GameObject second)
        {

            {
                SpriteRenderer spriteRenderer1 = first.GetComponent<SpriteRenderer>();
                SpriteRenderer spriteRenderer2 = second.GetComponent<SpriteRenderer>();
                if (spriteRenderer1 == null || spriteRenderer2 == null)
                {
                    return 0;
                }

                return spriteRenderer1.orderLayer - spriteRenderer2.orderLayer;

            }
        }

        static void Main(string[] args)
        {

            Engine.Instance.Init();

            Engine.Instance.SetSortCompare(Compare);

            Engine.Instance.Load("level01.map");
            Engine.Instance.Run();

            Engine.Instance.Quit();
        }



    }

}
