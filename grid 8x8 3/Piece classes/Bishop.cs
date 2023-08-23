
using grid_8x8_3.Piece_classes;
using System.Collections.Generic;

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

            Loop(array, 1, 1);
            Loop(array, -1, 1);
            Loop(array, 1, -1);
            Loop(array, -1, -1);
            
            return Moves;
        }
        public List<Movess> Loop(Mothaclass[,] array, int c, int d)
        {

            for (int i = 1; i < 9; i++)
            {
                int a = i * c;
                int b = i * d;


                if (IsInArray(position.x + a, position.y + b))
                {
                    if (array[position.x + a, position.y + b] == null)
                    {
                        Moves.Add(new Movess(new Position(position.x, position.y),
                        new Position(position.x + a, position.y + b), Mtype.Regular));

                    }
                    //capture

                    else
                    {
                        if (array[position.x + a, position.y + b].colour != colour)
                        {
                            Moves.Add(new Movess(new Position(position.x, position.y),
                            new Position(position.x + a, position.y + b), Mtype.Take));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }

                }


            }
            return Moves;
            
        }
    }
}

