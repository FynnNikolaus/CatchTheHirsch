using System;
using System.Collections.Generic;
using System.Text;

namespace GameCatch
{
    class PlayingField
    {
        public Position position;
        enum MoveResult
        {
            position,


        }
        public Position GetPlayerPosition(HumanPlayer player)
        {
            return position;
        }
    }
}
