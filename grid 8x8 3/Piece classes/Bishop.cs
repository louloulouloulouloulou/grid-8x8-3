
using grid_8x8_3.Piece_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grid_8x8_3
{
    public class Bishop : Mothaclass
    {
        public Bishop(Colour colour, Position position) : base(colour, position)
        {
            this.colour = colour;
            this.position = position;
        }

        public override List<Movess> Move(Mothaclass[,] array)
        {
            List<Movess> Moves = new List<Movess>(); // list for the moves of the pawns

            for (int i = -8; i < 9; i++)
            {
                int z = i*i;
                if (z > 0)
                {
                    if (IsInArray(position.x + i, position.y + i))
                    {
                        if (array[position.x + i, position.y + i] == null)
                        {
                            Moves.Add(new Movess(new Position(position.x, position.y),
                                new Position(position.x + i, position.y + i), Mtype.Regular));
                        }
                        //capture
                        if (colour == Colour.White || colour == Colour.Black)
                        {
                            if (array[position.x + i, position.y + i] != null)
                            {
                                if (array[position.x + i, position.y + i].colour == colour)
                                {
                                    break;
                                }
                                else if (array[position.x + i, position.y + i].colour != colour)
                                {
                                    Moves.Add(new Movess(new Position(position.x, position.y),
                                    new Position(position.x + i, position.y + i), Mtype.Take));
                                }
                            }
                        }
                    }
                }
                else if (z < 0)
                {
                    if (IsInArray(position.x - i, position.y - i))
                    {
                        if (array[position.x - i, position.y - i] == null)
                        {
                            Moves.Add(new Movess(new Position(position.x, position.y),
                                new Position(position.x - i, position.y - i), Mtype.Regular));
                        }

                        //capture
                        if (colour == Colour.White || colour == Colour.Black)
                        {
                            if (array[position.x - i, position.y - i] != null)
                            {
                                if (array[position.x - i, position.y - i].colour == colour)
                                {
                                    break;
                                }
                                else if (array[position.x - i, position.y - i].colour != colour)
                                {
                                    Moves.Add(new Movess(new Position(position.x, position.y),
                                    new Position(position.x - i, position.y - i), Mtype.Take));
                                }
                            }
                        }
                    }
                }
       
            }
            return Moves;
        }
    }
}
