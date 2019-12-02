using System;
using System.Collections.Generic;
using System.Text;

namespace GameCatch
{
    class HighScore
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public override string ToString()
        {
            return $" {Name} has {Score} points";
        }
    }

}
