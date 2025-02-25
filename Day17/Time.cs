using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public class Time
    {
        public static TimeSpan deltaTimeSpan;

        protected static DateTime currentTime;
        public static DateTime lastTime;
        public static float deltaTime
        {
            get
            {
                return (float)deltaTimeSpan.TotalMilliseconds;
            }
        }



        public static void Update()
        {
            currentTime = DateTime.Now;
            deltaTimeSpan = currentTime - lastTime;
            lastTime = currentTime;

        }

    }
}
