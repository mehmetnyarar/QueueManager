namespace QueueManager.Enums
{
    /// <summary>
    /// Command to be executed by the queue manager.
    /// </summary>
    public enum Execute
    {
        Nothing,
        Enqueue,
        Dequeue,
        SortById,
        SortByPhone
    }
}
