using grid_8x8_3.Piece_classes;
using System;
using System.Collections;
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
                    int newX = position.x + i;
                    int newY = position.y + j;

                    if (IsInArray(newX, newY))
                    {
                        if (array[newX, newY] == null)
                        {
                            Moves.Add(new Movess(new Position(position.x, position.y),
                                new Position(newX, newY), Mtype.Regular));

                        }
                        if (colour == Colour.White || colour == Colour.Black)
                        {
                            if (array[newX, newY] != null && array[newX, newY].colour != colour)
                            {
                                Moves.Add(new Movess(new Position(position.x, position.y),
                               new Position(newX, newY), Mtype.Take));
                            }
                        }
                    }
                }
            }

            return FUCKYOU(Moves, array);
        }

        private List<Movess> FUCKYOU(List<Movess> kingMoves, Mothaclass[,] array) 
        {
            List<Movess> EnemyPawnMoves = new List<Movess>(); // list for the moves of the pawns
            List<Mothaclass> EnemyPawns = GetEnemyPawns();

            foreach (Mothaclass pawn in EnemyPawns)
            {
                if (pawn is not King)
                {
                    EnemyPawnMoves.AddRange(pawn.Move(array));

                    if (pawn is Pawn)
                    {
                        EnemyPawnMoves.AddRange(pawn.UnlockedMove(array));
                    }
                }
            }
            var distinctEndPositions = EnemyPawnMoves.Select(move => move.endPosition).Distinct().ToList();
            var filteredKingMoves = new List<Movess>();

            foreach (var move in kingMoves)
            {
                bool test = distinctEndPositions.Contains(move.endPosition);

                if (!test)
                {
                    filteredKingMoves.Add(move);
                }
            }

            kingMoves = filteredKingMoves;

            return kingMoves;
        }

        private List<Mothaclass> GetEnemyPawns() 
        {
            if (colour == Colour.White)
            {
                return Gaming.PiecesB;
            }
            else
            {
                return Gaming.PiecesW;
            }
        }
    }
}
