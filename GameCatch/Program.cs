using System;

namespace GameCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var Size = 10; // Matchfield size
            Console.WriteLine("");
            Console.Write("   \u2554");
           
            for (int i = 0; i < (Size*2); i++)
            {                  
                Console.Write("\u2550");
            }
            Console.WriteLine("\u2557");

            for (int i = 0; i < Size; i++) 
            {
                Console.WriteLine("   \u2551                    \u2551");
            }
           
            //Console.WriteLine("   \u255A\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255D");
        }

        




    }

    







}

