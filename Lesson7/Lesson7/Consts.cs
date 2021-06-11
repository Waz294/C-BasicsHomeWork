using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    static class Consts
    {

        public static int SIZE = 5;
        public static int LENGTH_FOR_WIN = 4;
        public static int AI_CHECK_LENGTH = 1;

        public static char PLAYER_DOT = 'X';
        public static char AI_DOT = 'O';
        public static char EMPTY_DOT = '.';

        public static Random random = new Random();
        public static Field field = new Field(EMPTY_DOT, SIZE, LENGTH_FOR_WIN);
    }
}
