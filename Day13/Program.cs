using System.Security.Cryptography.X509Certificates;

namespace Day13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");















        }




    }

    public class Player
    {
        public int HP = 10;
        public int Gold;



        
    }



    struct Monster
    {
        public void Goblin()
        {
            int HP = 0;
        }
        public void Slime()
        {
            int HP = 0;
        }
        public void Bore()
        {
            int HP = 0;
        }

    }

    public class Act
    {

        public void Attack()
        {
            Player player = new Player();
            Monster[] monster = new Monster[3];


            if (player.HP == 0) { 
                //GameOver
            }


            //if () { 
            //    //랜덤함수 -> 골드값 랜덤
            //    //몬스터 사망
            //    //몬스터 오브젝트 삭제
            //}


        }
        public void Move()
        {

            //OnKey~~~  -> 플레이어 이동

            //onMouse  -> 플레이어 공격

            //몬스터 이동

            //몬스터 공격






        }

    }


}
