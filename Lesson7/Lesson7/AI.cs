using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    class AI : Player
    {
        private char enemySymbol;

        public AI(char Symbol, char EnemySymbol) : base(Symbol)
        {
            enemySymbol = EnemySymbol;
        }
        public override void Move()
        {
            int x, y;
            do
            {
                (x, y) = GetBestMove();
            } while (!Consts.field.IsCellValid(x, y));
            Consts.field.SetSym(x, y, Symbol);
        }

        private (int, int) GetBestMove()
        {
            var field = Consts.field.GetField;
            var winLength = Consts.field.winLength;
            var Size = Consts.field.Size;

            int x, y;
            Direction dir;

            (x, y, dir) = GetWinSequence(winLength, Size, enemySymbol);

            if (x == -1 || y == -1)
            {
                (x, y, dir) = GetWinSequence(winLength, Size, Symbol);
            }

            if (x != -1 && y != -1)
            {
                switch (dir)
                {
                    case Direction.Horizontal:
                        {
                            for (var i = y; i < winLength; i++)
                            {
                                if (field[x, i] == Consts.field.EmptySymbol)
                                {
                                    return (x, i);
                                }
                            }
                            break;
                        }
                    case Direction.Vertical:
                        {
                            for (var i = x; i < winLength; i++)
                            {
                                if (field[i, y] == Consts.field.EmptySymbol)
                                {
                                    return (i, y);
                                }
                            }
                            break;
                        }
                    case Direction.FirstDiagonal:
                        {
                            for (int i = 0, j = 0; i < winLength && j < winLength; i++, j++)
                            {
                                if (field[i, j] == Consts.field.EmptySymbol)
                                {
                                    return (i, j);
                                }
                            }

                            break;
                        }
                    case Direction.SecondDiagonal:
                        {
                            for (int i = 0, j = winLength - 1; i < winLength && j >= 0; i++, j--)
                            {
                                if (field[i, j] == Consts.field.EmptySymbol)
                                {
                                    return (i, j);
                                }
                            }

                            break;
                        }
                }
            }

            x = Consts.random.Next(0, Size);
            y = Consts.random.Next(0, Size);

            return (x, y);
        }

        private (int, int, Direction) GetWinSequence(int winLength, int Size, char symbol)
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    foreach (var dir in (Direction[])Enum.GetValues(typeof(Direction)))
                    {
                        var enemyLength = Consts.field.getSequenceSize(dir, enemySymbol, i, j);

                        if (enemyLength == winLength - Consts.AI_CHECK_LENGTH)
                        {
                            return (i, j, dir);
                        }
                    }
                }
            }

            return (-1, -1, Direction.Horizontal);
        }
    }
}
