using System;
using QueueManager.Enums;
using QueueManager.Interfaces;
using QueueManager.Utilities;

namespace QueueManager.Abstracts
{
    /// <summary>
    /// Generic queue manager.
    /// </summary>
    public abstract class Queue<T> : IQueue<T> where T : IQueueItem
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:QueueManager.MyQueue`1"/> class.
        /// </summary>
        protected Queue()
        {
            Command = Execute.Nothing;
            Print = 0;
            Items = new T[] { };
        }

        #endregion

        #region Properties

        /// <summary>
        /// Command to be executed.
        /// </summary>
        public Execute Command { get; set; }

        /// <summary>
        /// Number of items to be displayed.
        /// </summary>
        public int Print { get; set; }

        /// <summary>
        /// Queue items.
        /// </summary>
        public T[] Items { get; set; }


        #endregion

        #region Methods

        /// <summary>
        /// Determines the command to be executed.
        /// </summary>
        /// <param name="value">CLI command as string.</param>
        /// <returns>Command.</returns>
        public Execute GetCommand(string value)
        {
            switch (value)
            {
                case "-e": return Execute.Enqueue;
                case "-d": return Execute.Dequeue;
                case "-i": return Execute.SortById;
                case "-p": return Execute.SortByPhone;
                default: return Execute.Nothing;
            }
        }

        /// <summary>
        /// Removes the first item from the queue and returns the removed item.
        /// </summary>
        /// <returns>Removed item.</returns>
        public T Dequeue()
        {
            var item = Items[0];

            Items = Items.Remove(item);

            return item;
        }

        /// <summary>
        /// Adds a new item to the queue.
        /// </summary>
        /// <param name="item">Item.</param>
        public void Enqueue(T item)
        {
            Items = Items.AddOne(item);
        }

        /// <summary>
        /// Determines whether the queue is empty or not.
        /// </summary>
        /// <returns><c>true</c>, if the queue is empty, <c>false</c> otherwise.</returns>
        public bool IsEmpty()
        {
            return Items.Length == 0;
        }

        /// <summary>
        /// Determines the size of the queue.
        /// </summary>
        /// <returns>Number of items in the queue.</returns>
        public int Size()
        {
            return Items.Length;
        }

        /// <summary>
        /// Sorts queue item by their IDs.
        /// </summary>
        public void SortById()
        {
            Array.Sort(Items, (a, b) => string.Compare(
                a.Id, b.Id, StringComparison.Ordinal));
        }

        /// <summary>
        /// Initiliazes the queue manager via user input.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public abstract void Parse(string[] args);

        /// <summary>
        /// Displays queue items.
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Print: {0}", Print);

            var size = Size();
            var take = Print > size ? size : Print;
            var result = Items.Join(take);
            var allItems = Items.Join();

            Console.WriteLine("Output: {0}", result);
            Console.WriteLine("All items: {0}", allItems);
        }

        /// <summary>
        /// Continous dequeue and display.
        /// </summary>
        public abstract void Continuous();

        #endregion
    }
}
