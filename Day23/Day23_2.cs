using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23
{
    internal class Day23_2
    {
        class DynamicArray<T> : IEnumerable
        {
            protected T[] data;
            protected int count;

            public DynamicArray()
            {
                data = new T[10];
                count = 0;
            }

            public void Add(T newData)
            {
                if (count >= data.Length)
                {
                    T[] newArray = new T[data.Length * 2];
                    Array.Copy(data, newArray, data.Length);
                    data = newArray;
                }
                data[count] = newData;
                count++;
            }

            //[][][2][][][]
            public void RemoveAt(int index)
            {
                for (int i = index + 1; i < data.Length; ++i)
                {
                    data[i - 1] = data[i];
                }
                count--;
            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public T this[int index]
            {
                get
                {
                    return data[index];
                }

                set
                {
                    data[index] = value;
                }
            }

            public int Count
            {
                get
                {
                    return count;
                }
            }
        }

        public abstract class Animal
        {
            public abstract void Eat();

            public void Do()
            {

            }

            public int legs;
        } //-> 다중 상속, C# 다중 상속이 안되, 

        public interface 네발달린짐승
        {
            void Run();
        }

        public interface 새
        {
            void Fly();
        }

        class Lion : Animal, 네발달린짐승
        {
            public override void Eat()
            {

            }

            public void Run()
            {
            }
        }

        class Tiger : Animal, 네발달린짐승
        {
            public override void Eat()
            {

            }

            public void Run()
            {
            }
        }

        class Chciken : Animal, 새
        {
            public override void Eat()
            {
            }

            public void Fly()
            {
                Console.WriteLine("조금 난다.");
            }
        }

        //다중 상속, C++, Diamond, interface X
        //class Liger : Lion, Tiger
        //{

        //}

        //C#, java

        //혼자 만들면 안 씀 -> 다 같이 만든다. -> 다른 놈을 믿을 수 없다.
        public interface IItem
        {
            void Use();
        }

        public interface IEatable
        {
            void Use();
        }

        public class Position : IItem, IEatable
        {
            public void Use()
            {
                throw new NotImplementedException();
            }
        }

        public class Sword : IItem
        {
            public void Use()
            {
                throw new NotImplementedException();
            }
        }


        class Program
        {
            static void Main2(string[] args)
            {
                List<int> list = new List<int>();
                list.Add(1);
                list.Add(2);
                list.Add(3);
                list.Add(4);
                list.Add(1);
                list.Add(2);
                list.Add(3);
                list.Add(4);
                list.Add(1);
                list.Add(2);
                list.Add(3);
                list.Add(4);

                list.RemoveAt(11);

                //for (int i = 0; i < list.Count; ++i)
                //{
                //    Console.WriteLine(list[i]);
                //}

                //range for
                foreach (int value in list)
                {
                    Console.WriteLine(value);
                }

                DynamicArray<int> dynamicArray = new DynamicArray<int>();
                dynamicArray.Add(1);
                dynamicArray.Add(2);
                dynamicArray.Add(3);
                dynamicArray.Add(4);
                dynamicArray.Add(1);
                dynamicArray.Add(2);
                dynamicArray.Add(3);
                dynamicArray.Add(4);
                dynamicArray.Add(1);
                dynamicArray.Add(2);
                dynamicArray.Add(3);
                dynamicArray.Add(4);

                dynamicArray.RemoveAt(11);
                foreach (int value in dynamicArray)
                {
                    Console.WriteLine(value);
                }
            }

            class Component
            {
                public virtual void OnTriggerEnter() { }
                public virtual void OnTriggerExt() { }
            }

            //함수 강제 구현, 다중 상속
            static void Main(string[] args)
            {
                Object position = new Position();
                Type type = position.GetType();
                if (typeof(Position) == type.GetInterface("IItem"))
                {
                    (position as Position).Use();
                }

                List<IItem> items = new List<IItem>();
                items.Add(new Position());
                items.Add(new Sword());
                foreach (var item in items)
                {
                    item.Use();
                }
            }
        }


    }
}
