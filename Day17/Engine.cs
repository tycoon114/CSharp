using System;
using System.Diagnostics;
using SDL2;

namespace Day17
{
    public class Engine
    {

        protected bool isRunning = true;

        protected ConsoleKeyInfo keyInfo;

        static protected Engine instance;


        static public char[,] backBuffer = new char[20, 40];
        static public char[,] frontBuffer = new char[20, 40];


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

        public IntPtr myWindow;
        public IntPtr myRenderer;
        public SDL.SDL_Event myEvnet;

        Random random = new Random();

        public bool Init()
        {
            //엔진 초기화
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
            {
                Console.WriteLine("Init ERROR");
                return false;
            }

            // 창 생성
            myWindow = SDL.SDL_CreateWindow(
                "Game",
                100, 100,
                640, 480,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
                );

            myRenderer = SDL.SDL_CreateRenderer(myWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
               SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC |
               SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE);


            return true;
        }

        public bool Quit()
        {
            SDL.SDL_DestroyRenderer(myRenderer);
            SDL.SDL_DestroyWindow(myWindow);
            SDL.SDL_Quit();

            return true;
        }


        public void Load(string filename)
        {

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
                        GameObject player = new GameObject();
                        player.Name = "Player";
                        player.transform.X = x;
                        player.transform.Y = y;

                        player.AddComponent<PlayerController>(new PlayerController());
                        SpriteRenderer spriteRenderer = player.AddComponent<SpriteRenderer>(new SpriteRenderer());
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 0;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadBmp("player.bmp", true);
                        spriteRenderer.processTime = 150.0f;
                        spriteRenderer.maxCellCountX = 5;

                        spriteRenderer.Shape = 'P';

                        world.Instanciate(player);
                    }
                    else if (scene[y][x] == 'M')
                    {
                        GameObject monster = new GameObject();
                        monster.Name = "Monster";
                        monster.transform.X = x;
                        monster.transform.Y = y;

                        SpriteRenderer spriteRenderer = monster.AddComponent<SpriteRenderer>(new SpriteRenderer());
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 255;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadBmp("monster.bmp");

                        spriteRenderer.Shape = 'M';


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
            }
            world.Sort();

        }

        protected void Update()
        {
            world.Update();
        }

        protected void Render()
        {
            //색 설정
            SDL.SDL_SetRenderDrawColor(myRenderer, 0, 0, 0, 0);
            //위해서 지정한 색으로 지음( 채움)
            SDL.SDL_RenderClear(myRenderer);
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
            SDL.SDL_RenderPresent(myRenderer);

        }

        public void ProcessInput()
        {
            Input.Process();
        }



        public void Run()
        {

            Console.CursorVisible = false;
            while (isRunning)
            {
                SDL.SDL_PollEvent(out myEvnet);


                Time.Update();
                switch (myEvnet.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        isRunning = false;
                        break;
                }
                Update();
                Render();
            }

        }




        public World world;
    }
}
