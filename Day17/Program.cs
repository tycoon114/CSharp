using System.Text;

namespace Day17
{
    internal class Program
    {

        //Network에 접속 했지만 비밀번호가 틀리다.

        class CustomException : Exception
        {
            public CustomException() : base("이거 내가 만든 예외")
            {
            }
        }

        class WrongPasswordException : Exception
        {
            public WrongPasswordException() : base("비번 틀림")
            {
            }
        }


        class Singleton
        {
            private Singleton()
            {

            }

            static Singleton instance;

            static public Singleton GetInstance()
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return new Singleton();
            }

        }


        static void Main(string[] args)
        {

            Engine.Instance.Load("level01.map");
            Engine.Instance.Run();

            //Singleton s = new Singleton();

            //Singleton s1 = new Singleton.GetInstance();
            //Engine.Instance.Load("level02.map");
            //Engine.Instance.Run();


            //Engine engine = new Engine();


            //engine.Load();

            //engine.Run();



            //StreamReader sr = null;
            //try
            //{
            //    List<string> scene = new List<string>();

            //    sr = new StreamReader("level01.map");
            //    while (!sr.EndOfStream)
            //    {
            //        scene.Add(sr.ReadLine());
            //    }

            //}
            //catch (FileNotFoundException e)
            //{
            //    Console.WriteLine(e.FileName);
            //    Console.WriteLine(e.Source);
            //    Console.WriteLine(e.Message);
            //}
            //catch (WrongPasswordException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    //network, file 입출력
            //    Console.WriteLine("finally");
            //    sr.Close();
            //}
        }



    }
}
