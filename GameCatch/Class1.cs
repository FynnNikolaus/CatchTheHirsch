using System;
using System.Collections.Generic;
using System.Text;
using System.IO; // text file

namespace GameCatch
{
    class PlayerRank
    {
        static void Score(string[] args)
        {
            string score = @"score\Rangliste.txt";

            string[] PayerGameScore = rankInGame(01);

            File.WriteAllLines(score, PlayerGameScore);



        }
    }
}
