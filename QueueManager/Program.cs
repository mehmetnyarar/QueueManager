using System;
using QueueManager.Models;
using QueueManager.Utilities;

// Availabe commands:
// Enqueue          : -e <n> <phone_number_1> <phone_number_2> -c
// Dequeue          : -d
// Sort by id       : -i
// Sort by phone    : -p 
// 
//
// Examples         :
// -e 3 +11111111 +33333333 +99999999 +77777777 +55555555
// -e 5 +22222222 +88888888 +44444444 +66666666 +00000000 -c

namespace QueueManager
{
    class MainClass
    {

        /// <summary>
        /// Queue manager.
        /// </summary>
        static readonly MyQueue queue = new MyQueue();


        /// <summary>
        /// Queue runner.
        /// </summary>
        /// <returns>1 if.</returns>
        /// <param name="args">Arguments.</param>
        static int Run(string[] args = null)
        {
            // Ensure that the arguments are provided
            if (args.IsNullOrEmpty())
            {
                Console.WriteLine("");
                Console.WriteLine("Please provide the CLI arguments");
                Console.WriteLine("Available commands:");
                Console.WriteLine("Enqueue          : -e <n> <phone_number_1> <phone_number_2> [-c]");
                Console.WriteLine("  n              : number of phone numbers you wish to output");
                Console.WriteLine("  phone_number   : phone number in +70000000 format");
                Console.WriteLine("  -c             : continous dequeue and display");
                Console.WriteLine("Dequeue          : -d ");
                Console.WriteLine("Sort by id       : -i");
                Console.WriteLine("Sort by phone    : -p ");
                Console.WriteLine("");

                string input = Console.ReadLine();
                args = input.Split(' ');
            }


            try
            {
                // Parse arguments and display the queue
                queue.Parse(args);
            }
            catch (Exception ex)
            {
                // Re-run in case of parsing error
                Console.WriteLine("An error occured: {0}", ex.Message);
                return Run();
            }

            Console.WriteLine("Press 'q' to exit, or any key to continue...");

            // Exit the application if user presses the 'q', otherwise run again
            var key = Console.ReadKey();
            if (key.KeyChar == 'q') return 0;
            return Run();
        }

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Queue Manager!");

            while (Run(args) == 1) {};
            Environment.Exit(0);
        }
    }
}
