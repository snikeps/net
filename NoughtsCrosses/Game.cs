﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NoughtsCrosses
{
    class Game
    {
        //private Square[][] _board =
        //{
        //    new Square[3],
        //    new Square[3],
        //    new Square[3]
        //};

        private Square[,] _board = new Square[3, 3];

        public void PlayGame()
        {
            Player player = Player.Crosses;

            bool @continue = true;
            while (@continue)
            {
                DisplayBoard();
                @continue = PlayMove(player);
                if (@continue)
                    return;
                player = 3 - player; // swap between X and O
            }
        }

        private void DisplayBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write(" " + _board[i, j]);
                Console.WriteLine();
            }
        }

        private bool PlayMove(Player player)
        {
            Console.WriteLine("Invalid input quits game");
            Console.Write($"{player}: Enter row comma column, eg. 3,3 > ");
            string input = Console.ReadLine();
            string[] parts = input.Split(',');
            if (parts.Length != 2)
                return false;
            int.TryParse(parts[0], out int row);
            int.TryParse(parts[1], out int column);

            if (row < 1 || row > 3 || column < 1 || column > 3)
                return false;

            if (_board[row-1, column-1].Owner != Player.Noone )
            {
                Console.WriteLine("Square is already occupied");
                return true;
            }

            _board[row - 1, column - 1] = new Square(player);
            return true;
        }
    }
}
