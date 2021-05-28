using System;

namespace Lesson3
{
    class Program
    {
        enum Direction
        {
            BOTTOM,
            RIGHT
        }
        static void Main(string[] args)
        {
            //1
            var arr = new int[5,5];
            int xLast = arr.GetLength(0) - 1 , yLast = arr.GetLength(1) - 1;
            for (int i = 0; i <= xLast; i++)
            {
                arr[i, i] = 1;
                arr[i, xLast - i] = 1;

                for (var j = 0; j <= yLast; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }

            //2
            var phonebook = new string[5, 2]
            {
                { "Петя", "55" },
                { "Вася", "56" },
                { "Коля", "57" },
                { "Маша", "58" },
                { "Аня", "59" }
            };

            //3
            Console.WriteLine("\nВведите текст для разворота");
            var input = Console.ReadLine();

            Console.Write("Развернутый текст: ");

            for(var i = input.Length - 1; i >= 0; i--)
            {
                Console.Write(input[i]);
            }

            //4*
            Console.WriteLine("\n");
            var rectLength = 10;
            var seaBattleMap = new char[rectLength, rectLength];

            var ships = new (int, int, int, Direction)[]
            {
                (1, 2, 3, Direction.BOTTOM),
                (1, 4, 1, Direction.BOTTOM),
                (1, 6, 4, Direction.BOTTOM),
                (1, 9, 1, Direction.BOTTOM),
                (4, 8, 2, Direction.BOTTOM),
                (6, 1, 2, Direction.RIGHT),
                (7, 5, 3, Direction.RIGHT),
                (9, 1, 1, Direction.BOTTOM),
                (9, 5, 1, Direction.BOTTOM)
            };

            Action<int, int, int, Direction> drawShip = (i, j, length, dir) =>
             {
                 if(dir == Direction.BOTTOM)
                 {
                     if (i + length > rectLength || j >= rectLength)
                         return;


                     for (var k = 0; k < length; k++)
                     {
                         seaBattleMap[i + k, j] = 'X';
                     }
                 }
                 else
                 {
                     if (j + length > rectLength || i >= rectLength)
                         return;

                     for (var k = 0; k < length; k++)
                     {
                         seaBattleMap[i, j + k] = 'X';
                     }
                 }
             };
    
            foreach(var ship in ships)
            {
                drawShip(ship.Item1, ship.Item2, ship.Item3, ship.Item4);
            }

            for (var i = 0; i < rectLength; i++)
            {
                for (var j = 0; j < rectLength; j++)
                {
                    if (seaBattleMap[i, j] != 'X')
                        seaBattleMap[i, j] = 'О';
                    
                    Console.Write(seaBattleMap[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}

