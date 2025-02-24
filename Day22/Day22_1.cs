using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day22
{


    internal class Map
    {
        public void Temp()
        {

            //int n = 5;

            //uint[] arrA = [9, 20, 28, 18, 11];  //[9, 20, 28, 18, 11]
            //uint[] arrB = [30, 1, 21, 17, 28];  //[30, 1, 21, 17, 28]

            //string[] arrR = new string[n];

            ////string numStr = Convert.ToString(n, 2);
            //uint k = 0;
            //for (int i = 0; i < arrA.Length; i++)
            //{
            //    k = arrA[i] | arrB[i];

            //    Console.WriteLine(Convert.ToString(k, 2));
            //}


        }


        public void Kakao()
        {
            int n = 5;
            int[] arrA = { 9, 20, 28, 18, 11 };
            int[] arrB = { 30, 1, 21, 17, 28 };

            int[] arrR = new int[n];

            for (int i = 0; i < n; i++)
            {
                arrR[i] = arrA[i] | arrB[i];
                //Console.WriteLine(Convert.ToString(arrR[i], 2).Replace('1','#').Replace('0',' '));
            }

            int bitMask = 0b00000001;
            for (int i = 0; i < n; ++i)
            {

                bitMask = 1 << (n - 1);
                for (int j = 0; j < 8; ++j)
                {
                    Console.Write((bitMask & arrR[i]) > 0 ? "#" : " ");
                    bitMask = bitMask >> 1;
                }
                Console.WriteLine();
            }


        }


        public void bitQ2()
        {

            uint N = 3;
            ulong[] X = new ulong[4];

            X[0] = 3;
            X[1] = 5;
            X[2] = 7;

            ulong result = 0;

            for (int i = 0; i < N; ++i)
            {
                ulong value = 1;
                for (int n = 1; n < 64; ++n)
                {
                    value = value << 1;
                    if (X[i] < value)
                    {
                        //Console.Write(value);
                        result = result ^ value;

                        break;
                    }
                }
            }
            Console.WriteLine(result);

        }


    }

}

