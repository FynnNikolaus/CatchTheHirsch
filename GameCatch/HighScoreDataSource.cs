using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GameCatch
{
    class HighScoreDataSource
    {
        const string path = @"C:\develop\Spielerdaten\Rangliste.txt";
        private List<HighScore> _scores;

        public void LoadHighScore()
        {
            _scores = new List<HighScore>();
  
            if (File.Exists(path))
            {
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

                        _scores.Add(highScore);
                    }
                }
            }
        }

        public void PrintHighScores()
        {         
            foreach (var score in _scores)
                Console.WriteLine(score);
        }

        public void SaveHighScore()
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var score in _scores)
                    writer.WriteLine($"{score.Name}\u00A6{score.Score}");
                
            }

    }
}
    }
