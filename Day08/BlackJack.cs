﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    internal class BlackJack
    {
            static void Initialize(int[] deck)
            {
                for (int i = 0; i < deck.Length; i++)
                {
                    deck[i] = i + 1;
                }
            }

            static void Shuffle(int[] deck)
            {
                Random random = new Random();

                for (int i = 0; i < deck.Length * 10; ++i)
                {
                    int firstCardIndex = random.Next(0, deck.Length);
                    int secondCardIndex = random.Next(0, deck.Length);

                    int temp = deck[firstCardIndex];
                    deck[firstCardIndex] = deck[secondCardIndex];
                    deck[secondCardIndex] = temp;
                }
            }

            enum CardType
            {
                None = -1,
                Heart = 0,
                Diamond = 1,
                Clover = 2,
                Spade = 3,
            }

            static void Print(int[] deck)
            {
                //for (int i = 0; i <3; ++i)
                //{
                //    Console.WriteLine($"{CheckCardType(deck[i]).ToString()} {CheckCardName(deck[i])}");
                //}



            }

            static CardType CheckCardType(int cardNumber)
            {
                int valueType = (cardNumber - 1) / 13;

                return (CardType)valueType;
            }

            static string CheckCardName(int cardNumber)
            {
                int cardValue = ((cardNumber - 1) % 13) + 1;
                string cardName;
                switch (cardValue)
                {
                    case 1:
                        cardName = "A";
                        break;
                    case 11:
                        cardName = "J";
                        break;
                    case 12:
                        cardName = "Q";
                        break;
                    case 13:
                        cardName = "K";
                        break;
                    default:
                        cardName = cardValue.ToString();
                        break;
                }

                return cardName;
            }




            public void Main()
            {
                int[] deck = new int[52];

                Initialize(deck);

                Shuffle(deck);

                //Print(deck);

                blackJackDraw(deck);

            }

        static void blackJackDraw(int[] deck)
        {

            PrintCardList(deck);

            string[] player = new string[2];
            int playerScore =0, computerScore;

            string[] computer = new string[2];

            playerScore = blackJackScore(deck[0]) + blackJackScore(deck[2]) + blackJackScore(deck[4]);
            computerScore = blackJackScore(deck[1]) + blackJackScore(deck[3]) + blackJackScore(deck[5]);

            Console.WriteLine($"player : {playerScore}  Comp :  {computerScore}");

            if (playerScore >= 21 && computerScore < 21)
            {
                //Computer Win
                Console.WriteLine("Computer Win");
            }
            else if (playerScore < 21 && computerScore >= 21)
            {
                //Player Win
                Console.WriteLine("Player Win");
            }
            else if (playerScore >= 21 && computerScore >= 21)
            {
                //Player Win
                Console.WriteLine("Player Win");
            }
            else if (computerScore <= playerScore)
            {
                //Player Win
                Console.WriteLine("Player Win");
            }
            else // (computerScore > playerScore)
            {
                //Computer Win
                Console.WriteLine("Computer Win");
            }



        }

        static int  blackJackScore(int cardNum) {
            int value = (((cardNum - 1) % 13) + 1) > 10 ? 10 : ((cardNum - 1) % 13) + 1;
            return value;
        }

        static void PrintCardList(int[] deck)
        {
            //
            Console.WriteLine("Player");
            for (int i = 0; i < 3; ++i)
            {
                Console.WriteLine($"{CheckCardType(deck[i]).ToString()} {CheckCardName(deck[i])}");
            }
            Console.WriteLine("-------------");

            Console.WriteLine("Computer");
            for (int i = 3; i < 6; ++i)
            {
                Console.WriteLine($"{CheckCardType(deck[i]).ToString()} {CheckCardName(deck[i])}");
            }
            Console.WriteLine("-------------");
        }


    }
}
