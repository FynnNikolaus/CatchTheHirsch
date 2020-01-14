using GameCatch.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCatch
{
    interface IReadOnlyPlayingfield

    {
        Position GetPlayerPosition(IPlayer player);
    }
}
