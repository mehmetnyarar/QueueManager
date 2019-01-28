using QueueManager.Enums;

namespace QueueManager.Interfaces
{
    public interface IQueue<T> where T: IQueueItem
    {
        Execute Command { get; set; }
        int Print { get; set; }
        T[] Items { get; set; }


        Execute GetCommand(string value);
        T Dequeue();
        void Enqueue(T item);
        bool IsEmpty();
        int Size();
        void SortById();
        void Parse(string[] args);
        void Display();
        void Continuous();
    }
}
