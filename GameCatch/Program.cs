using System;
using System.Collections.Generic;

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

        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine(" Welcome to catchTheHirsch MENU BAR");
            Console.WriteLine(" Press F1 to START or press F2 to CLOSE");
            var MENU = Console.ReadKey();
            if (MENU.Key == ConsoleKey.F1)
            {
                Console.WriteLine("");
                Console.WriteLine(" Please enter your nickname: ");
                Console.Write(" Player 1:");
                Console.ReadLine();
                Console.Write(" Player 2:");
                Console.ReadLine();
                int size = 10;                                          // Matchfield size

                var playingfield = CreatePlayingField(size);
                DrawPlayingField(size, playingfield);

            }

            if (MENU.Key == ConsoleKey.F2)
            {
                System.Environment.Exit(0);
            }
        }

        static void DrawPlayingField(int size, string[,] playingfield)
        {
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
                        Console.Write(currentField);
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

            playingfield[5, 5] = "1";
            playingfield[9, 9] = "2";

            return playingfield;
        }




    }

   







}

