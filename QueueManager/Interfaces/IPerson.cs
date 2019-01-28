namespace QueueManager.Interfaces
{
    public interface IPerson: IQueueItem
    {
        string PhoneNumber { get; set; }
    }
}
