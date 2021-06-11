using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    class Field
    {
        public char EmptySymbol { get; set; }
        public int Size { get; set; }
        
        public int winLength { get; set; }

        private char[,] field;

        public char[,] GetField
        {
            get
            {
                return field;
            }
        }

        public Field(char EmptySymbol, int fieldSize, int winLength)
        {
            this.EmptySymbol = EmptySymbol;
            Size = fieldSize;
            this.winLength = winLength;
            InitField();
        }

        private void InitField()
        {
            field = new char[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    field[i, j] = EmptySymbol;
                }
            }
        }

        private bool IsFieldFull()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (field[i, j] == EmptySymbol)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void runGame(Player p1, Player p2)
        {
            do
            {
                PrintField();
                Console.WriteLine("Ход игрока 1");
                p1.Move();
                PrintField();
                if (CheckWin(p1.Symbol))
                {
                    Console.WriteLine("Победил игрок 1");
                    break;
                }
                else if (IsFieldFull()) break;
                PrintField();
                Console.WriteLine("Ход игрока 2");
                p2.Move();
                PrintField();
                if (CheckWin(p2.Symbol))
                {
                    Console.WriteLine("Победил игрок 2");
                    break;
                }
                else if (IsFieldFull()) break;
            } while (true);
        }

        private bool CheckWin(char sym)
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    foreach (var itm in (Direction[])Enum.GetValues(typeof(Direction)))
                    {
                        if (getSequenceSize(itm, sym, i, j) >= winLength)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public int getSequenceSize(Direction direction, char sym, int x, int y)
        {
            int sequenceSize = 0;
            switch (direction)
            {
                case Direction.Horizontal:
                    {
                        var max = y + winLength >= Size ? Size : y + winLength;
                        for (var i = y; i < max; i++)
                        {
                            if (field[x, i] == sym)
                            {
                                sequenceSize++;
                            }
                        }
                        break;
                    }
                case Direction.Vertical:
                    {
                        var max = x + winLength >= Size ? Size : x + winLength;
                        for (var i = x; i < max; i++)
                        {
                            if (field[i, y] == sym)
                            {
                                sequenceSize++;
                            }
                        }
                        break;
                    }
                case Direction.FirstDiagonalDown:
                    {
                        var maxX = x + winLength >= Size ? Size : x + winLength;
                        var maxY = y + winLength >= Size ? Size : y + winLength;
                        for (int i = 0, j = 0; i < maxX && j < maxY; i++, j++)
                        {
                            if (field[i, j] == sym)
                            {
                                sequenceSize++;
                            }
                        }

                        break;
                    }
                case Direction.FirstDiagonalUp:
                    {
                        var min = Size - winLength > 0 ? Size - winLength : 0;
                        for (int i = Size - 1, j = Size - 1; i >= min && j >= min; i--, j--)
                        {
                            if (field[i, j] == sym)
                            {
                                sequenceSize++;
                            }
                        }

                        break;
                    }
                case Direction.SecondDiagonalDown:
                    {
                        var min = Size - winLength > 0 ? Size - winLength : 0;
                        for (int i = 0, j = Size - 1; i < winLength && j >= min; i++, j--)
                        {
                            if (field[i, j] == sym)
                            {
                                sequenceSize++;
                            }
                        }

                        break;
                    }
                case Direction.SecondDiagonalUp:
                    {
                        var min = Size - winLength > 0 ? Size - winLength : 0;
                        for (int i = Size - 1, j = 0; i >= min && j < winLength; i--, j++)
                        {
                            if (field[i, j] == sym)
                            {
                                sequenceSize++;
                            }
                        }

                        break;
                    }
            }

            return sequenceSize;
        }

        public void PrintField()
        {
            Console.Clear();
            Console.WriteLine("-------");
            for (int i = 0; i < Size; i++)
            {
                Console.Write("|");
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(field[i, j] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------");
        }

        public bool IsCellValid(int y, int x)
        {
            if (x < 0 || y < 0 || x > Size - 1 || y > Size - 1)
            {
                return false;
            }

            return field[y, x] == EmptySymbol;
        }

        public void SetSym(int y, int x, char sym)
        {
            field[y, x] = sym;
        }
    }
}
