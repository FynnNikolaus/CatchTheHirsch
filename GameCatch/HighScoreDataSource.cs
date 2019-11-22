using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GameCatch
{
    class HighScoreDataSource
    {
        private string _data;
        private List<HighScore> _scores;

        public static List<HighScore> LoadHighScore()
        {
            var resultList = new List<HighScore>();
            string path = @"C:\develop\Spielerdaten\Rangliste.txt";
            if (!File.Exists(path))
            {
                return resultList;
            }

            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    HighScore highScore = new HighScore();
                    string[] namePlusScore = line.Split("\u00A6");
                    highScore.Name = namePlusScore[0];
                    if (!string.IsNullOrWhiteSpace(namePlusScore[1]))
                        highScore.Score = int.Parse(namePlusScore[1]);
                    resultList.Add(highScore);                   
                }
            }
            return resultList;  
        }

        public static void PrintHighScores()
        {
            string x = "sdf";
            int b = 55;
            HighScore h = new HighScore();



            var allHighScores = LoadHighScore();
            foreach (var score in allHighScores)
                Console.WriteLine(score);
        }
    }   
}
