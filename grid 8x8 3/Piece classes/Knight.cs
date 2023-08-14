
using grid_8x8_3.Piece_classes;

namespace grid_8x8_3
{
    public class Knight : Mothaclass 
    { 
        public Knight(Colour colour, Position position): base(colour, position)
        {
            this.colour = colour;
            this.position = position;
        }
       
        public override List<Movess> Move(Mothaclass[,] array)
        {
            List<Movess> Moves = new List<Movess>(); // list for the moves of the pawns

            for (int i = -2; i < 3; i++)
            {
                for (int j = -2; j < 3; j++)
                {
                    if (i * j == 2)
                    {
                        if (IsInArray(position.x + i, position.y + j) == true)
                        {
                            if (array[position.x + i, position.y + j] == null)
                            {
                                Moves.Add(new Movess(new Position(position.x, position.y),
                                    new Position(position.x + i, position.y + j), Mtype.Regular));
                            }

                            // capture
                            if (colour == Colour.Black || colour == Colour.White)
                            {

                                if (array[position.x + i, position.y + j] != null && array[position.x + i, position.y + j].colour != colour)
                                {
                                    Moves.Add(new Movess(new Position(position.x, position.y),
                                    new Position(position.x + i, position.y + j), Mtype.Take));

                                }                       
                            }                           
                        }
                    }
                    if (i * j == -2)
                    {
                        if (IsInArray(position.x - i, position.y - j) == true)
                        {
                            if (array[position.x - i, position.y - j] == null)
                            {
                                Moves.Add(new Movess(new Position(position.x, position.y),
                                new Position(position.x - i, position.y - j), Mtype.Regular));
                            }

                            // capture
                            if (colour == Colour.Black || colour == Colour.White)
                            {
                                if (array[position.x - i, position.y - j] != null && array[position.x - i, position.y - j].colour != colour)
                                {
                                    Moves.Add(new Movess(new Position(position.x, position.y),
                                    new Position(position.x - i, position.y - j), Mtype.Take));

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
