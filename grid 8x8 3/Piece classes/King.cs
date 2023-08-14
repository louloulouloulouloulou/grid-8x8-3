using grid_8x8_3.Piece_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grid_8x8_3
{
    public class King : Mothaclass
    {
        public King(Colour colour, Position position) : base(colour, position)
        {
            this.colour = colour;
            this.position = position;
        }
        public override List<Movess> Move(Mothaclass[,] array)
        {
            List<Movess> Moves = new List<Movess>(); // list for the moves of the pawns

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (IsInArray(position.x + i, position.y + j) == true)
                    {
                        if (array[position.x + i, position.y + j] == null)
                        {
                            Moves.Add(new Movess(new Position(position.x, position.y),
                                new Position(position.x + i, position.y + j), Mtype.Regular));
                        }
                        if (colour == Colour.White || colour == Colour.Black)
                        {
                            if (array[position.x + i, position.y + j] != null && array[position.x + i, position.y + j].colour != colour)
                            {
                                Moves.Add(new Movess(new Position(position.x, position.y),
                                new Position(position.x + i, position.y + j), Mtype.Take));
                            }
                            
                            
                        }
                    }
                }
            }
            return Moves;

        }
    }
}
