using GameCatch.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCatch
{
    class HumanPlayer : IPlayer
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public Direction GetNextMove()
        {
            Direction result = Direction.Up;
            bool validPress = false;
            do
            {
                var playerMove = Console.ReadKey();
                if (playerMove.Key == ConsoleKey.UpArrow || playerMove.Key == ConsoleKey.W)
                {
                    result = Direction.Up;
                    validPress = true;
                }
                else if (playerMove.Key == ConsoleKey.RightArrow || playerMove.Key == ConsoleKey.D)
                {
                    result = Direction.Right;
                    validPress = true;
                }
                else if (playerMove.Key == ConsoleKey.LeftArrow || playerMove.Key == ConsoleKey.A)
                {
                    result = Direction.Left;
                    validPress = true;
                }
                else if (playerMove.Key == ConsoleKey.DownArrow || playerMove.Key == ConsoleKey.S)
                {
                    result = Direction.Down;
                    validPress = true; 
                }
            } while (!validPress);
            return result;
        }
    }
}
