﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public class Input
    {
        public Input()
        {

        }

        static public void Process() { 
        
            keyInfo = Console.ReadKey();
        }


        static protected ConsoleKeyInfo keyInfo;

        static public bool GetKeyDown(ConsoleKey key) { 
        
            return (keyInfo.Key == key);
        }




    }
}
