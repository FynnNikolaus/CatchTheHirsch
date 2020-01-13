using System;
using System.Collections.Generic;
using System.Text;

namespace GameCatch.Players.BotCpuMrBrain
{
     enum playerReact
    {
        hunt,
        escape
    }
        
    class BrainProperties
    {
        private playerReact HunterOrHirsch(IPlayer playerOne, string HUNTER)
        {
            if (playerOne.Symbol == HUNTER)
                return playerReact.hunt;

            return playerReact.escape;
        }

        public Position TrackBothPlayers()
        {
            // Gibt Position von player one und player two in einem neuen Object zurück
        }

        public Direction MoveConsulent()
        {
            // calculate the abstand und gibt direction return
            // In IPlayerklasse wird entscheidung mit Zufall vermischt 
        }
        

    }
}
