using grid_8x8_3.Piece_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grid_8x8_3
{
    public static class Gaming
    {
        public static Grid Biggrid { get; set; }
        public static Mothaclass[,] Motha { get; set; }

        public static Button button1;
        public static List<Movess> CurrentListOfMoves { get; set; }

        public static List<Mothaclass> whitePieces { get; set; }

        /// <summary>
        /// Inits the game
        /// </summary>
        /// <param name="grid_layout1"></param>
        public static void InitGame(Layout grid_layout1) 
        {
            Biggrid = turipipip.CGrid(8, 8);
            Motha = new Mothaclass[8, 8];

            InitArray(Motha);
            ControlHelper.Wenumuchuinsama(Biggrid, grid_layout1);
            ControlHelper.Squares(Biggrid);
            ControlHelper.PaintGrid(Biggrid, Motha);
        }

        /// <summary>
        /// Inits the array with all the pieces + adds them to the players lists
        /// </summary>
        /// <param name="Motha"></param>
        public static void InitArray(Mothaclass[,] Motha)
        {         
            for (int i = 0; i < Motha.GetLength(0); i++)
            {
                for (int j = 0; j < Motha.GetLength(1); j++)
                {
                    Motha[1, j] = new Pawn(Colour.Black, new Position(1, j));
                    Motha[6, j] = new Pawn(Colour.White, new Position(6, j));
                }
            }

            Motha[0, 1] = new Knight(Colour.Black, new Position(0, 1));
            Motha[0, 6] = new Knight(Colour.Black, new Position(0, 6));
            Motha[7, 1] = new Knight(Colour.White, new Position(7, 1));
            Motha[7, 6] = new Knight(Colour.White, new Position(7, 6));

            Motha[0, 4] = new King(Colour.Black, new Position(0, 4));
            Motha[7, 4] = new King(Colour.White, new Position(7, 4));

            Motha[0, 2] = new Bishop(Colour.Black, new Position(0, 2));
            Motha[0, 5] = new Bishop(Colour.Black, new Position(0, 5));
            Motha[7, 2] = new Bishop(Colour.White, new Position(7, 2));
            Motha[7, 5] = new Bishop(Colour.White, new Position(7, 5));

            Motha[0, 0] = new Rook(Colour.Black, new Position(0, 0));
            Motha[0, 7] = new Rook(Colour.Black, new Position(0, 7));
            Motha[7, 0] = new Rook(Colour.White, new Position(7, 0));
            Motha[7, 7] = new Rook(Colour.White, new Position(7, 7));

            Motha[0, 3] = new Queen(Colour.Black, new Position(0, 3));
            Motha[7, 3] = new Queen(Colour.White, new Position(7, 3));
        }

        /// <summary>
        ///  Game's heart whre the real business happens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void GridButton_Click(object sender, EventArgs e)
        {
            Button clickedbutton = (Button)sender;
            int row = Biggrid.GetRow(clickedbutton);
            int col = Biggrid.GetColumn(clickedbutton);

            if (button1 != null)
            {
                foreach (Movess move in CurrentListOfMoves)
                {
                    if (move.endPosition.x == row && move.endPosition.y == col)
                    {

                        // 1- move the pawn to new position
                        Motha[move.endPosition.x, move.endPosition.y] = Motha[move.startPosition.x, move.startPosition.y];

                        // 2- update the pawn's position
                        Motha[move.endPosition.x, move.endPosition.y].position.x = move.endPosition.x;
                        Motha[move.endPosition.x, move.endPosition.y].position.y = move.endPosition.y;

                        // 3- remove the pawn at old position
                        Motha[move.startPosition.x, move.startPosition.y] = null;
                        button1.ImageSource = null;
                    }
                }

                button1 = null;
                ControlHelper.UnPaintPossibleMoves(CurrentListOfMoves, Biggrid);
                CurrentListOfMoves.Clear();
                ControlHelper.PaintGrid(Biggrid, Motha);
            }
            else
            {
                if (Motha[row, col] != null)
                {
                    CurrentListOfMoves = Motha[row, col].Move(Motha);
                    ControlHelper.PaintPossibleMoves(CurrentListOfMoves, Biggrid);
                    button1 = clickedbutton;
                }
            }
        }
    }
}
