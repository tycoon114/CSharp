using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    public  class Class1
    {
        public int temp(int a) {
            Console.Write("aaa");

            return a + 1;
        }

        static uint A = 1103515245;
        static uint C = 12345;
        static uint M = 2147483648;

        static uint seed = 1;

        static uint rand()
        {
            seed = (A * seed + C) % M;
            return seed;
        }

        public void deckBuild()
        {
            int[] deck = new int[52];

            //1 - 13 -> Heart , 1 -> A, 11 -> J, 12 -> Q , 13 -> K
            //14 - 26 -> Diamond
            //27 - 39 -> Clover
            //40 - 52 -> Spade 
            //Initialize
            for (int i = 0; i < deck.Length; i++)
            {
                deck[i] = i + 1;
            }

            //Shuffle 
            Random random = new Random();

            for (int i = 0; i < deck.Length * 10; ++i)
            {
                int firstCardIndex = random.Next(0, deck.Length);
                int secondCardIndex = random.Next(0, deck.Length);

                int temp = deck[firstCardIndex];
                deck[firstCardIndex] = deck[secondCardIndex];
                deck[secondCardIndex] = temp;
            }

            //Print
            for (int i = 0; i < 8; ++i)
            {

                int k = deck[i] / 13;

                string teir = checkTier(deck[i]);
                string card = checkCard(deck[i]);


                Console.WriteLine(card + "  " + teir);
            }
        }


        public string checkTier(int numb) {

            if (numb % 13 == 1)
            {
                return "ACE";
            }
            else if (numb % 13 == 11)
            {
                return "J";
            }
            else if (numb % 13 == 12)
            {
                return "Q";
            }
            else if (numb % 13 == 0)
            {
                return "K";
            }
            else {
                numb = numb % 13;
            }


            return numb.ToString();
        }


        public string checkCard(int card) {

            string temp = "";
            if (card >= 0 && card<14)
            {
                temp = "Heart";
            }
            else if (card >= 13 && card<27)
            {
                temp = "Dia";
            }
            else if (card >= 27 && card <40)
            {
                temp = "Clov";
            }
            else if (card >= 40 && card < 53)
            {
                temp = "Spade";
            }
            return temp;
        }

    }
}
