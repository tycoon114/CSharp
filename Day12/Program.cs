using System.Drawing;

namespace Day12
{
    class Monster() { 
    
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Position[] positions = new Position[10];
            positions[0].x = 12;
            positions[0].y = 13;

            Apple[] apple = new Apple[3]; // 스택 참조 변수, heap을 가르킴
            for (int i = 0; i < apple.Length; i++)
            {
                apple[i] = new Apple(); // heap apple 형태 메모리 공간 확보
            }

            //apple[0].color = apple.EColor.Yellow


        }
    }

    class Apple() {


        public enum EColor
        {
            Yellow,
                Green,
                Blue,
                Red,
                Cyan
        }
        public EColor color;

        public int shape;
        public int hp = 100;
        public bool taste;


        public void Damage()
        {
            hp -= 10;
        }



    }

    struct Position{
        public int x;
        public int y;
    }


    internal class Progm
    {
        public int n = 0;
        static void Main(string[] args)
        {
            Progm program = new Progm();
            program.n = 0;

        }

    }

}


