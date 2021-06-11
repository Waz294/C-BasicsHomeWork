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
            var winLength = Consts.field.winLength;
            var Size = Consts.field.Size;

            var enemySequences = GetWinSequences(winLength, Size, enemySymbol);

            if (enemySequences.Count == 0)
            {
                var winSeq = GetWinSequence(winLength, Size, Symbol);

                if (winSeq.startX != -1 && winSeq.startY != -1)
                {
                    return GetAINextPosition(winSeq.startX, winSeq.startY, winSeq.dir);
                }
            }
            else
            {
                foreach(var seq in enemySequences)
                {
                    var res = GetAINextPosition(seq.startX, seq.startY, seq.dir);

                    if(res.Item1 != -1 && res.Item2 != -1)
                    {
                        return res;
                    }
                }
            }    

            var x = Consts.random.Next(0, Size);
            var y = Consts.random.Next(0, Size);

            return (x, y);
        }
        private Sequence GetWinSequence(int winLength, int Size, char symbol)
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    foreach (var dir in (Direction[])Enum.GetValues(typeof(Direction)))
                    {
                        var seqLength = Consts.field.getSequenceSize(dir, enemySymbol, i, j);

                        if (seqLength == winLength - Consts.AI_CHECK_LENGTH)
                        {
                            return new Sequence(i, j, dir);
                        }
                    }
                }
            }

            return new Sequence(-1, -1, Direction.Horizontal);
        }

        private List<Sequence> GetWinSequences(int winLength, int Size, char symbol)
        {
            var result = new List<Sequence>();
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    foreach (var dir in (Direction[])Enum.GetValues(typeof(Direction)))
                    {
                        var seqLength = Consts.field.getSequenceSize(dir, enemySymbol, i, j);

                        if (seqLength == winLength - Consts.AI_CHECK_LENGTH)
                        {
                            result.Add(new Sequence(i, j, dir));
                        }
                    }
                }
            }

            return result;
        }

        private (int, int) GetAINextPosition(int x, int y, Direction dir)
        {
            var field = Consts.field.GetField;
            var winLength = Consts.field.winLength;
            var Size = Consts.field.Size;

            switch (dir)
            {
                case Direction.Horizontal:
                    {
                        var max = y + winLength >= Size ? Size : y + winLength;
                        for (var i = y; i < max; i++)
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
                        var max = x + winLength >= Size ? Size : x + winLength;
                        for (var i = x; i < max; i++)
                        {
                            if (field[i, y] == Consts.field.EmptySymbol)
                            {
                                return (i, y);
                            }
                        }
                        break;
                    }
                case Direction.DiagonalDown:
                    {
                        var maxX = x + winLength >= Size ? Size : x + winLength;
                        var maxY = y + winLength >= Size ? Size : y + winLength;

                        for (int i = x, j = y; i < maxX && j < maxY; i++, j++)
                        {
                            if (field[i, j] == Consts.field.EmptySymbol)
                            {
                                return (i, j);
                            }
                        }

                        break;
                    }
                case Direction.DiagonalUp:
                    {
                        var minY = y - winLength > 0 ? y - winLength : 0;
                        var maxX = x + winLength >= Size ? Size : x + winLength;
                        for (int i = x, j = y; i < maxX && j >= minY; i++, j--)
                        {
                            if (field[i, j] == Consts.field.EmptySymbol)
                            {
                                return (i, j);
                            }
                        }

                        break;
                    }
            }

            return (-1, -1);
        }

        class Sequence
        {
            public int startX { get; private set; }
            public int startY { get; private set; }
            public Direction dir { get; private set; }

            public Sequence(int startX, int startY, Direction dir)
            {
                this.startX = startX;
                this.startY = startY;
                this.dir = dir;
            }
        }
    }
}
