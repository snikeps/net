﻿using System;

namespace NoughtsCrosses
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.PlayGame();
            Console.WriteLine("Game over");
        }
    }
}
