﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;



namespace GameCatch
{
    class Program

    {
        const string BelowLeftCorner = "\u255A";
        const string BelowRightCorner = "\u255D";
        const string TopLeftCorner = "\u2554";
        const string TopRightCorner = "\u2557";
        const string HorizontalLine = "\u2550";
        const string VerticalLine = "\u2551";
        const string hunter = "\u0466";
        const string hirsch = "\u047E";
        const ConsoleColor PlayerColorYello = ConsoleColor.Yellow;
        const ConsoleColor PlayerColorRed = ConsoleColor.Red;
       

        static void Main(string[] args)
        {
            var highScores = new HighScoreDataSource();

            Console.OutputEncoding = Encoding.UTF8;
            while(true)
            { 
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(Writings.gameTitel);
                Console.WriteLine(" \u00A9 2019 Fynn Nikolaus. All rights reserved.");
                Thread.Sleep(2000);
                Console.WriteLine("");
                Console.WriteLine(" Welcome to catchTheHirsch MENU BAR");
                Console.WriteLine(" Press F1 to START");
                Console.WriteLine(" Press F2 to RESET");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(" Scores ...");
                highScores.LoadHighScore();
                highScores.PrintHighScores();
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.White;
                var MENU = Console.ReadKey(); 
                if (MENU.Key == ConsoleKey.F1)                                                       
                { 
                    Console.WriteLine("");
                    Console.WriteLine(" Please enter your nickname: ");
                    Console.Write(" Player 1:");
                    string playerNameOne = Console.ReadLine();
                    Console.Write(" Player 2:");
                    string playerNameTwo = Console.ReadLine();
                    int size = 11;

                    while (true)
                    {
                        var playingfield = CreatePlayingField(size);
                        DrawPlayingField(size, playingfield);
                        Console.ForegroundColor = PlayerColorRed;
                        Console.WriteLine("    " + playerNameOne + " You're starting!");
                        string player = hunter;
                        var moveResult = KeyPadPlayer(playingfield, size, player);


                        while (moveResult == KeyResult.NextPlayer)
                        {
                            DrawPlayingField(size, playingfield);
                            if (player == hunter)
                            {
                                Console.ForegroundColor = PlayerColorYello;
                                Console.WriteLine("    " + playerNameTwo + ", you move!");
                                player = hirsch;
                            }
                            else
                            {
                                Console.ForegroundColor = PlayerColorRed;
                                Console.WriteLine("    " + playerNameOne + ", you move!");
                                player = hunter;
                            }
                            moveResult = KeyPadPlayer(playingfield, size, player);

                            while (moveResult == KeyResult.Invalid)
                            {
                                moveResult = KeyPadPlayer(playingfield, size, player);
                                Console.ForegroundColor = ConsoleColor.Black;
                            }
                        }

                        var currentPlayerName = highScores.GetPlayernameFromSymbol(player, hunter, playerNameOne, playerNameTwo);
                        var calculater = new CalculateScore();
                        if (moveResult == KeyResult.GameOver)
                        {
                            GameOverFunction(player, currentPlayerName);
                            PlayerSwitch(ref playerNameOne, ref playerNameTwo);
                            calculater.calculateScore(ResultForCalculate.Lose, currentPlayerName, highScores);
                        }
                        if (moveResult == KeyResult.Win)
                        {
                            DrawPlayingField(size, playingfield);
                            WinFunction(player, currentPlayerName);
                            PlayerSwitch(ref playerNameOne, ref playerNameTwo);
                            calculater.calculateScore(ResultForCalculate.Won, currentPlayerName, highScores);
                        }

                        highScores.SaveHighScore();
                    }
                }

                if (MENU.Key == ConsoleKey.F2)
                {
                    highScores.resetAllScore();
                }
                if (MENU.Key != ConsoleKey.F1 || MENU.Key != ConsoleKey.F2 || MENU.Key != ConsoleKey.F3)
                {
                    Console.Clear();
                }
            }
        }

        static void DrawPlayingField(int size, string[,] playingfield)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("");
            Console.Write("   " + TopLeftCorner); 

            for (int i = 0; i < (size); i++)
            {
                Console.Write(HorizontalLine); 
            }

            Console.WriteLine(TopRightCorner); 

            for (int zeile = 0; zeile < size; zeile++)
            {
                Console.Write("   " + VerticalLine); 

                for (int spalte = 0; spalte < (size); spalte++)
                {
                    var currentField = playingfield[zeile, spalte];
                    if (currentField == "")
                    {
                        Console.Write(" "); 
                    }
                    else
                    {
                        if (currentField == hunter)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        if (currentField == hirsch)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        Console.Write(currentField); 
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                }

                Console.WriteLine(VerticalLine); 
            }
            
            Console.Write("   " + BelowLeftCorner);

            for (int i = 0; i < (size); i++)
            {
                Console.Write(HorizontalLine);
            }

            Console.WriteLine(BelowRightCorner);
        }

