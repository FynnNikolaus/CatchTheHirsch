using System;
using System.Collections.Generic;
using System.Text;

namespace GameCatch
{
    class CalculateScore                                                                                                                       
    {
        public void calculateScore(ResultForCalculate winScore, string playerName, HighScoreDataSource highScores)
        {
            int resultRating = 0;

            if (winScore == ResultForCalculate.Won)
            {
                resultRating = 2; 
            }
            if (winScore == ResultForCalculate.Lose)
            {
                resultRating = -1;
            }

            var highScore = highScores.FindByName(playerName);

            if (highScore == null)
            {
                highScore = highScores.AddNewScore(playerName);
            } 

            if (highScore != null)
            {
                highScore.Score += resultRating;
                
            }
        }
    }          
}



