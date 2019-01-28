using System;
using QueueManager.Abstracts;
using QueueManager.Enums;
using QueueManager.Interfaces;
using QueueManager.Utilities;

namespace QueueManager.Models
{
    /// <summary>
    /// Queue manager for persons.
    /// </summary>
    public class MyQueue: Queue<IPerson>, IPersonQueue
    {
        #region Methods

        /// <summary>
        /// Initiliazes the queue manager via user input.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public override void Parse(string[] args)
        {
            // Check whether command is specified
            Command = GetCommand(args[0]);
            if (Command == Execute.Nothing)
            {
                throw new Exception("Please provide a command to be executed.");
            }

            // Execute the command given by the user
            switch (Command)
            {
                case Execute.Enqueue:
                    // Check whether the first argument is number
                    if (!int.TryParse(args[1], out int print))
                    {
                        throw new Exception("Number of prints couldn't be determined.");
                    }

                    // Check whether there are items to enqueue
                    if (args.Length < 3)
                    {
                        throw new Exception("There are no items to enqueue.");
                    }

                    // Update queue
                    Print = print;
                    for (var i = 2; i < args.Length; i++)
                    {
                        if (args[i] != "-c")
                        {
                            Enqueue(new Person(args[i]));
                        }                
                    }

                    // Continuous dequeue and display
                    if (args.Contains("-c"))
                    {
                        Continuous();
                    }
                    else
                    {
                        Display();
                    }

                    break;
                case Execute.Dequeue:
                    var removedItem = Dequeue();
                    Console.WriteLine("Removed item: {0}", removedItem.PhoneNumber);
                    Display();
                    break;
                case Execute.SortById:
                    SortById();
                    Display();
                    break;
                case Execute.SortByPhone:
                    SortByPhoneNumber();
                    Display();
                    break;
            }
        }

        /// <summary>
        ///  Sorts persons by their phone numbers.
        /// </summary>
        public void SortByPhoneNumber()
        {
            Array.Sort(Items, (a, b) => string.Compare(
                a.PhoneNumber, b.PhoneNumber, StringComparison.Ordinal));
        }

        /// <summary>
        /// Continous dequeue and display.
        /// </summary>
        public override void Continuous()
        {
            while (!IsEmpty())
            {
                Console.WriteLine("");
                Console.WriteLine("Queue size: {0}", Size());
                Display();
                var removedItem = Dequeue();
                Console.WriteLine("Removed item: {0}", removedItem.PhoneNumber);
                Console.WriteLine("");
            }
        }


        #endregion
    }
}
