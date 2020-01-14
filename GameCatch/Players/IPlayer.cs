using System;
using System.Collections.Generic;
using System.Text;

namespace GameCatch.Players
{
    interface IPlayer
    {
        string Name { get; set; }
        string Symbol { get; set; }

        Direction GetNextMove(MoveContext context);
    }
}
