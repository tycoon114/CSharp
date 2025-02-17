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

        public void ProcessInput() 
        {
            Input.Process();
        }

        public void Load() {

            //파일에서 로딩하면 되는데, 지금 예시로는 하드코딩 처리
            string[] scene = { "**********",
                               "*P       *",
                               "*        *",
                               "*        *",
                               "*   M    *",
                               "*        *",
                               "*        *",
                               "*        *",
                               "*       G*",
                               "**********"};
            world = new World();

            for (int y = 0; y < scene.Length; y++) {
                for (int x = 0; x < scene[y].Length; x++) {
                    if (scene[y][x] == '*')
                    {
                        Wall wall = new Wall(x, y, scene[y][x]);
                        wall.X = x;
                        wall.Y = y;
                        world.Instanciate(wall);
                    }
                    else if (scene[y][x] == ' ') { 
                        Floor floor = new Floor(x, y, scene[y][x]);
                        floor.X = x;
                        floor.Y = y;
                        world.Instanciate(floor);
                    }
                    else if (scene[y][x] == 'P')
                    {
                        Player player = new Player(x, y, scene[y][x]);
                        player.X = x;
                        player.Y = y;
                        world.Instanciate(player);
                    }
                    else if (scene[y][x] == 'M')
                    {
                        Monster monster = new Monster(x, y, scene[y][x]);
                        monster.X = x;
                        monster.Y = y;
                        world.Instanciate(monster);
                    }
                    else if (scene[y][x] == 'G')
                    {
                        Goal goal = new Goal(x, y, scene[y][x]);
                        goal.X = x;
                        goal.Y = y;
                        world.Instanciate(goal);
                    }
                }
            
            }

        }

        protected void Update()
        { 
            world.Update();
        }

        protected void Render()
        {
            Console.Clear();
            world.Render();
        }


        public void Run()
        {
            while (isRunning) { 
                ProcessInput();
                Update();
                Render();
            }
        }



        public World world;
    }
}
