using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public class AIController : Component
    {



        private float elapsedTime = 0;
        private Random rand = new Random();

        public CharacterController2D characterController2D;

        public override void Awake()
        {
            characterController2D = GetComponent<CharacterController2D>();
        }



        public override void Update()
        {
            return;
            if (elapsedTime >= 500.0f)
            {
                int Direction = rand.Next(0, 4);

                if (Direction == 0)
                {
                    characterController2D.Move(0, -1);
                }
                if (Direction == 1)
                {
                    characterController2D.Move(-1, 0); 

                }
                if (Direction == 2)
                {
                    transform.Translate(0, 1);
                }
                if (Direction == 3)
                {
                    characterController2D.Move(1, 0);
                }
                elapsedTime = 0;
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
            Console.SetCursorPosition(30, 10);
            Console.Write(Time.deltaTime);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            Console.WriteLine($"겸침 감지 : {other.gameObject.Name}");
        }
    }
}
