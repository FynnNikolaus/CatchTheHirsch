using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GameCatch.Players
{

    class BotCpuDrunkenPlayer : IPlayer
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        private Random _rnd = new Random();
        public Direction GetNextMove()
        {
            Thread.Sleep(500);
            Direction random = (Direction)_rnd.Next(0,3);
            return random;
        }
    }
}
