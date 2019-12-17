using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GameCatch.Players
{
    class BotCpuPlayer : IPlayer
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        int Counter = 0;
        public Direction GetNextMove()
        {

            Thread.Sleep(500);
            Counter += 1;
            if (Counter <= 2)
            {
                return Direction.Up;
            }
            if (Counter <= 4)
            {     
                return Direction.Left;
            }
            if (Counter <= 6)
            { 
                return Direction.Down;
            }
            else 
            {
                if (Counter == 8)
                {
                    Counter = 0;
                }
                return Direction.Right;
            }   
        }

    }
}
