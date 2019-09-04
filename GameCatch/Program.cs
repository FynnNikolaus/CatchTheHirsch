using System;

namespace GameCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            showlayout();   

            var input = Console.ReadLine();
            Console.WriteLine("you have entered: " + input);

            showlayout();

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
            Console.WriteLine("   #                     #");
            Console.WriteLine("   # # # # # # # # # # # #");
        }
    }
}
