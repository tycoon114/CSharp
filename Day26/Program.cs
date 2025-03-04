using SDL2;
using System;
using static SDL2.SDL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day26
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();

            //엔진 초기화
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0) {
                Console.WriteLine("Init ERROR");
            }

            // 창 생성
            IntPtr myWindow = SDL.SDL_CreateWindow(
                "Game",
                100, 100,
                640, 480,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
                );

            SDL.SDL_Event myEvnet;
            bool isRunning = true;

            //메세지 처리 ( 사용자 처리가 추가 구조를 바꿈)
            while (isRunning) {

                
                //메세지(이벤트)가 있는지 가져온다. (게임에서는 PeekMesssage를 사용)
                SDL.SDL_PollEvent(out myEvnet);

                //그리기  -1 -> 가장 먼저 그린다.
                //SDL_RENDERER_SOFTWARE -> CPU가 직접 그린다. 성능 안좋음, ACCELETATED ->GPU가 그림,
                //SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC - 수직 동기화?
                //SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE - 메모리에도 그린다?
                IntPtr myRenderer = SDL.SDL_CreateRenderer(myWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
                    SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC |
                    SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE);

                // 종료 버튼
                switch (myEvnet.type) {
                    case SDL.SDL_EventType.SDL_QUIT:
                        isRunning = false; 
                        break;
                }

                //색 설정
                SDL.SDL_SetRenderDrawColor(myRenderer, 0, 51, 102, 0);
                //위해서 지정한 색으로 지음( 채움)
                SDL.SDL_RenderClear(myRenderer);
                //GPU한테 위를 시킴
                SDL.SDL_RenderPresent(myRenderer);


                //사각형 100개 그리기 + 원 그리기
                for (int i = 0; i < 100; ++i)
                {
                    byte r = (byte)(random.Next() % 256);
                    byte g = (byte)(random.Next() % 256);
                    byte b = (byte)(random.Next() % 256);


                    SDL.SDL_Rect myRect;
                    myRect.x = random.Next() % 640 - 200;
                    myRect.y = random.Next() % 480 - 200;
                    myRect.w = random.Next() % 640;
                    myRect.h = random.Next() % 480;

                    //색상 랜덤 설정
                    SDL.SDL_SetRenderDrawColor(myRenderer, r, g, b, 0);

                    int type = random.Next() % 3;
                    switch (type)
                    {
                        case 0:
                         //   SDL.SDL_RenderDrawRect(myRenderer, ref myRect);
                            break;
                        case 1:
                           // SDL.SDL_RenderFillRect(myRenderer, ref myRect);
                            break;
                        case 2:
                            int step = 10;
                            int x0 = myRect.x;
                            int y0 = myRect.y;

                            double radius = myRect.w;

                            //시작 값
                            int prevX = (int)(radius * Math.Cos(0 * (Math.PI / 180.0f)));
                            int prevY = (int)(radius * Math.Sin(0 * (Math.PI / 180.0f)));
                            for (int angle = 1; angle <= 360 + step; angle += step)
                            {
                                int x = (int)(radius * Math.Cos(angle * (Math.PI / 180.0f)));
                                int y = (int)(radius * Math.Sin(angle * (Math.PI / 180.0f)));

                                //SDL.SDL_RenderDrawPoint(myRenderer, x0 + x, y0 + y);
                                SDL.SDL_RenderDrawLine(myRenderer, x0 + prevX, y0 + prevY, x0 + x, y0 + y);
                                prevX = x;
                                prevY = y;
                            }
                            break;
                    }
                }




                //원 그리기
                //double radius = 100.0f;

                //int x0 = 320;
                //int y0 = 240;
                //시작값
                //int prevX = (int)(radius * Math.Cos(0 * (Math.PI / 180.0f)));
                //int prevY = (int)(radius * Math.Sin(0 * (Math.PI / 180.0f)));

                //for (int i = 1; i <= 370; i+=10) {
                //    int x = (int)(radius * Math.Cos(i * (Math.PI / 180.0f)));
                //    int y = (int)(radius * Math.Sin(i * (Math.PI / 180.0f)));
                //    SDL.SDL_RenderDrawLine(myRenderer, x0 + prevX, y0 +prevY, x0 +x , y0 +y);
                //    prevX = x;
                //    prevY = y;
                //}


               

                SDL.SDL_RenderPresent(myRenderer);




            }


            // 메모리에서 삭제 ( 종료)
            SDL.SDL_DestroyWindow(myWindow);

            //Init 한것을 종료
            SDL.SDL_Quit();

        }
    }
}
