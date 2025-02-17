namespace Day17
{
    internal class Program
    {

        class Singleton
        { 
            private Singleton() 
            {
            
            }

            static Singleton instance;

            static public Singleton GetInstance() {
                if (instance == null) { 
                    instance = new Singleton();
                }
                return new Singleton();
            }

        }


        static void Main(string[] args)
        {

            //Singleton s = new Singleton();

            //Singleton s1 = new Singleton.GetInstance();


            Engine engine = new Engine();

            engine.Load();

            engine.Run();


        }
    }
}