        static string[,] CreatePlayingField(int size)
        {
            string[,] playingfield = new string[size, size]; 

            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    playingfield[i, j] = ""; 
                }
            }
            // set player in the array 
            playingfield[5, 5] = hunter;
            playingfield[9, 8] = hirsch;

            return playingfield;
        }

        static KeyResult KeyPadPlayer(string[,] playingfield, int size, string player)
        {
            var playerMove = Console.ReadKey();
            Position playerset = new Position();
            playerset.Line = -1;
            playerset.Column = -1;
            for (int zeile = 0; zeile < size; zeile++)
            {
                for (int spalte = 0; spalte < size; spalte++)
                {
                    if (playingfield[zeile, spalte] == player.ToString())
                    {
                        playerset.Line = zeile;
                        playerset.Column = spalte;
                    }
                }
            }
            if (playerMove.Key == ConsoleKey.UpArrow || playerMove.Key == ConsoleKey.W)
            {
                if (playerset.Line - 1 < 0)
                {
                    return KeyResult.GameOver;
                }
                playingfield[playerset.Line, playerset.Column] = "";
                var isCatched = IsHirschCatched(playingfield, playerset.Line - 1, playerset.Column, player);                    

                playingfield[playerset.Line - 1, playerset.Column] = player.ToString();

                if (isCatched)
                    return KeyResult.Win;
            }
            else if (playerMove.Key == ConsoleKey.RightArrow || playerMove.Key == ConsoleKey.D)
            {
                if (playerset.Column + 1 >= size)
                {
                    return KeyResult.GameOver;
                }
                playingfield[playerset.Line, playerset.Column] = "";
                var isCatched = IsHirschCatched(playingfield, playerset.Line, playerset.Column + 1, player);
               
                playingfield[playerset.Line, playerset.Column + 1] = player.ToString();

                if (isCatched)
                    return KeyResult.Win;
            }
            else if (playerMove.Key == ConsoleKey.LeftArrow || playerMove.Key == ConsoleKey.A)
            {
                if (playerset.Column - 1 < 0)
                {
                    return KeyResult.GameOver;
                }
                playingfield[playerset.Line, playerset.Column] = "";
                var isCatched = IsHirschCatched(playingfield, playerset.Line, playerset.Column - 1, player);                

                playingfield[playerset.Line, playerset.Column - 1] = player.ToString();

                if (isCatched)
                    return KeyResult.Win;
            }
            else if (playerMove.Key == ConsoleKey.DownArrow || playerMove.Key == ConsoleKey.S)
            {
                if (playerset.Line + 1 >= size)
                {
                    return KeyResult.GameOver;
                }
                playingfield[playerset.Line, playerset.Column] = "";
                var isCatched = IsHirschCatched(playingfield, playerset.Line + 1, playerset.Column, player);
               

                playingfield[playerset.Line + 1, playerset.Column] = player.ToString();

                if (isCatched)
                    return KeyResult.Win;
            }
            else
            {
                return KeyResult.Invalid;
            }


            return KeyResult.NextPlayer;
        }

        static ResultForCalculate GameOverFunction(string playerSymbol, string lastPlayerName)
        {
            int SleepEnterPress = 1000;
            Console.WriteLine("   GAME OVER " + playerSymbol + " " + lastPlayerName + "!");
            Thread.Sleep(SleepEnterPress);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("    Press [ENTER]");
            Console.ForegroundColor = ConsoleColor.Black;
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            return ResultForCalculate.Lose;
        }

        static void PlayerSwitch(ref string playerNameOne, ref string playerNameTwo)
        {
            var p = playerNameOne;
            playerNameOne = playerNameTwo;
            playerNameTwo = p;
        }    

        static bool IsHirschCatched(string[,] playingfield, int positionZeileEins, int positionSpalteEins, string player)
        {
            if (player == hunter && playingfield [positionZeileEins, positionSpalteEins] == hirsch)
            {
                return true; 
            }
            return false;
        }
        public static ResultForCalculate WinFunction(string playerSymbol, string lastPlayerName)
        {
            
            int SleepEnterPress = 1000;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   WON " + playerSymbol + " " + lastPlayerName + " !!!");
            Thread.Sleep(SleepEnterPress);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("   Press [ENTER]");
            Console.ForegroundColor = ConsoleColor.Black;
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            return ResultForCalculate.Won;
        }
    }

}











