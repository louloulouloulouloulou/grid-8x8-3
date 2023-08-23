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
            Loop(array, 1);
            Loop(array, -1);
                    


            return Moves;
        }
        public void Loop(Mothaclass[,] array, int c)
        {
            

            X(array, c);
            Y(array, c); //() => Y(array, c)

           
            
        }
        public void X(Mothaclass[,] array, int c)
        {
            for (int i = 1; i < 9; i++)
            {
                int a = i * c;
                if (IsInArray(position.x + a, position.y) == true)
                {
                    if (array[position.x + a, position.y] == null)
                    {
                        Moves.Add(new Movess(new Position(position.x, position.y),
                            new Position(position.x + a, position.y), Mtype.Regular));
                    }
                    //capture
                    else
                    {
                        if (array[position.x + a, position.y].colour != colour)
                        {
                            Moves.Add(new Movess(new Position(position.x, position.y),
                            new Position(position.x + a, position.y), Mtype.Take));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
        public void Y(Mothaclass[,] array, int c)
        {
            for (int i = 1; i < 9; i++)
            {

                int a = i * c;

                if (IsInArray(position.x, position.y + a) == true)
                {
                    if (array[position.x, position.y + a] == null)
                    {
                        Moves.Add(new Movess(new Position(position.x, position.y),
                            new Position(position.x, position.y + a), Mtype.Regular));
                    }
                    //capture
                    else
                    {
                        if (array[position.x, position.y + a].colour != colour)
                        {
                            Moves.Add(new Movess(new Position(position.x, position.y),
                            new Position(position.x, position.y + a), Mtype.Take));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

    }
}
