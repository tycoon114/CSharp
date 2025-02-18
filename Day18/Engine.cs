using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    public class Engine
    {

        public World? world;

        public bool isRunning = true;

        public void GetInput()
        {
            Input.Process();
        }


        public void Load()
        {
            string[] map1 =
            {   "**********",
                "*P       *",
                "*        *",
                "*        *",
                "*        *",
                "*        *",
                "*    M   *",
                "*        *",
                "*       G*",
                "**********"
            };
            world = new World();

            for (int y = 0; y < map1.Length; y++)
            {
                for (int x = 0; x < map1[y].Length; x++)
                {
                    if (map1[y][x] == '*')
                    {
                        Wall wall = new Wall(x, y, map1[y][x]);
                        wall.X = x;
                        wall.Y = y;
                        world.Instanciate(wall);
                    }
                    else if (map1[y][x] == ' ')
                    {
                        Floor floor = new Floor(x, y, map1[y][x]);
                        floor.X = x;
                        floor.Y = y;
                        world.Instanciate(floor);
                    }
                    else if (map1[y][x] == 'P')
                    {
                        Player player = new Player(x, y, map1[y][x]);
                        player.X = x;
                        player.Y = y;
                        world.Instanciate(player);
                    }
                    else if (map1[y][x] == 'M')
                    {
                        Monster monster = new Monster(x, y, map1[y][x]);
                        monster.X = x;
                        monster.Y = y;
                        world.Instanciate(monster);
                    }
                    else if (map1[y][x] == 'G')
                    {
                        Goal goal = new Goal(x, y, map1[y][x]);
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

        public void Render()
        {
            Console.Clear();
            world.Render();
        }

        public void Run()
        {
            while (isRunning)
            {
                GetInput();
                Update();
                Render();
            }
        }


        public void isCollison() { 
            //몬스터에 닿으면 GameOver 부르기

            //골에 닿으면 Clear
        }


        public void GameOver()
        {
            isRunning = false;
        }

        public void Clear() { 
            Console.Clear();
            Console.WriteLine("Clear!");

        }


        //충돌 판정 - 몬스터나 플레이어가 *에 닿으면 마지막 위치 랜더링 -> 충돌하면 해당 오브젝트는 움직임 없음
        //          - 몬스터에 닿으면 게임오버 출력, 골에 닿으면 win 춣력
        // isWall -false  , 벽에 닿으면 업데이트 처리 X, 

    }
}
