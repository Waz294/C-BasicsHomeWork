using System;
using System.Diagnostics;
using System.Linq;

namespace Lesson6
{
    public class MyArraySizeException : Exception
    {

    }

    public class MyArrayDataException : Exception
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Process[] allProcesses = Process.GetProcesses();
            Console.WriteLine($"ID\tProcess Name");

            allProcesses = allProcesses.OrderBy(x => x.Id).ToArray();

            foreach(var item in allProcesses)
                Console.WriteLine($"{item.Id}\t{item.ProcessName}");

            Console.WriteLine("\nChoose process to kill (enter ID or Name):");

            var input = Console.ReadLine();

            if (input != "")
            {
                var proc = allProcesses.FirstOrDefault(x =>
                    {
                        if (x.ProcessName == input)
                            return true;

                        int res = -1;
                        try
                        {
                            res = int.Parse(input);
                        }
                        catch (FormatException)
                        {
                            return false;
                        }

                        if (x.Id == res)
                            return true;

                        return false;
                    });

                if (proc != null)
                {
                    proc.Kill();
                }
            }

            string[,] arr = new string[,]
            {
                { "1", "2", "3", "5" },
                { "1", "2", "2", "3" },
                { "1", "2", "4", "3" },
                { "1", "2", "1", "3" }
            };

            try
            {
                Console.WriteLine(sumElementsOfArray(arr));
            }
            catch (MyArraySizeException e)
            {
                Console.WriteLine("Incorrect array size!");
                Console.WriteLine(e.StackTrace);
            }
            catch(MyArrayDataException e)
            {
                Console.WriteLine("Could not convert string to int!");
                Console.WriteLine(e.StackTrace);
            }
        }

        static int sumElementsOfArray(string[,] arr)
        {
            if(arr.GetLength(0) != 4 || arr.GetLength(1) != 4)
            {
                throw new MyArraySizeException();
            }

            int sum = 0;

            for(var i = 0; i < arr.GetLength(0); i++)
            {
                for(var j = 0; j < arr.GetLength(1); j++)
                {
                    try
                    {
                        sum += int.Parse(arr[i, j]);
                    }
                    catch(FormatException)
                    {
                        throw new MyArrayDataException();
                    }
                }
            }

            return sum;
        }
    }
}
