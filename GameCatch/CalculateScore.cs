using System;
using System.Collections.Generic;
using System.Text;

namespace GameCatch
{
    class CalculateScore                                                                                                                       
    {
        public void calculateScore(ResultForCalculate winScore, string lastPlayerMove, HighScoreDataSource highScores)
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


            var highScore = highScores.FindByName(lastPlayerMove);

            if (highScore == null)
            {
                var addPlayer = new HighScoreDataSource();

                addPlayer.AddNewPlayer(lastPlayerMove);
            }
            if (highScore != null)
            {
                highScore.Score = highScore.Score + resultRating;
            }
        }
    }          
}



