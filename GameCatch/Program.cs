using System;
using System.Collections.Generic;
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
            // Create a MANU for the game
            Console.WriteLine("");
            Console.WriteLine(" Welcome to catchTheHirsch MENU BAR");
            Console.WriteLine(" Press F1 to START or press F2 to CLOSE");
            var MENU = Console.ReadKey(); // Read the keypad for menu options
            if (MENU.Key == ConsoleKey.F1)
            {
                Console.WriteLine("");
                Console.WriteLine(" Please enter your nickname: ");
                Console.Write(" Player 1:");
                Console.ReadLine(); //Keypad input 
                Console.Write(" Player 2:");
                Console.ReadLine();
                int size = 11; // Matchfield size 

                while (true)
                {
                    var playingfield = CreatePlayingField(size); // Implementable the parameter size in CreatePlayingField method 
                    DrawPlayingField(size, playingfield); // Implementable the parameter size and the string from CreatePlayingField
                    var moveValid = true;
                    while (moveValid)
                    {
                        moveValid = KeyPad(playingfield, size);
                        DrawPlayingField(size, playingfield);
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
                        Console.Write(currentField); // Set characters from "Zeile" and "Spalte" 
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

        static bool KeyPad(string[,] playingfield, int size)
        {

            var playerMove = Console.ReadKey();
            var positionZeileEins = -1;
            var positionSpalteEins = -1;
            var positionZeileZwei = -1;
            var positionSpalteZwei = -1;
            int SleepEnterPress = 600;
            for (int zeile = 0; zeile < size; zeile++)
            {
                for (int spalte = 0; spalte < size; spalte++)
                {
                    if (playingfield[zeile, spalte] == "1")
                    {
                        positionZeileEins = zeile;
                        positionSpalteEins = spalte;
                    }
                    if (playingfield[zeile, spalte] == "2")
                    {
                        positionZeileZwei = zeile;
                        positionSpalteZwei = spalte;
                    }
                }
            }
            if (playerMove.Key == ConsoleKey.UpArrow)
            {
                if (positionZeileEins - 1 < 0)
                {
                    Console.WriteLine("   GAME OVER PLAYER1!");
                    Thread.Sleep(SleepEnterPress);
                    Console.WriteLine("    Press [ENTER]");
                    Console.ReadLine();
                    Thread.Sleep(100);
                    return false;
                }
                playingfield[positionZeileEins, positionSpalteEins] = "";
                playingfield[positionZeileEins - 1, positionSpalteEins] = "1";

            }
            if (playerMove.Key == ConsoleKey.W)  // UP
            {
                if (positionZeileZwei - 1 < 0)
                {
                    Console.WriteLine("   GAME OVER PLAYER2!");
                    Thread.Sleep(SleepEnterPress);
                    Console.WriteLine("    Press [ENTER]");
                    Console.ReadLine();
                    Thread.Sleep(100);
                    return false;
                }
                playingfield[positionZeileZwei, positionSpalteZwei] = "";
                playingfield[positionZeileZwei - 1, positionSpalteZwei] = "2";
            }
            if (playerMove.Key == ConsoleKey.RightArrow)
            {
                if (positionSpalteEins + 1 >= size)
                {
                    Console.WriteLine("   GAME OVER PLAYER1!");
                    Thread.Sleep(SleepEnterPress);
                    Console.WriteLine("    Press [ENTER]");
                    Console.ReadLine();
                    Thread.Sleep(100);
                    return false;
                }
                playingfield[positionZeileEins, positionSpalteEins] = "";
                playingfield[positionZeileEins, positionSpalteEins + 1] = "1";
            }
            if (playerMove.Key == ConsoleKey.D)  // Right
            {
                if (positionSpalteZwei + 1 >= size)
                {
                    Console.WriteLine("   GAME OVER PLAYER2!");
                    Thread.Sleep(SleepEnterPress);
                    Console.WriteLine("    Press [ENTER]");
                    Console.ReadLine();
                    Thread.Sleep(100);
                    return false;
                }
                playingfield[positionZeileZwei, positionSpalteZwei] = "";
                playingfield[positionZeileZwei, positionSpalteZwei + 1] = "2";
            }
            if (playerMove.Key == ConsoleKey.LeftArrow)
            {
                if (positionSpalteEins - 1 < 0)
                {
                    Console.WriteLine("   GAME OVER PLAYER1!");
                    Thread.Sleep(SleepEnterPress);
                    Console.WriteLine("    Press [ENTER]");
                    Console.ReadLine();
                    Thread.Sleep(100);
                    return false;
                }
                playingfield[positionZeileEins, positionSpalteEins] = "";
                playingfield[positionZeileEins, positionSpalteEins - 1] = "1";
            }
            if (playerMove.Key == ConsoleKey.A)  // Left
            {
                if (positionSpalteZwei - 1 < 0)
                {
                    Console.WriteLine("   GAME OVER PLAYER2!");
                    Thread.Sleep(SleepEnterPress);
                    Console.WriteLine("    Press [ENTER]");
                    Console.ReadLine();
                    Thread.Sleep(100);
                    return false;
                }
                playingfield[positionZeileZwei, positionSpalteZwei] = "";
                playingfield[positionZeileZwei, positionSpalteZwei - 1] = "2";
            }
            if (playerMove.Key == ConsoleKey.DownArrow)
            {
                if (positionZeileEins +1 >= size)
                {
                    Console.WriteLine("   GAME OVER PLAYER1!");
                    Thread.Sleep(SleepEnterPress);
                    Console.WriteLine("    Press [ENTER]");
                    Console.ReadLine();
                    Thread.Sleep(100);
                    return false;
                }
                playingfield[positionZeileEins, positionSpalteEins] = "";
                playingfield[positionZeileEins + 1, positionSpalteEins] = "1";
            }
            if (playerMove.Key == ConsoleKey.S)  // Down
            {
                if (positionZeileZwei +1 >= size)
                {
                    Console.WriteLine("   GAME OVER PLAYER2!");
                    Thread.Sleep(SleepEnterPress);
                    Console.WriteLine("    Press [ENTER]");
                    Console.ReadLine();
                    Thread.Sleep(100);
                    return false;
                }
                playingfield[positionZeileZwei, positionSpalteZwei] = "";
                playingfield[positionZeileZwei + 1, positionSpalteZwei] = "2";
            }

            return true;
        }


    }









}

