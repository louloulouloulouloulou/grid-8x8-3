using grid_8x8_3.Piece_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grid_8x8_3
{
    public class Pawn : Mothaclass
    {
        
        public Pawn(Colour colour, Position position)  : base(colour, position)
        {
            this.colour = colour;
            this.position = position;

        }

        public override List<Movess> Move(Mothaclass[,] array) // move
        {
            // movement of black pawn

            List<Movess> Moves = new List<Movess>(); // list for the moves of the pawns

            if (colour == Colour.Black)
            {
                if (IsInArray(position.x + 1, position.y) == true && array[position.x + 1, position.y] == null)
                {
                    Moves.Add(new Movess(new Position(position.x, position.y), new Position(position.x + 1, position.y), Mtype.Regular));
                }

                // capturing
                if (IsInArray(position.x + 1, position.y - 1) == true)
                {
                    if (array[position.x + 1, position.y - 1] != null && array[position.x + 1, position.y - 1].colour == Colour.White)
                    {
                        Moves.Add(new Movess(new Position(position.x, position.y), new Position(position.x + 1, position.y - 1), Mtype.Take));

                    }
                }
                if (IsInArray(position.x + 1, position.y + 1) == true)
                {
                    if (array[position.x + 1, position.y + 1] != null && array[position.x + 1, position.y + 1].colour == Colour.White)
                    {
                        Moves.Add(new Movess(new Position(position.x, position.y), new Position(position.x + 1, position.y + 1), Mtype.Take));

                    }
                }
            }
            // movement of white pawn

            if (colour == Colour.White)
            {
                if (IsInArray(position.x - 1, position.y) == true && array[position.x - 1, position.y] == null)
                {
                    Moves.Add(new Movess(new Position(position.x, position.y), new Position(position.x - 1, position.y), Mtype.Regular));
                }
                // capturing

                if (IsInArray(position.x - 1, position.y - 1) == true)
                {

                    if (array[position.x - 1, position.y - 1] != null && array[position.x - 1, position.y - 1].colour == Colour.Black)
                    {
                        Moves.Add(new Movess(new Position(position.x, position.y), new Position(position.x - 1, position.y - 1), Mtype.Take));

                    }
                }
                if (IsInArray(position.x - 1, position.y + 1) == true)
                {
                    if (array[position.x - 1, position.y + 1] != null && array[position.x - 1, position.y + 1].colour == Colour.Black)
                    {
                        Moves.Add(new Movess(new Position(position.x, position.y), new Position(position.x - 1, position.y + 1), Mtype.Take));

                    }
                }

            }
            return Moves;
        }
    }
}
