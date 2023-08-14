using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grid_8x8_3.Piece_classes
{
    public class Mothaclass
    {
        public Colour colour { get; set; } // colours 4 da homies
        public Position position { get; set; } // position okokoko

        public List<Movess> Moves { get; set; } // list for the moves of the pawns
        public Mothaclass(Colour colour, Position position)  // constructor
        {
            this.colour = colour;
            this.position = position;

        }
        public virtual List<Movess> Move(Mothaclass[,] array) // move
        {
            return Moves;
        }
        public bool IsInArray(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
