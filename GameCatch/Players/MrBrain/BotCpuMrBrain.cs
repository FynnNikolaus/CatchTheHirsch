using System;
using System.Collections.Generic;
using System.Text;

namespace GameCatch.Players.MrBrain 
{
    class BotCpuMrBrain : IPlayer
    {
        public string Name { get; set; }
        public string Symbol { get; set; }

        public Direction GetNextMove()
        {
            // Mischung aus Consult und bei nur zwei Abstand von Line kommt aus Drunken player der Zufall 
            return Direction.Down;
        }

        
    }
}
