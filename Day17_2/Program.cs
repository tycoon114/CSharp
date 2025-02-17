namespace Day17_2
{


    class Monster {

        public virtual void Move() {
            Console.WriteLine("이동한다");
        }
    }

    class Slime : Monster {

        public override void Move() {
            Console.WriteLine("미끄러진다");
        }


        public void Sticky() { 
            Console.WriteLine("끈적이다.");
        }

    }

    class Goblin : Monster {

        public override void Move()
        {
            Console.WriteLine("뛰어다닌다");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Monster[] monster = new Monster[2];
            monster[0] = new Slime();
            monster[1] = new Goblin();

            //Down Casting, 동적변환
            for (int i = 0; i <monster.Length; i++)
            {
                Slime? s = monster[i] as Slime;
                if (s != null)
                {
                    s.Sticky();
                }


            }
            // 만약 [0]이 슬라임이 아니면  null값이 들어간다.
            //Slime s = monster[0] as Slime;


            if (s != null)
            { 
                s.Sticky(); 
            }
        }
    }
}
