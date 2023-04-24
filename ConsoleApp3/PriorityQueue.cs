using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class PriorityQueue<TElement>
    {
        private struct Node
        {
            public TElement element;
            public int priority;
        }

        private List<Node> nodes;
        // 구조체 Node를 List에 넣어줌

        public PriorityQueue()
        {
            this.nodes = new List<Node>();
        }
        public int Count { get { return nodes.Count; } }
        // nodes의 요소값을 반환

        public void Enqueue(TElement element, int priority)
        {
            Node newNode = new Node() { element = element, priority = priority };
            // Node를 newNode로 새로 선언하고 Node 안에element, priority를 포함한다

            nodes.Add(newNode);
            int newNodeIndex = nodes.Count - 1;
            // newNodeIndex는 노드의 배열값에서 1을 감소함

            while (newNodeIndex > 0)
            // 새로운 노드를 힙상태가 유지되도록 승격 작업 반복
            {
                int parentIndex = GetParentIndex(newNodeIndex);
                Node parentNode = nodes[parentIndex];

                if (newNode.priority < parentNode.priority)
                {
                    nodes[newNodeIndex] = parentNode;
                    nodes[parentIndex] = newNode;
                    newNodeIndex = parentIndex;
                }
                else
                {
                    break;
                    // 자식이 없는 경우는 여기서 끝낸다
                }
            }
        }
        public TElement Dequeue()
        {
            Node rootNode = nodes[0];
            Node lastNode = nodes[nodes.Count - 1];
            nodes[0] = lastNode;
            nodes.RemoveAt(nodes.Count - 1);

            int index = 0;
            while (index < nodes.Count)
            {
                int lefrChildIndex = GetLeftChildIndex(index);
                int rightChildIndex = GetRightChildIndex(index);

                if (rightChildIndex < nodes.Count)
                {
                    int lessChildIndex = nodes[lefrChildIndex].priority < nodes[rightChildIndex].priority
                        ? lefrChildIndex : rightChildIndex;

                    if (nodes[lessChildIndex].priority < nodes[index].priority)
                    {
                        nodes[index] = nodes[lefrChildIndex];
                        nodes[lessChildIndex] = lastNode;
                        index = lessChildIndex;
                    }
                }
                else if (lefrChildIndex < nodes.Count)
                {
                    if (nodes[lefrChildIndex].priority < nodes[index].priority)
                    {
                        nodes[index] = nodes[lefrChildIndex];
                        nodes[lefrChildIndex] = lastNode;
                        index = lefrChildIndex;
                    }
                }
                else
                {
                    break;
                }
            }

            return rootNode.element;
        }
        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }
        public TElement Peek()
        {
            return nodes[0].element;
        }
        public int GetLeftChildIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }
        private int GetRightChildIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }
    }
}