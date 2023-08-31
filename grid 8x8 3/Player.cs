using grid_8x8_3.Piece_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grid_8x8_3
{
    public class Player 
    {
        public Colour colour { get; set; }

        public List<Mothaclass> pieces { get; set; }
        
        public bool HasPlayed { get; set; }

        public Player(Colour colour, List<Mothaclass> pieces, bool hasPlayed)
        {
            this.colour = colour;
            this.pieces = pieces;
            this.HasPlayed = hasPlayed;
        }   
    }
}
