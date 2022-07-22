using System;
using System.Threading;

namespace SecondTask
{
    class Program
    {
        public class SecondTask
        {
            static readonly object bucket = new object();
            static readonly object rag = new object();

            static void ThreadJob()
            {
                Console.WriteLine("\t\tGoing to the bucket");
                lock (bucket)
                {
                    Console.WriteLine("\t\tThe bucket is occupied");
                    Thread.Sleep(1000);
                    Console.WriteLine("\t\tGoing to the rag");
                    lock (rag)
                    {
                        Console.WriteLine("\t\tThe rag is occupied");
                    }
                    Console.WriteLine("\t\tReleased rag");
                }
                Console.WriteLine("\t\tReleased bucket");
            }

            static void Main()
            {
                new Thread(new ThreadStart(ThreadJob)).Start();
                Thread.Sleep(500);
                Console.WriteLine("\t\tGoing to the rag");
                lock (rag)
                {
                    Console.WriteLine("\t\tThe rag is occupied");
                    Console.WriteLine("\t\tGoing to the bucket");
                    lock (bucket)
                    {
                        Console.WriteLine("\t\tThe bucket is occupied");
                    }
                    Console.WriteLine("\t\tReleased bucket");
                }
                Console.WriteLine("\t\tReleased rag");
                Console.Read();
            }
        }
    }

}
