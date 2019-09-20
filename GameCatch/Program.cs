using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;



namespace GameCatch
{
    class Program

    {
        // Variable for the match field withe unit codes 
        const string BelowLeftCorner = "\u255A";
        const string BelowRightCorner = "\u255D";
        const string TopLeftCorner = "\u2554";
        const string TopRightCorner = "\u2557";
        const string HorizontalLine = "\u2550";
        const string VerticalLine = "\u2551";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(" \u00A9 2019 Fynn Nikolaus. All rights reserved \u047E \u0466 .");
            Thread.Sleep(2500);
            Console.WriteLine("");
            Console.WriteLine(" Welcome to catchTheHirsch MENU BAR");
            Console.WriteLine(" Press F1 to START or press F2 to CLOSE");
            var MENU = Console.ReadKey(); // Read the keypad for menu options
            if (MENU.Key == ConsoleKey.F1)
            {
                Console.WriteLine("");
                Console.WriteLine(" Please enter your nickname: ");
                Console.Write(" Player 1:");
                string playerNameOne = Console.ReadLine();
                Console.Write(" Player 2:");
                string playerNameTwo = Console.ReadLine();
                int size = 11; // Matchfield size 

                while (true)
                {
                    var playingfield = CreatePlayingField(size); // Implementable the parameter size in CreatePlayingField method 
                    DrawPlayingField(size, playingfield); // Implementable the parameter size and the string from CreatePlayingField
                    Console.WriteLine("    " + playerNameOne + " You're starting!");
                    var moveValid = true;
                    int player = 1;
                    while (moveValid)
                    {
                        moveValid = KeyPadPlayer(playingfield, size, player);
                        DrawPlayingField(size, playingfield);
                        if (player == 1)
                        {
                            Console.WriteLine("    " + playerNameTwo + ", you move!");
                            player = 2;
                        }
                        else
                        {
                            Console.WriteLine("    " + playerNameOne + ", you move!");
                            player = 1;
                        }

                    }
                }
            }


            if (MENU.Key == ConsoleKey.F2)
            {
                System.Environment.Exit(0); //Close the terminal
            }
        }

        static void DrawPlayingField(int size, string[,] playingfield)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("");
            Console.Write("   " + TopLeftCorner); // Draws the left corner after 3 distances

            for (int i = 0; i < (size); i++)
            {
                Console.Write(HorizontalLine); // Draws horizontal line on the field top 
            }

            Console.WriteLine(TopRightCorner); // Draws the right corner

            for (int zeile = 0; zeile < size; zeile++)
            {
                Console.Write("   " + VerticalLine); // Draws the left field line

                for (int spalte = 0; spalte < (size); spalte++)
                {
                    var currentField = playingfield[zeile, spalte];
                    if (currentField == "")
                    {
                        Console.Write(" "); //Makes in a void string a space
                    }
                    else
                    {
                        if (currentField == "1")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        if (currentField == "2")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        Console.Write(currentField); // Set characters from "Zeile" and "Spalte
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                }

                Console.WriteLine(VerticalLine); // Draws the right line
            }
            // Draws the below left corner aand the below right corner and the below line
            Console.Write("   " + BelowLeftCorner);

            for (int i = 0; i < (size); i++)
            {
                Console.Write(HorizontalLine);
            }

            Console.WriteLine(BelowRightCorner);
        }

        static string[,] CreatePlayingField(int size)
        {
            string[,] playingfield = new string[size, size]; //Create a 2 demension string for "Spalte" and "Zeile"

            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    playingfield[i, j] = ""; // overwrite null in "" 
                }
            }
            // set player in the array 
            playingfield[5, 5] = "1";
            playingfield[9, 8] = "2";

            return playingfield;
        }

        static bool KeyPadPlayer(string[,] playingfield, int size, int player)
        {

            var playerMove = Console.ReadKey();
            var positionZeileEins = -1;
            var positionSpalteEins = -1;
            int SleepEnterPress = 600;
            int finalDeleay = 10;
            for (int zeile = 0; zeile < size; zeile++)
            {
                for (int spalte = 0; spalte < size; spalte++)
                {
                    if (playingfield[zeile, spalte] == player.ToString())
                    {
                        positionZeileEins = zeile;
                        positionSpalteEins = spalte;
                    }
                }
            }
            if (playerMove.Key == ConsoleKey.UpArrow || playerMove.Key == ConsoleKey.W)
            {
                if (positionZeileEins - 1 < 0)
                {
                    Console.WriteLine("   GAME OVER PLAYER " + player.ToString() + "!");
                    Thread.Sleep(SleepEnterPress);
                    Console.WriteLine("    Press [ENTER]");
                    Console.ReadLine();
                    Thread.Sleep(finalDeleay);
                    return false;
                }
                playingfield[positionZeileEins, positionSpalteEins] = "";
                playingfield[positionZeileEins - 1, positionSpalteEins] = player.ToString();

            }
            if (playerMove.Key == ConsoleKey.RightArrow || playerMove.Key == ConsoleKey.D)
            {
                if (positionSpalteEins + 1 >= size)
                {
                    Console.WriteLine("   GAME OVER PLAYER " + player.ToString() + "!");
                    Thread.Sleep(SleepEnterPress);
                    Console.WriteLine("    Press [ENTER]");
                    Console.ReadLine();
                    Thread.Sleep(finalDeleay);
                    return false;
                }
                playingfield[positionZeileEins, positionSpalteEins] = "";
                playingfield[positionZeileEins, positionSpalteEins + 1] = player.ToString();
            }
            if (playerMove.Key == ConsoleKey.LeftArrow || playerMove.Key == ConsoleKey.A)
            {
                if (positionSpalteEins - 1 < 0)
                {
                    Console.WriteLine("   GAME OVER PLAYER " + player.ToString() + "!");
                    Thread.Sleep(SleepEnterPress);
                    Console.WriteLine("    Press [ENTER]");
                    Console.ReadLine();
                    Thread.Sleep(finalDeleay);
                    return false;
                }
                playingfield[positionZeileEins, positionSpalteEins] = "";
                playingfield[positionZeileEins, positionSpalteEins - 1] = player.ToString();
            }
            if (playerMove.Key == ConsoleKey.DownArrow || playerMove.Key == ConsoleKey.S)
            {
                if (positionZeileEins + 1 >= size)
                {
                    Console.WriteLine("   GAME OVER PLAYER " + player.ToString() + "!");
                    Thread.Sleep(SleepEnterPress);
                    Console.WriteLine("    Press [ENTER]");
                    Console.ReadLine();
                    Thread.Sleep(finalDeleay);
                    return false;
                }
                playingfield[positionZeileEins, positionSpalteEins] = "";
                playingfield[positionZeileEins + 1, positionSpalteEins] = player.ToString();
            }
            return true;
        }

        



    }









}

