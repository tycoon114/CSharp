using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace Day17
{
    public class PlayerController : Component
    {
        public override void Update()
        {

            if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_w) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_UP))
            {
                //if (!PredictCollision(X, Y - 1))
                //{
                //    Y--;
                //}

            }

            if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_a) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_LEFT))
            {
                //if (!PredictCollision(X - 1, Y))
                //{
                //    X--;
                //}
            }

            if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_s) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_DOWN))
            {
                //if (!PredictCollision(X, Y + 1))
                //{
                //    Y++;
                //}
            }

            if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_d) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_RIGHT))
            {
                //if (!PredictCollision(X + 1, Y))
                //{
                //    X++;
                //}
            }
        }


    }
}
