using System;

namespace GameCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            
            showlayout();
            KeyReading();
            
        }

        static void showlayout()
        {
            Console.WriteLine("                          ");
            Console.WriteLine("   \u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557");
            Console.WriteLine("   \u2551                     \u2551");
            Console.WriteLine("   \u2551                     \u2551");
            Console.WriteLine("   \u2551                     \u2551");
            Console.WriteLine("   \u2551                     \u2551");
            Console.WriteLine("   \u2551                     \u2551");
            Console.WriteLine("   \u2551                     \u2551");
            Console.WriteLine("   \u2551                     \u2551");
            Console.WriteLine("   \u2551                     \u2551");
            Console.WriteLine("   \u2551 1                   \u2551");
            Console.WriteLine("   \u255A\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255D");
        }

        static void KeyReading()
        {
            var MovementInput = Console.ReadKey();

            if (MovementInput.Key == ConsoleKey.W)
            {
                Console.Clear(); // Erneuerung
                Console.WriteLine("                          ");
                Console.WriteLine("   \u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557");
                Console.WriteLine("   \u2551                     \u2551");
                Console.WriteLine("   \u2551                     \u2551");
                Console.WriteLine("   \u2551                     \u2551");
                Console.WriteLine("   \u2551                     \u2551");
                Console.WriteLine("   \u2551                     \u2551");
                Console.WriteLine("   \u2551                     \u2551");
                Console.WriteLine("   \u2551                     \u2551");
                Console.WriteLine("   \u2551 1                   \u2551");
                Console.WriteLine("   \u2551                     \u2551");
                Console.WriteLine("   \u255A\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255D");

            }

            while (MovementInput.Key != ConsoleKey.W)
            {
                Console.WriteLine("Please press a valid button!");
                break;  
            }

        }









    }
}
