using System;
using System.Collections.Generic;
using System.Text;

namespace GameCatch
{
    class CalculateScore
    {
        public void calculateScore(ResultForCalculate winScore)
        {            
            if (winScore == ResultForCalculate.Won)
            {
              
            }
        }

        internal static void CalculateLoose(string playerName, HighScoreDataSource highScores)
        {
           
        }

        internal static void CalculateWin(string playerName, HighScoreDataSource highScores)
        {
            var highScore = highScores.FindByName(playerName);

            if (highScore != null)
            {
                highScore.Score = highScore.Score + 2;
            }
            if (highScore = null)
            {
                var addPlayer = new HighScoreDataSource();
                addPlayer.AddNewPlayer();
            }
        }
    }
}




// Referenz bei WinFunction     OBACHT!!! aktueller Spieler: player.ToString()    return ResultForCalculate.Won
// Referenz bei GameOver        OBACHT!!! aktueller Spieler: player.ToString()    return ResultForCalculate.Lose
