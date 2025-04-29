namespace D20250429_1
{
    internal class BSTree
    {
        private BSTreeNode? _root = null;


        //Insert 새로운 데이터를 트리에 추가
        // 입력 : 새로운 정수 데이터
        // 출력 : 필요 없음

        public void Insert(int data)
        {
            //root가 null인가?
            //ㄴ 새로운 루트 노드 생성
            if (_root == null)
            {
                _root = new BSTreeNode(data, null, this);
            }
            else
            {
                _root.Insert(data);
            }
        }

        //InorderSearch : 트리를 중위 순회
        // 입력 : 필요없음
        //출력 : 필요없음
        public void InorderSearch()
        {
            if (_root == null)
            {
                return;
            }
            _root.InorderSearch();
        }

        public void LevelOrderSearch()
        {
            if (_root == null)
            {
                return;
            }
            Queue<BSTreeNode> qu = new();
            qu.Enqueue(_root);

            while (qu.Count > 0)
            {
                BSTreeNode node = qu.Dequeue();
                Console.WriteLine(node.Data);
                if (node.Left != null)
                {
                    qu.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    qu.Enqueue(node.Right);
                }
            }
        }

        //주어진 데이터가 트리에 존재하는지
        //입력 - 검사할 데이터
        //출력 - 존재 여부
        public bool Contains(int data)
        {

            if (_root == null)
            {
                return false;
            }


            return _root.Contains(data);
        }



        static void Main(string[] args)
        {
            BSTree tree = new();

            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);

            tree.LevelOrderSearch();

        }
    }

    //트리 노드 클래스
    class BSTreeNode
    {
        //private인 이유
        public int Data { get; init; }
        public BSTreeNode? Left { get; private set; }
        public BSTreeNode? Right { get; private set; }
        private BSTreeNode? _patents;
        private BSTree? _tree;

        public BSTreeNode(int data, BSTreeNode parent, BSTree tree)
        {
            Data = data;
            _patents = parent;
            _tree = tree;
        }

        //Insert : 새로운 데이터를 노드에 삽입 =>자신 보다 작은 값은 왼쪽, 큰값은 오른쪽에 삽입
        //입력 : 새로운 정수 데이터
        //출력 없음
        public void Insert(int data)
        {
            if (data > Data)
            {
                if (Right == null)
                {
                    Right = new BSTreeNode(data, this, _tree);
                }
                else
                {
                    Right.Insert(data);
                }
            }
            else
            {
                if (Left == null)
                {
                    Left = new BSTreeNode(data, this, _tree);
                }
                else
                {
                    Left.Insert(data);
                }
            }
        }

        public void InorderSearch()
        {
            if (Left != null)
            {
                Left.InorderSearch();
            }
            Console.WriteLine($"{Data}");

            if (Right != null)
            {
                Right.InorderSearch();
            }
        }

        public bool Contains(int data)
        {
            if (Data == data)
            {
                return true;
            }
            else if (Data > data)
            {
                if (Left == null)
                {
                    return false;
                }
                else
                {
                    return Left.Contains(data);
                }
            }
            else if (Data < data)
            {
                if (Right == null)
                {
                    return false;
                }
                else
                {
                    return Right.Contains(data);
                }
            }
            return false;
        }


    }


}

