﻿using System;

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
            var MENU
            while ()
            var Size = 10;                                          // Matchfield size
            Console.WriteLine("");
            Console.Write("   " + TopLeftCorner);
           
            for (int i = 0; i < (Size*2); i++)
            {                  
                Console.Write(HorizontalLine);
            }

            Console.WriteLine(TopRightCorner);

            for (int i = 0; i < Size; i++) 
            {
                Console.Write("   " + VerticalLine);
                
                for (int j = 0; j < (Size * 2); j++)
                {
                    Console.Write(" ");
                }

                Console.WriteLine(VerticalLine);
            }

            Console.Write("   " + BelowLeftCorner);

            for (int i = 0; i < (Size * 2); i++)
            {
                Console.Write(HorizontalLine);
            }

            Console.WriteLine(BelowRightCorner);

            //Player input 

            Console.Write("   Player 1:");
            Console.ReadLine();
            Console.Write("   Player 2:");
            Console.ReadLine();
            
            





        }

        




    }

    







}

