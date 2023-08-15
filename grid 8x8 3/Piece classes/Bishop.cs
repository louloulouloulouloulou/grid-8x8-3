
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

            Loop(array, -1, -1);
            Loop(array, -1, 1);
            Loop(array, 1, -1);
            Loop(array, 1, 1);
            
            return Moves;
        }
        public void Loop(Mothaclass[,] array, int x, int y)
        {
            List<Movess> Moves = new List<Movess>(); // list for the moves of the pawns

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j <8; j++)
                {
                    i *= x;
                    j *= y;

                    if (IsInArray(position.x + i, position.y + i))
                    {
                        if (array[position.x + i, position.y + i] == null)
                        {
                            if (array[position.x + i, position.y + i] == null)
                            {
                                Moves.Add(new Movess(new Position(position.x, position.y),
                                    new Position(position.x + i, position.y + i), Mtype.Regular));
                            }

                            //capture
                            else if (colour == Colour.White || colour == Colour.Black)
                            {
                                if (array[position.x + i, position.y + i] != null)
                                {
                                    
                                    if (array[position.x + i, position.y + i].colour == colour)
                                    {
                                        break;
                                    }
                                    
                                    if (array[position.x - i, position.y + i].colour != colour)
                                    {
                                        Moves.Add(new Movess(new Position(position.x, position.y),
                                        new Position(position.x - i, position.y + i), Mtype.Take));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
