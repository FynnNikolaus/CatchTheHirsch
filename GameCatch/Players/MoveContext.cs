using System;
using System.Collections.Generic;
using System.Text;

namespace GameCatch.Players
{
    class MoveContext
    {
        public IReadOnlyPlayingfield Playingfield { get; set; }

        public IPlayer OtherPlayer { get; set; }
    }
}
