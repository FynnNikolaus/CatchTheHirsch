using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GameCatch.Players.MrBrain 
{
    class BotCpuMrBrain : IPlayer
    {
        public string Name { get; set; }
        public string Symbol { get; set; }

        public Direction GetNextMove(MoveContext context)
        {
            var myPosition = context.Playingfield.GetPlayerPosition(this);
            var otherPosition = context.Playingfield.GetPlayerPosition(context.OtherPlayer);
            
            Thread.Sleep(700);

            if (this.Symbol == Program.HIRSCH)
            {
                if (myPosition.Line < otherPosition.Line)
                    return Direction.Up;
                
                else if (myPosition.Line > otherPosition.Line)
                    return Direction.Down;
                
                else if (myPosition.Column < otherPosition.Column)
                    return Direction.Right;
                
                else if (myPosition.Column < otherPosition.Column)
                    return Direction.Left;
            }

            else 
            {
                if (myPosition.Column < otherPosition.Column)
                    return Direction.Down;

                else if (myPosition.Column > otherPosition.Column)
                    return Direction.Up;

                else if (myPosition.Line < otherPosition.Line)
                    return Direction.Left;

                else if (myPosition.Line < otherPosition.Line)
                    return Direction.Right;
            }

            return Direction.Down;

        }
    }



}
