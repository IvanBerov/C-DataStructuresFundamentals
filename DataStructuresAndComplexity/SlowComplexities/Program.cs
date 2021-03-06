using System;
using System.Diagnostics;

namespace SlowComplexities
{
    class Program
    {
        private static int count = 0;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Algorithm(n);

            watch.Stop();
            Console.WriteLine($"Count: { count }");
            Console.WriteLine($"Time {watch.ElapsedMilliseconds}");
        }

        // O(2^n)
        static void Algorithm(int n)
        {
            if (n == 0)
            {
                return;
            }

            for (int i = 0; i < n; i++)
            {
                Algorithm(n - 1);
            }
            count++;
            //Algorithm(n - 1);
        }
    }
}
