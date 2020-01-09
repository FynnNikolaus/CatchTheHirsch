using GameCatch.Players;
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
                Console.WriteLine("");
                Console.WriteLine(" Welcome to catchTheHirsch MENU BAR");
                Console.WriteLine(" Press F1 to START");
                Console.WriteLine(" Press F2 to RESET");
                Console.WriteLine(" Press F3 to START SINGLE");
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

                    var playerOne = new BotCpuDrunkenPlayer();                          
                    playerOne.Name = Console.ReadLine();
                    playerOne.Symbol = HUNTER;
                
                    Console.Write(" Player 2:");
                    var playerTwo = new HumanPlayer();
                    playerTwo.Name = Console.ReadLine();
                    playerTwo.Symbol = HIRSCH;
                   
                    int size = 11;
                    IPlayer playerWhooseTurnItCurrentlyIs = playerOne;
                    IPlayer playerThatStartsTheNextGame = playerOne;

                    var playingfield = new PlayingField(size);

                    while (true)                                                                                                                 
                    {
                        playerWhooseTurnItCurrentlyIs = playerThatStartsTheNextGame;
      
                        playingfield.SetPlayerPosition(playerOne, playerTwo, playerThatStartsTheNextGame);
                        playingfield.Draw();
                        Console.ForegroundColor = PlayerColorRed;
                        Console.WriteLine("    " + playerThatStartsTheNextGame.Name + " You're catch!");
                        Console.ForegroundColor = ConsoleColor.Black;
                        var moveResult = MoveResult.Successfull;
                        while (moveResult == MoveResult.Successfull)
                        {
                            var direction = playerWhooseTurnItCurrentlyIs.GetNextMove();                                                            
                            moveResult = playingfield.MovePlayer(playerWhooseTurnItCurrentlyIs, direction);
                            
                            if(moveResult == MoveResult.Successfull)
                                playerWhooseTurnItCurrentlyIs = PlayerSwitch(playerOne, playerTwo, playerWhooseTurnItCurrentlyIs);
                            
                            playingfield.Draw();
                            Console.ForegroundColor = colors[playerWhooseTurnItCurrentlyIs.Symbol];
                            Console.WriteLine("    " + playerWhooseTurnItCurrentlyIs.Name + ", you move!");
                            if(moveResult == MoveResult.Successfull)
                                Console.ForegroundColor = ConsoleColor.Black;
                        }
                        var calculater = new CalculateScore();
                        if (moveResult == MoveResult.OnTheWall)                                                                                                              
                        {
                            GameOverFunction(playerWhooseTurnItCurrentlyIs);
                            calculater.calculateScore(ResultForCalculate.Lose, playerWhooseTurnItCurrentlyIs, highScores);
                        }
                        if (moveResult == MoveResult.Catched)
                        {
                            WinFunction(playerWhooseTurnItCurrentlyIs);
                            
                            calculater.calculateScore(ResultForCalculate.Won, playerThatStartsTheNextGame, highScores);
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

        static ResultForCalculate GameOverFunction(IPlayer player)
        {
            int SleepEnterPress = 0;                                                                                     
            Console.WriteLine("    GAME OVER " + player.Symbol + " " + player.Name + "!");
            Thread.Sleep(SleepEnterPress);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("    Press [ENTER]");
            Console.ForegroundColor = ConsoleColor.Black;
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            return ResultForCalculate.Lose;
        }

        static IPlayer PlayerSwitch(IPlayer playerOne, IPlayer playerTwo, IPlayer actualPlayer)
        {
            if (actualPlayer == playerTwo)
                return playerOne;

            return playerTwo;
        }

        static void SymbolSwitch(IPlayer playerOne, IPlayer playerTwo)
        {
            string oldPlayerOne = playerOne.Symbol;
            playerOne.Symbol = playerTwo.Symbol;
            playerTwo.Symbol = oldPlayerOne;
        }

        public static ResultForCalculate WinFunction(IPlayer player)
        {
            int SleepEnterPress = 0;
            Console.WriteLine("    WON " + player.Symbol + " " + player.Name + " !!!");
            Thread.Sleep(SleepEnterPress);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("    Press [ENTER]");
            Console.ForegroundColor = ConsoleColor.Black;
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            return ResultForCalculate.Won;
        }
    }

}











