using System;

namespace DataComplexity
{
    public class Startup
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            // O(3 + 3n + 3(n^2))
            Console.WriteLine(3 + 3 * n + 3 * (n * n));

            //O(n^2)
            Console.WriteLine(n * n);

            Console.WriteLine(GetOperationCount(n));
        }

        static long GetOperationCount(long n)
        {
            long count = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
