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
               // Abspeichern vor beenden  
            }
        }

        internal static void CalculateLoose(string playerName, HighScoreDataSource highScores)
        {
           
        }

        internal static void CalculateWin(string playerName, HighScoreDataSource highScores)
        {
            var highScore = highScores.FindByName(playerName);

            if (highScore == null)
            {
                var addPlayer = new HighScoreDataSource();

                addPlayer.AddNewPlayer(playerName);
            }
            if (highScore != null)
            {
                highScore.Score = highScore.Score + 2;
            }
            
        }
    }
}



