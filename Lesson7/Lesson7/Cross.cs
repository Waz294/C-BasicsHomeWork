using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
    class Cross
    {

        static void Main(string[] args)
        {
            Player p1 = new Player(Consts.PLAYER_DOT);
            Player p2 = new AI(Consts.AI_DOT, Consts.PLAYER_DOT);

            Consts.field.runGame(p1, p2);
        }

    }
}
