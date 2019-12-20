using System;
using System.Collections.Generic;
using System.Text;

namespace GameCatch.Players 
{
    class BotCpuMrBrain : IPlayer
    {
        public string Name { get; set; }
        public string Symbol { get; set; }

        
        
        public Direction GetNextMove()
        {
            return Direction.Up; 
        }

        
    }
}
