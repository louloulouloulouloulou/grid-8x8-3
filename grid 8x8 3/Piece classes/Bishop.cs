
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

            Moves.AddRange(Loop(array, -1, -1));
            Moves.AddRange(Loop(array, -1, 1));
            Moves.AddRange(Loop(array, 1, -1));
            Moves.AddRange(Loop(array, 1, 1));
            
            return Moves;
        }
        public List<Movess> Loop(Mothaclass[,] array, int x, int y)
        {

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j <8; j++)
                {
                    int a = i * x;
                    int b = j * y;

                    if (Math.Pow(a, 2) == Math.Abs(a * b))
                    {
                        if (IsInArray(position.x + a, position.y + b))
                        {
                            if (array[position.x + a, position.y + b] == null)
                            {
                                Moves.Add(new Movess(new Position(position.x, position.y),
                                new Position(position.x + a, position.y + b), Mtype.Regular));

                            }
                            //capture

                            if (array[position.x + a, position.y + b] != null)
                            {

                                if (array[position.x + a, position.y + b].colour == colour)
                                {
                                    break;
                                }

                                if (array[position.x + a, position.y + b].colour != colour)
                                {
                                    Moves.Add(new Movess(new Position(position.x, position.y),
                                    new Position(position.x + a, position.y + b), Mtype.Take));
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

