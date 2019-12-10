using System;
using System.Collections.Generic;
using System.Text;

namespace GameCatch
{
    class CalculateScore                                                                                                                       
    {
        public void calculateScore(ResultForCalculate winScore, HumanPlayer player, HighScoreDataSource highScores)
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

            var highScore = highScores.FindByName(player.Name);

            if (highScore == null)
            {
                highScore = highScores.AddNewScore(player.Name);
            } 

            if (highScore != null)
            {
                highScore.Score += resultRating;
                
            }
        }
    }          
}



