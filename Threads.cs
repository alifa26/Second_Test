using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Threads
    {
        private static int counter = 0; // Shared variable
        private static readonly object lockObject = new object(); // Lock object for synchronization

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(IncrementCounter);
            Thread thread2 = new Thread(IncrementCounter);

            thread1.Start();
            thread2.Start();

            // Wait for both threads to finish
            thread1.Join();
            thread2.Join();

            Console.WriteLine("Final counter value: " + counter);
        }

        static void IncrementCounter()
        {
            for (int i = 0; i < 100; i++)
            {
                lock (lockObject) // Locking to ensure only one thread can access the counter at a time
                {
                    counter++;
                }
            }
        }
    }