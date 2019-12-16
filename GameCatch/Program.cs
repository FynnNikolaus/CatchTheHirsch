using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;



namespace GameCatch
{
    class Program

    {
        public const string HUNTER = "\u0466";
        public const string HIRSCH = "\u047E";
        const ConsoleColor PlayerColorYello = ConsoleColor.Yellow;
        const ConsoleColor PlayerColorRed = ConsoleColor.Red;
        static Dictionary<string, ConsoleColor> colors = new Dictionary<string, ConsoleColor> {
            { HUNTER, ConsoleColor.Red },
            { HIRSCH, ConsoleColor.Yellow }

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
                Thread.Sleep(0);
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
                    playerOne.Symbol = HUNTER;
    
                    Console.Write(" Player 2:");
                    var playerTwo = new HumanPlayer();
                    playerTwo.Name = Console.ReadLine();
                    playerTwo.Symbol = HIRSCH;
                    int size = 11;
                    HumanPlayer playerWhooseTurnItCurrentlyIs = playerOne;
                    HumanPlayer playerThatStartsTheNextGame = playerOne;

                    var playingfield = new PlayingField(size);

                    while (true)
                    {
                        playerWhooseTurnItCurrentlyIs = playerThatStartsTheNextGame;
      
                        playingfield.SetPlayerPosition(playerOne, playerTwo, playerThatStartsTheNextGame);
                        playingfield.Draw();
                        Console.ForegroundColor = PlayerColorRed;
                        Console.WriteLine("    " + playerThatStartsTheNextGame.Name + " You're catch!");
                        var moveResult = MoveResult.Successfull;
                        while (moveResult == MoveResult.Successfull)
                        {
                            var direction = playerWhooseTurnItCurrentlyIs.GetNextMove();
                            moveResult = playingfield.MovePlayer(playerWhooseTurnItCurrentlyIs, direction);
                            playerWhooseTurnItCurrentlyIs = PlayerSwitch(playerOne, playerTwo, playerWhooseTurnItCurrentlyIs);
                            playingfield.Draw();
                            Console.ForegroundColor = colors[playerWhooseTurnItCurrentlyIs.Symbol];
                            Console.WriteLine("    " + playerWhooseTurnItCurrentlyIs.Name + ", you move!");
                        }
                        var calculater = new CalculateScore();
                        if (moveResult == MoveResult.OnTheWall)                                                                                                              
                        {
                            GameOverFunction(playerWhooseTurnItCurrentlyIs);
                            calculater.calculateScore(ResultForCalculate.Lose, playerWhooseTurnItCurrentlyIs, highScores);
                        }
                        if (moveResult == MoveResult.Catched)
                        {
                            WinFunction(playerThatStartsTheNextGame);
                            
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

        static ResultForCalculate GameOverFunction(HumanPlayer player)
        {
            int SleepEnterPress = 1000;
            Console.WriteLine("    GAME OVER " + player.Symbol + " " + player.Name + "!");
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

        public static ResultForCalculate WinFunction(HumanPlayer player)
        {
            
            int SleepEnterPress = 1000;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    WON " + player.Symbol + " " + player.Name + " !!!");
            Thread.Sleep(SleepEnterPress);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("   Press [ENTER]");
            Console.ForegroundColor = ConsoleColor.Black;
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            return ResultForCalculate.Won;
        }
    }

}











