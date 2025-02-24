namespace Day22
{

    class BitArray32 {
        public uint Data;

        public void On(int position) {
            Data = Data | (uint)(1 << position -1);
        }

        public void Off(int position)
        {
            Data = Data & ~(uint)(1 << position);
        }

    }


    internal class Program
    {


        static void Main(string[] args)
        {
            //byte a = 0; // 0000 0000
            //a = 1 << 1;  // ===> 0000 0010
            //Console.WriteLine(a);
            //byte b = 0;
            //b = 1 << 2; // ====> 0000 0100
            //Console.WriteLine(b);


            //int R = 255;
            //R = 0xFF;
            //R = 0b11111111;
            byte Player = 1; // 0b0000 0001
            byte Camera = 2; // 0b0000 0010
            byte UI = 4;     // 0b0000 0100
            byte water = 8;  // 0b0000 1000

            //Player
            byte playerLayer = 0b00000000;   // 0b00000000
            playerLayer = (byte)(playerLayer | Player);


            //비트 마스킹 
            //플레이어나 카메라 레이어 중 최소 1개만 고른다면
            if ((playerLayer & (Player | Camera))>(byte)0) { 
            
            }


            BitArray32 bitarray = new BitArray32();

            Map map = new Map();
            //map.Kakao();
            map.bitQ2();

        }
    }
}
