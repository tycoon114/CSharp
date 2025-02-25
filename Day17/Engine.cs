using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public class Engine
    {

        protected bool isRunning = true;

        protected ConsoleKeyInfo keyInfo;

        static protected Engine instance;


        static public char[,] backBuffer = new char[40, 40];
        static public char[,] frontBuffer = new char[40, 40];


        static public Engine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }

                return instance;
            }
        }

        public void Load(string filename)
        {

            //string tempScene = "";
            //byte[] buffer = new byte[1024];
            //FileStream fs = new FileStream("level01.map", FileMode.Open);

            //fs.Seek(0, SeekOrigin.End);
            //long fileSize = fs.Position;

            //fs.Seek(0, SeekOrigin.Begin);
            //int readCount = fs.Read(buffer, 0, (int)fileSize);
            //tempScene = Encoding.UTF8.GetString(buffer);
            //tempScene = tempScene.Replace("\0", "");
            //string[] scene = tempScene.Split("\r\n");

            List<string> scene = new List<string>();

            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                scene.Add(sr.ReadLine());
            }
            sr.Close();



            world = new World();



            for (int y = 0; y < scene.Count; y++)
            {
                for (int x = 0; x < scene[y].Length; x++)
                {
                    if (scene[y][x] == '*')
                    {
                        Wall wall = new Wall(x, y, scene[y][x]);
                        wall.X = x;
                        wall.Y = y;
                        world.Instanciate(wall);
                    }
                    else if (scene[y][x] == ' ')
                    {
                        //Floor floor = new Floor(x, y, scene[y][x]);
                        //floor.X = x;
                        //floor.Y = y;
                        //world.Instanciate(floor);
                    }
                    else if (scene[y][x] == 'P')
                    {
                        Player player = new Player(x, y, scene[y][x]);
                        world.Instanciate(player);
                    }
                    else if (scene[y][x] == 'M')
                    {
                        Monster monster = new Monster(x, y, scene[y][x]);
                        world.Instanciate(monster);
                    }
                    else if (scene[y][x] == 'G')
                    {
                        Goal goal = new Goal(x, y, scene[y][x]);
                        world.Instanciate(goal);
                    }
                    Floor floor = new Floor(x, y, ' ');
                    world.Instanciate(floor);
                }

                world.Sort();

            }
            //로딩 끝
            //정렬 시작


        }

        protected void Update()
        {
            world.Update();
        }

        protected void Render()
        {
            //Console.Clear();
            world.Render();

            //IO 제일 느리다. 특히 모니터 출력 

            for (int Y = 0; Y < 20; ++Y)
            {
                for (int X = 0; X < 40; ++X)
                {

                    if (Engine.frontBuffer[Y, X] != Engine.backBuffer[Y, X])
                    {
                        Engine.frontBuffer[Y, X] = Engine.backBuffer[Y, X];
                        Console.SetCursorPosition(X, Y);
                        Console.Write(backBuffer[Y, X]);
                    }

                }
            }

        }

        public void ProcessInput()
        {
            Input.Process();
        }



        public void Run()
        {
            float frameTime = 1000.0f / 60.0f;
            float elpaseTime = 0.0f;
            Console.CursorVisible = false;
            while (isRunning)
            {

                Time.Update();
                if (elpaseTime >= frameTime)
                {
                    ProcessInput();
                    Update();
                    Render();
                    Input.ClearInput();
                    elpaseTime = 0;
                }
                else
                {
                    elpaseTime += Time.deltaTime;
                }

            }
        }



        public World world;
    }
}
