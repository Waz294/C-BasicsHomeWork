using System;

namespace Lesson8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1st dimention");
            var x = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter 2nd dimention");
            var y = int.Parse(Console.ReadLine());

            var arr = new int[x, y];

            {
                int i = 0, j, k = 0, p = 1;

                while (i < x * y)
                {
                    k++;
                    for (j = k - 1; j < y - k + 1; j++)
                    {
                        arr[k - 1, j] = p++;
                        i++;
                    }   

                    for (j = k; j < x - k + 1; j++)
                    {
                        arr[j, y - k] = p++;
                        i++;
                    }   

                    for (j = y - k - 1; j >= k - 1; j--)
                    {
                        arr[x - k, j] = p++;
                        i++;
                    }  

                    for (j = x - k - 1; j >= k; j--)
                    {
                        arr[j, k - 1] = p++;
                        i++;
                    }   

                }
            }

            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    Console.Write($"{arr[i,j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
