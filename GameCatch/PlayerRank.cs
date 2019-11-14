using System;
using System.Collections.Generic;
using System.Text;
using System.IO; // text file

namespace GameCatch
{
    class PlayerRank
    {
        const string seperator = "\u00A6";
        static public void Write(string player, string hirsch, string hunter, string playerNameOne, string playerNameTwo)
        {
            var path = @"C:\develop\Spielerdaten\Rangliste.txt";
            StreamWriter writer = new StreamWriter(path);
            string name = "";

            if (player == hunter)
            {
                name = playerNameOne + seperator;
                name + 1                                           // Referenzen von an die Wand, Verloren und gewonnen erzeugen 
            }
            if (player == hirsch)
            {
                name = playerNameTwo + seperator;
            }
            
            writer.Write("Score:" + " " + name); 
            writer.Close();
            Console.ReadKey(); 
        }

        static public void Show()                                                  
        {
            var pathRead = @"C:\develop\Spielerdaten\Rangliste.txt";
            StreamReader reader = new StreamReader(pathRead);
            var rang = reader.ReadToEnd();
            reader.Close();

            Console.WriteLine(rang);
        }
    }
}


