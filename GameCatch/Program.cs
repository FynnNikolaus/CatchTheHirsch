using System;
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
        static Dictionary<string, ConsoleColor> colors = new Dictionary<string, ConsoleColor> {
            { hunter, ConsoleColor.Red },
            { hirsch, ConsoleColor.Yellow }

        };
            
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
                    var playerOne = new HumanPlayer(); 
                    playerOne.Name = Console.ReadLine();
                    playerOne.Symbol = hunter;
    
                    Console.Write(" Player 2:");
                    var playerTwo = new HumanPlayer();
                    playerTwo.Name = Console.ReadLine();
                    playerTwo.Symbol = hirsch;
                    int size = 11;
                    HumanPlayer playerWhooseTurnItCurrentlyIs = playerOne;
                    HumanPlayer playerThatStartsTheNextGame = playerOne;

                    while (true)
                    {
                        playerWhooseTurnItCurrentlyIs = playerThatStartsTheNextGame;

                        var playingfield = CreatePlayingField(size, playerOne, playerTwo, playerThatStartsTheNextGame);
                        DrawPlayingField(size, playingfield);
                        Console.ForegroundColor = PlayerColorRed;
                        Console.WriteLine("    " + playerThatStartsTheNextGame.Name + " You're starting!");
                        var moveResult = KeyPadPlayer(playingfield, size, playerWhooseTurnItCurrentlyIs);
                        while (moveResult == KeyResult.NextPlayer)
                        {
                            playerWhooseTurnItCurrentlyIs = PlayerSwitch(playerOne, playerTwo, playerWhooseTurnItCurrentlyIs);
                            DrawPlayingField(size, playingfield);
                            Console.ForegroundColor = colors[playerWhooseTurnItCurrentlyIs.Symbol];
                            Console.WriteLine("    " + playerWhooseTurnItCurrentlyIs.Name + ", you move!");
                            moveResult = KeyPadPlayer(playingfield, size, playerWhooseTurnItCurrentlyIs);
                        }
                        var calculater = new CalculateScore();
                        if (moveResult == KeyResult.GameOver)
                        {
                            GameOverFunction(playerWhooseTurnItCurrentlyIs);
                            calculater.calculateScore(ResultForCalculate.Lose, playerWhooseTurnItCurrentlyIs, highScores);
                        }
                        if (moveResult == KeyResult.Win)
                        {
                            WinFunction(playerWhooseTurnItCurrentlyIs);
                            
                            calculater.calculateScore(ResultForCalculate.Won, playerWhooseTurnItCurrentlyIs, highScores);
                        }
                        SymbolSwitch(playerOne, playerTwo);
                        playerThatStartsTheNextGame = PlayerSwitch(playerOne, playerTwo, playerThatStartsTheNextGame);
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

        static string[,] CreatePlayingField(int size, HumanPlayer playerOne, HumanPlayer playertwo, HumanPlayer playerWhoStartsTheGame)
        {
            string[,] playingfield = new string[size, size]; 

            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    playingfield[i, j] = ""; 
                }
            }

            if (playerWhoStartsTheGame == playerOne)
            {
                playingfield[5, 5] = playerOne.Symbol;
                playingfield[9, 8] = playertwo.Symbol;
            }
            else 
            {
                playingfield[9, 8] = playerOne.Symbol;
                playingfield[5, 5] = playertwo.Symbol;
            }   

            return playingfield;
        }

        static KeyResult KeyPadPlayer(string[,] playingfield, int size, HumanPlayer player)
        {
            var playerMove = player.GetNextMove();
            Position playerset = new Position();
            playerset.Line = -1;
            playerset.Column = -1;
            for (int zeile = 0; zeile < size; zeile++)
            {
                for (int spalte = 0; spalte < size; spalte++)
                {
                    if (playingfield[zeile, spalte] == player.Symbol)
                    {
                        playerset.Line = zeile;
                        playerset.Column = spalte;
                    }
                }
            }
            if (playerMove == Direction.Up)
            {
                if (playerset.Line - 1 < 0)
                {
                    return KeyResult.GameOver;
                }
                playingfield[playerset.Line, playerset.Column] = "";
                var isCatched = IsHirschCatched(playingfield, playerset.Line - 1, playerset.Column, player);                    

                playingfield[playerset.Line - 1, playerset.Column] = player.Symbol;

                if (isCatched)
                    return KeyResult.Win;
            }
            else if (playerMove == Direction.Right)
            {
                if (playerset.Column + 1 >= size)
                {
                    return KeyResult.GameOver;
                }
                playingfield[playerset.Line, playerset.Column] = "";
                var isCatched = IsHirschCatched(playingfield, playerset.Line, playerset.Column + 1, player);
               
                playingfield[playerset.Line, playerset.Column + 1] = player.Symbol;

                if (isCatched)
                    return KeyResult.Win;
            }
            else if (playerMove == Direction.Left)
            {
                if (playerset.Column - 1 < 0)
                {
                    return KeyResult.GameOver;
                }
                playingfield[playerset.Line, playerset.Column] = "";
                var isCatched = IsHirschCatched(playingfield, playerset.Line, playerset.Column - 1, player);                

                playingfield[playerset.Line, playerset.Column - 1] = player.Symbol;

                if (isCatched)
                    return KeyResult.Win;
            }
            else if (playerMove == Direction.Down)
            {
                if (playerset.Line + 1 >= size)
                {
                    return KeyResult.GameOver;
                }
                playingfield[playerset.Line, playerset.Column] = "";
                var isCatched = IsHirschCatched(playingfield, playerset.Line + 1, playerset.Column, player);
               
                playingfield[playerset.Line + 1, playerset.Column] = player.Symbol;

                if (isCatched)
                    return KeyResult.Win;
            }
            else
            {
                return KeyResult.Invalid;
            }


            return KeyResult.NextPlayer;
        }

        static ResultForCalculate GameOverFunction(HumanPlayer player)
        {
            int SleepEnterPress = 1000;
            Console.WriteLine("   GAME OVER " + player.Symbol + " " + player.Name + "!");
            Thread.Sleep(SleepEnterPress);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("    Press [ENTER]");
            Console.ForegroundColor = ConsoleColor.Black;
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            return ResultForCalculate.Lose;
        }

        static HumanPlayer PlayerSwitch(HumanPlayer playerOne, HumanPlayer playerTwo, HumanPlayer actualPlayer)
        {
            if (actualPlayer == playerTwo)
                return playerOne;

            return playerTwo;
        }

        static void SymbolSwitch(HumanPlayer playerOne, HumanPlayer playerTwo)
        {
            string oldPlayerOne = playerOne.Symbol;
            playerOne.Symbol = playerTwo.Symbol;
            playerTwo.Symbol = oldPlayerOne;
        }

        private static bool IsHirschCatched(string[,] playingfield, int positionZeileEins, int positionSpalteEins, HumanPlayer player)
        {
            if (player.Symbol == hunter && playingfield [positionZeileEins, positionSpalteEins] == hirsch)
            {
                return true; 
            }
            return false;
        }
        public static ResultForCalculate WinFunction(HumanPlayer player)
        {
            
            int SleepEnterPress = 1000;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   WON " + player.Symbol + " " + player.Name + " !!!");
            Thread.Sleep(SleepEnterPress);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("   Press [ENTER]");
            Console.ForegroundColor = ConsoleColor.Black;
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            return ResultForCalculate.Won;
        }
    }

}











