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
            List<string> rangliste = new List<string>();
         
            if (player == hunter)
            {
                rangliste.Add(playerNameOne + seperator);                                           
            }
            if (player == hirsch)
            {
                rangliste.Add(playerNameTwo + seperator);
            } 
        }

        static public void Read(List<string> rangliste)                                                  
        {
            var pathRead = @"C:\develop\Spielerdaten\Rangliste.txt";
            StreamReader reader = new StreamReader(pathRead);
            var rang = reader.ReadToEnd();
            reader.Close();
            rangliste.Add(rang);
        }

        static public void ContentWriteInList(List<string> rangliste)
        {
            Read(rangliste);
            var path = @"C:\develop\Spielerdaten\Rangliste.txt";
            StreamWriter writer = new StreamWriter(path);
            foreach (string allRangliste in rangliste) 
            {
                writer.Write(allRangliste);
            }
            writer.Close();
        }

        static public void Show(List<string> rangliste)
        {
            Console.WriteLine(rangliste);
        }


    }
}