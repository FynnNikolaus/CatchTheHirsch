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
            Console.WriteLine("   # # # # # # # # # # # #");
            Console.WriteLine("   #                     #");
            Console.WriteLine("   #                     #");
            Console.WriteLine("   #                     #");
            Console.WriteLine("   #                     #");
            Console.WriteLine("   #                     #");
            Console.WriteLine("   #                     #");
            Console.WriteLine("   #                     #");
            Console.WriteLine("   #                     #");
            Console.WriteLine("   # 1                   #");
            Console.WriteLine("   # # # # # # # # # # # #");
        }

        static void KeyReading()
        {
            var MovementInput = Console.ReadKey();

            if (MovementInput.Key == ConsoleKey.W)
            {
                Console.Clear(); // Erneuerung
                Console.WriteLine("                          ");
                Console.WriteLine("   # # # # # # # # # # # #");
                Console.WriteLine("   #                     #");
                Console.WriteLine("   #                     #");
                Console.WriteLine("   #                     #");
                Console.WriteLine("   #                     #");
                Console.WriteLine("   #                     #");
                Console.WriteLine("   #                     #");
                Console.WriteLine("   #                     #");
                Console.WriteLine("   # 1                   #");
                Console.WriteLine("   #                     #");
                Console.WriteLine("   # # # # # # # # # # # #");

            }

            while (MovementInput.Key != ConsoleKey.W)
            {
                Console.WriteLine("Please press a valid button!");
                break;  
            }

        }









    }
}
