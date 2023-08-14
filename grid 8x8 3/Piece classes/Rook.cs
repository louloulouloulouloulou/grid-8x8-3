using grid_8x8_3.Piece_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grid_8x8_3
{
    public class Rook : Mothaclass
    {
        public Rook(Colour colour, Position position) : base(colour, position)
        {
            this.colour = colour;
            this.position = position;
        }
        public override List<Movess> Move(Mothaclass[,] array)
        {
            List<Movess> Moves = new List<Movess> ();
            for (int i = 1; i < 9; i++)
            {
                if (IsInArray(position.x + i, position.y) == true)
                {
                    if (array[position.x + i, position.y] == null)
                    {
                        Moves.Add(new Movess(new Position(position.x, position.y),
                            new Position(position.x + i, position.y), Mtype.Regular));
                    }
                    //capture
                    if (colour == Colour.White || colour == Colour.Black)
                    {
                        if (array[position.x + i, position.y] != null)
                        {
                            if(array[position.x + i, position.y].colour != colour)
                            {
                                Moves.Add(new Movess(new Position(position.x, position.y),
                                new Position(position.x + i, position.y), Mtype.Take));
                            }
                            else if(array[position.x + i, position.y].colour == colour)
                            {
                                break;
                            }
                        }                     
                    }
                }
                if (IsInArray(position.x, position.y + i) == true)
                {
                    if (array[position.x, position.y + i] == null)
                    {
                        Moves.Add(new Movess(new Position(position.x, position.y),
                            new Position(position.x, position.y + i), Mtype.Regular));
                    }
                    //capture
                    if (colour == Colour.White || colour == Colour.Black)
                    {
                        if (array[position.x, position.y + i] != null)
                        {
                            if (array[position.x, position.y + i].colour != colour)
                            {
                                Moves.Add(new Movess(new Position(position.x, position.y),
                                new Position(position.x, position.y + i), Mtype.Take));
                            }
                            else if (array[position.x, position.y + i].colour == colour)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return Moves;
        }
    }
}
