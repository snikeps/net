using System;
using System.Collections.Generic;
using System.Text;

namespace NoughtsCrosses
{
    public enum Player { Noone = 0, Noghts, Crosses }

    public struct Square
    {
        public Player Owner { get; }

        public Square(Player owner)
        {
            this.Owner = owner;
        }

        public override string ToString()
        {
            switch (Owner)
            {
                case Player.Noone:
                    return ".";
                case Player.Crosses:
                    return "X";
                case Player.Noghts:
                    return "O";
                default:
                    throw new Exception("Invalid state");
            }
        }
    }
}
