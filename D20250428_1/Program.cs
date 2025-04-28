using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


//MinHeap 구현
namespace D20250428_1
{
    internal class Program
    {
        //완전 이진 트리를 배열로 구현
        static List<int> _tree = new List<int>();

        //Peek 최소 원소 반환
        //입력 필요 없음
        //출력 : 최소 원소 => 루트 노드의 값 => 0번

        static public int Peek()
        {
            return _tree[0];
        }



        //Enqueue  힙에 원소 삽입
        // 입력 : 새로운 데이터
        // 출력 : 없음
        //예외 : 중복데이터? -> 중복은 허용
        static public void Enqueue(int data)
        {
            // 1.맨 끝에 새로운 데이터 삽입
            _tree.Add(data);

            // 2. 힙의 불변성이 지켜질 때까지
            // ㄴ 2.1 부모와 자식을 비교해서 바꾼다. -> 자식이 더 작다면? 부모와 바꾼다.
            //for (int i = 0; i < _tree.Count; i++)
            {
                //if (_tree[i] < _tree[i*2] && i*2<_tree.Count)
                //{
                //    int temp = _tree[i];
                //    _tree[i] = _tree[i*2];
                //    _tree[i * 2] = temp;

                //}
                //if (_tree[i] < _tree[i *2 +1] && i * 2 < _tree.Count)
                //{
                //    int temp = _tree[i];
                //    _tree[i] = _tree[i * 2 + 1];
                //    _tree[i * 2 + 1] = temp;
                //}
            }

            int current = _tree.Count;
            while (current != 1)
            {
                //부모는 current /2 
                int parent = current / 2;
                if (_tree[current - 1] < _tree[parent - 1])
                {
                    int temp = _tree[current - 1];
                    _tree[current - 1] = _tree[parent - 1];
                    _tree[parent - 1] = temp;
                }
                current = parent;
            }
        }



        //Dequeue 힙에서 원소 삭제
        //입력 없음
        //출력 : 삭제된 데이터 - 최소원소 - 루트노드
        static public int Dequeue()
        {
            // 1. 힙에서 루트 삭제
            int data = _tree[0];

            // 2. 마지막 원소를 루트 노드로 이동
            _tree[0] = _tree[_tree.Count - 1];
            _tree.RemoveAt(_tree.Count - 1);
            // 3. 힙의 불변성을 만족할 때가지
            // ㄴ 3.1 부모와 두 자식중 최솟값과 교환
            int current = 1;
            while (current > _tree.Count)
            {
                int child = current * 2;
                int min;

                if (_tree[child-1] > _tree[child])
                {
                    min = child - 1;
                }
                else
                {
                    min = child;
                }


                if (_tree[current - 1] > _tree[min])
                {
                    int temp = _tree[current - 1];
                    _tree[current - 1] = _tree[min];
                    _tree[min] = temp;
                }
                current = min;
            }

            // 4. 삭제한 원소를 반환한다.
            return data;
        }

        static void Main(string[] args)
        {
            Enqueue(4);
            Enqueue(5);
            Enqueue(3);
            Enqueue(1);
            Enqueue(2);

            Console.WriteLine(Dequeue());
            Console.WriteLine(Dequeue());
            Console.WriteLine(Dequeue());
            Console.WriteLine(Dequeue());
            Console.WriteLine(Dequeue());
        }
    }
}
