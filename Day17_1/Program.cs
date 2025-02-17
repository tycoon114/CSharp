using System.ComponentModel.DataAnnotations;

namespace Day17_1
{



    public class Fruit {
        public Fruit() { }

        public void Do() {
            Console.WriteLine("Parents");
        }

        private void Eat() { 
        
        }

        private int gold;

        public int Gold {
            get {
                return gold;
            }
            set {

                gold = value;
            }
        }

    
    }


    public class Orange : Fruit
    {
        public void Do1() {
            Console.WriteLine("Child");
        }


        public int hp;
    
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Fruit b = new Fruit();
            b.Do();



            //Orange orange = new Orange();
            //orange.Do();
            //orange.Do1();
            //orange.Gold++;

            //orange.hp++;
        }
    }
}
