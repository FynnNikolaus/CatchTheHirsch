﻿using System;
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

        internal HighScore FindByName(string lastPlayerMove)
        {
            foreach (var entry in _scores)
            {
                if (entry.Name == lastPlayerMove)
                {
                    return entry;
                }
            }
            return null;
        }
        public void PrintHighScores()
        {
            foreach (var score in _scores)
                Console.WriteLine(score); // Nur erste fünf Elemente anzeigen 
        }

        public void SaveHighScore()
        {
            using (StreamWriter writer = new StreamWriter(path))
            {                                                                                  
                foreach (var score in _scores)
                    writer.WriteLine($"{score.Name}\u00A6{score.Score}");
            }
        }
         public HighScore AddNewScore(string playerName)
        {
            HighScore highScore = new HighScore();    
            highScore.Name = playerName;
            highScore.Score = 0;
            _scores.Add(highScore); //Transmit the "Scores", name and the score in the list

            return highScore;
        }
        public string GetPlayernameFromSymbol(string playerSymbol, string hunter, string playerNameOne, string playerNameTwo)
        {
            string lastPlayerName;
            if (playerSymbol == hunter)
            {
                lastPlayerName = playerNameOne;
            }
            else
            {
                lastPlayerName = playerNameTwo;
            }
            return lastPlayerName;
        }
    }
}
