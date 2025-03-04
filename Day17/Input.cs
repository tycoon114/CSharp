using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;


namespace Day17
{
    public class Input
    {
        public Input()
        {

        }

        static public void Process() {

            //if (Console.KeyAvailable)
            //{
            //    keyInfo = Console.ReadKey(true);
            //}
        }


        static protected ConsoleKeyInfo keyInfo;

        static public bool GetKeyDown(ConsoleKey key) { 
        
            return (keyInfo.Key == key);
        }

        static public bool GetKeyDown(SDL.SDL_Keycode key) {


           return (Engine.Instance.myEvnet.key.keysym.sym == key);

        }


         public static void ClearInput()
        {
          keyInfo = new ConsoleKeyInfo();
        }
    }
}
