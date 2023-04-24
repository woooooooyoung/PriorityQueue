namespace PriorityQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<string, int> queue = new PriorityQueue<string, int>();
            // 노드의 이름과 우선순위를 새로 선언

            queue.Enqueue("앞", 10);
            queue.Enqueue("앞앞", 20);
            queue.Enqueue("앞앞앞", 30);
            queue.Enqueue("앞앞앞앞", 40);
            queue.Enqueue("앞앞앞앞앞", 50);
            queue.Enqueue("앞앞앞앞앞앞", 60);
            queue.Enqueue("앞앞앞앞앞앞앞", 70);
            queue.Enqueue("앞앞앞앞앞앞앞앞", 80);
            queue.Enqueue("앞앞앞앞앞앞앞", 90);
            queue.Enqueue("앞앞앞앞앞앞", 100);
            queue.Enqueue("앞앞앞앞앞", 110);
            queue.Enqueue("앞앞앞앞", 120);
            queue.Enqueue("앞앞앞", 130);
            queue.Enqueue("앞앞", 140);
            queue.Enqueue("앞", 150);
            queue.Enqueue("뒤", 9);
            queue.Dequeue();



            while (queue.Count > 0)
            {

                Console.WriteLine(queue.Dequeue());
                Console.WriteLine(queue.Dequeue());

            }
        }
    }
}
