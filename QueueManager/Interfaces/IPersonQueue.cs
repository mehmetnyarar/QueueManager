namespace QueueManager.Interfaces
{
    public interface IPersonQueue: IQueue<IPerson>
    {
        void SortByPhoneNumber();
    }
}
