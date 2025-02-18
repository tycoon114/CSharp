using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    public class Input
    {
        static protected ConsoleKeyInfo ConsoleKeyInfo;

        public Input() 
        { 
        
        }
        static public void Process() { 
            ConsoleKeyInfo = Console.ReadKey();

        }

        static public bool GetKeyDown(ConsoleKey key)
        {
            return (ConsoleKeyInfo.Key == key);
        }

    }
}
