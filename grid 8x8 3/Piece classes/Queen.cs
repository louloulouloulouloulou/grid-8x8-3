
using grid_8x8_3.Piece_classes;


namespace grid_8x8_3
{
    public class Queen : Mothaclass
    {
        public Queen(Colour colour, Position position) : base(colour, position)
        {
            this.colour = colour;
            this.position = position;
        }
        public override List<Movess> Move(Mothaclass[,] array)
        {
            List<Movess> Moves = new List<Movess>();
            Bishop bishop = new Bishop(colour, new Position(position.x,position.y));
            Rook rook = new Rook(colour, new Position(position.x, position.y));

            Moves.AddRange(bishop.Move(array).Concat(rook.Move(array)));
            
            return Moves;
        }
    }
}
