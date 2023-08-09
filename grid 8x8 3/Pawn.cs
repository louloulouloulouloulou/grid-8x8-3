using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grid_8x8_3
{
    public class Pawn
    {
        public Colour colour { get; set; } // colours 4 da homies
        public Position position { get; set; } // position okokoko

        public List<Movess> Moves { get; set;} // list for the moves of the pawns
        public Pawn(Colour colour, Position position)  // constructor
        {
            this.colour = colour;
            this.position = position;

        }

        public virtual List<Movess> Move(Pawn[,] array) // move
        {
            // movement of black pawn

            if (colour == Colour.Black)
            {
                if (array[position.x, position.y - 1] == null && IsInArray(position.x, position.y - 1) == true)
                {
                    Moves.Add(new Movess(new Position(position.x, position.y), new Position(position.x, position.y - 1), Mtype.Regular));
                }

                // capturing

                if (array[position.x + 1, position.y - 1].colour == Colour.White && IsInArray(position.x+1, position.y - 1) == true)
                {
                    Moves.Add(new Movess(new Position(position.x, position.y), new Position(position.x + 1, position.y - 1), Mtype.Take));

                }

                if (array[position.x - 1, position.y - 1].colour == Colour.White && IsInArray(position.x-1, position.y - 1) == true)
                {
                    Moves.Add(new Movess(new Position(position.x, position.y), new Position(position.x - 1, position.y - 1), Mtype.Take));

                }
            }
            // movement of white pawn

            if (colour == Colour.White)
            {
                if (array[position.x, position.y + 1] == null && IsInArray(position.x, position.y + 1) == true)
                {
                    Moves.Add(new Movess(new Position(position.x, position.y), new Position(position.x, position.y + 1), Mtype.Regular));
                }
            }

            // capturing

            if (array[position.x + 1, position.y + 1].colour == Colour.Black && IsInArray(position.x + 1, position.y + 1) == true )
            {
                Moves.Add(new Movess(new Position(position.x, position.y), new Position(position.x + 1, position.y - 1), Mtype.Take));

            }

            if (array[position.x - 1, position.y + 1].colour == Colour.Black && IsInArray(position.x - 1, position.y + 1) == true)
            {
                Moves.Add(new Movess(new Position(position.x, position.y), new Position(position.x - 1, position.y + 1), Mtype.Take));

            }

            return Moves;
            

        }
        private bool IsInArray(int x, int y)
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
