using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace Day17
{
    public class SpriteRenderer : Component
    {
        public int orderLayer;
        public char Shape;  //Mesh, Sprite

        public int spriteSize = 30;
        public SDL.SDL_Color color;

        public int spriteIndexX = 0;
        public int spriteIndexY = 0;

        public SDL.SDL_Color colorKey;

        protected bool isAnimaion = false;
        protected IntPtr myTexture;
        protected IntPtr mySurface;

        protected string filename;

        private float elapsedTime = 0;

        SDL.SDL_Rect sourceRect;            //원본 이미지
        SDL.SDL_Rect destinationRect;        // 스크린 좌표계

        public float processTime = 100.0f;
        public int maxCellCountX = 5;
        public int maxCellCountY = 5;


        public SpriteRenderer()
        {

        }

        public SpriteRenderer(string inFilename, bool inIsAnimation = false)
        {
            LoadBmp(inFilename);
            isAnimaion = inIsAnimation;
        }

        public override void Update()
        {
            int X = gameObject.transform.X;
            int Y = gameObject.transform.Y;

            destinationRect.x = X * spriteSize;
            destinationRect.y = Y * spriteSize;
            destinationRect.w = spriteSize;
            destinationRect.h = spriteSize;

            unsafe
            {
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);

                spriteIndexY = 1;
                if (isAnimaion)
                {

                    if (elapsedTime >= processTime)
                    {
                        spriteIndexX++;
                        spriteIndexX = spriteIndexX % 5;
                        elapsedTime = 0;
                    }
                    else
                    {
                        elapsedTime += Time.deltaTime;
                    }

                    int cellSizeX = surface->w / maxCellCountX;
                    int cellSizeY = surface->h / maxCellCountY;
                    sourceRect.x = cellSizeX * spriteIndexX;
                    sourceRect.y = cellSizeY * spriteIndexY;
                    sourceRect.w = cellSizeX;
                    sourceRect.h = cellSizeY;
                }
                else
                {
                    sourceRect.x = 0;
                    sourceRect.y = 0;
                    sourceRect.w = surface->w;
                    sourceRect.h = surface->h;
                }

            }
        }

        public virtual void Render()
        {
            int X = gameObject.transform.X;
            int Y = gameObject.transform.Y;

            //Console
            Engine.backBuffer[Y, X] = Shape;

            unsafe
            {
                SDL.SDL_RenderCopy(Engine.Instance.myRenderer,
                    myTexture,
                    ref sourceRect,
                    ref destinationRect);
            }
        }



        public void LoadBmp(string inFilename, bool inIsAnimation = false)
        {
            string projectFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            isAnimaion = inIsAnimation;
            filename = inFilename;

            //SDL C, 접근 할 수 있는게 없어서
            mySurface = SDL.SDL_LoadBMP(projectFolder + "/data/" + filename);
            unsafe
            {
                //이미지 정보 가져와서 할일이 있음
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);
                SDL.SDL_SetColorKey(mySurface, 1, SDL.SDL_MapRGB(surface->format,
                    colorKey.r, colorKey.g, colorKey.b));
            }

            myTexture = SDL.SDL_CreateTextureFromSurface(Engine.Instance.myRenderer, mySurface);

        }

    }
}
