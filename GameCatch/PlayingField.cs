using GameCatch.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCatch
{
    class PlayingField
    {
        const string BELOW_LEFT_CORNER = "\u255A";
        const string BELOW_RIGHT_CORNER = "\u255D";
        const string TOP_LEFT_CORNER = "\u2554";
        const string TOP_RIGHT_CORNER = "\u2557";
        const string HORIZONTAL_LINE = "\u2550";
        const string VERTICAL_LINE = "\u2551";
        private readonly int _size;
        private readonly string[,] _playingfield;
       
        public PlayingField(int size)
        {
            _size = size;
            _playingfield = new string[size, size];
            ClearPlayingField();
        }

        private Position GetPlayerPosition(IPlayer player)
        {
            Position playerset = new Position();

            playerset.Line = -1;
            playerset.Column = -1;

            for (int zeile = 0; zeile < _size; zeile++)
            {
                for (int spalte = 0; spalte < _size; spalte++)
                {
                    if (_playingfield[zeile, spalte] == player.Symbol)
                    {
                        playerset.Line = zeile;
                        playerset.Column = spalte;
                    }
                }
            }
            return playerset;
        }

        public MoveResult MovePlayer(IPlayer player, Direction playerMove)
        {
            var playerPosition = GetPlayerPosition(player);
            if (playerMove == Direction.Up)
            {
                if (playerPosition.Line - 1 < 0)
                    return MoveResult.OnTheWall;

                _playingfield[playerPosition.Line, playerPosition.Column] = "";
                var isCatched = IsHirschCatched(_playingfield, playerPosition.Line - 1, playerPosition.Column, player);

                _playingfield[playerPosition.Line - 1, playerPosition.Column] = player.Symbol;

                if (isCatched)
                    return MoveResult.Catched;
            } 

            else if (playerMove == Direction.Down)
            {
                if (playerPosition.Line + 1 >= _size)
                {
                    return MoveResult.OnTheWall;
                }
                _playingfield[playerPosition.Line, playerPosition.Column] = "";
                var isCatched = IsHirschCatched(_playingfield, playerPosition.Line + 1, playerPosition.Column, player);

                _playingfield[playerPosition.Line + 1, playerPosition.Column] = player.Symbol;

                if (isCatched)
                    return MoveResult.Catched;
            }

            else if (playerMove == Direction.Left)
            {
                if (playerPosition.Column -1 < 0)
                {
                    return MoveResult.OnTheWall;
                }
                _playingfield[playerPosition.Line, playerPosition.Column] = "";
                var isCatched = IsHirschCatched(_playingfield, playerPosition.Line, playerPosition.Column - 1, player);
                _playingfield[playerPosition.Line, playerPosition.Column - 1] = player.Symbol;

                if (isCatched)
                    return MoveResult.Catched;
            }

            else if (playerMove == Direction.Right)
            {
                if (playerPosition.Column + 1 >= _size)
                {
                    return MoveResult.OnTheWall;
                }
                _playingfield[playerPosition.Line, playerPosition.Column] = "";
                var isCatched = IsHirschCatched(_playingfield, playerPosition.Line, playerPosition.Column + 1, player);

                _playingfield[playerPosition.Line, playerPosition.Column + 1] = player.Symbol;

                if (isCatched)
                    return MoveResult.Catched;
            }
            
            else
            {
                return MoveResult.PlayerFailed;
            }

            return MoveResult.Successfull;
        }
        private static bool IsHirschCatched(string[,] playingfield, int positionZeileEins, int positionSpalteEins, IPlayer player)
        {
            if (player.Symbol == Program.HUNTER && playingfield[positionZeileEins, positionSpalteEins] == Program.HIRSCH)
            {
                return true;
            }
            return false;
        }

        public void Draw()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("");
            Console.Write("   " + TOP_LEFT_CORNER);

            for (int i = 0; i < _size; i++)
            {
                Console.Write(HORIZONTAL_LINE);
            }

            Console.WriteLine(TOP_RIGHT_CORNER);

            for (int zeile = 0; zeile < _size; zeile++)
            {
                Console.Write("   " + VERTICAL_LINE);

                for (int spalte = 0; spalte < _size; spalte++)
                {
                    var currentField = _playingfield[zeile, spalte];                                                        
                    if (currentField == "")
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        if (currentField == Program.HUNTER)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        if (currentField == Program.HIRSCH)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        Console.Write(currentField);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                }

                Console.WriteLine(VERTICAL_LINE);
            }

            Console.Write("   " + BELOW_LEFT_CORNER);

            for (int i = 0; i < _size; i++)
            {
                Console.Write(HORIZONTAL_LINE);
            }

            Console.WriteLine(BELOW_RIGHT_CORNER);
        }
        private void ClearPlayingField()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _playingfield[i, j] = "";
                }
            }
        }

        public void SetPlayerPosition(IPlayer playerOne, IPlayer playertwo, IPlayer playerWhoStartsTheGame)
        {
            ClearPlayingField();

            if (playerWhoStartsTheGame == playerOne)
            {
                _playingfield[5, 5] = playerOne.Symbol;
                _playingfield[9, 8] = playertwo.Symbol;
            }
            else
            {
                _playingfield[9, 8] = playerOne.Symbol;
                _playingfield[5, 5] = playertwo.Symbol;
            }
        }
    }
}

