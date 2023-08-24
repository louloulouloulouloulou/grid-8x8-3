using grid_8x8_3.Piece_classes;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace grid_8x8_3
{
    public static class ControlHelper
    {
        private static ImageSource wpawn = new FileImageSource { File = "../Resources/Images/wpawn.png" };
        private static ImageSource bpawn = new FileImageSource { File = "../Resources/Images/bpawn.png" };

        private static ImageSource wknight = new FileImageSource { File = "../Resources/Images/wknight.png" };
        private static ImageSource bknight = new FileImageSource { File = "../Resources/Images/bknight.png" };

        private static ImageSource wbishop = new FileImageSource { File = "../Resources/Images/wbishop.png" };
        private static ImageSource bbishop = new FileImageSource { File = "../Resources/Images/bbishop.png" };
            
        private static ImageSource wrook = new FileImageSource { File = "../Resources/Images/wrook.png" };
        private static ImageSource brook = new FileImageSource { File = "../Resources/Images/brook.png" };
            
        private static ImageSource wqueen = new FileImageSource { File = "../Resources/Images/wqueen.png" };
        private static ImageSource bqueen = new FileImageSource { File = "../Resources/Images/bqueen.png" };

        private static ImageSource wking = new FileImageSource { File = "../Resources/Images/wking.png" };
        private static ImageSource bking = new FileImageSource { File = "../Resources/Images/bking.png" };

        /// <summary>
        /// sets the pretty little images where the different pieces are UwU
        /// </summary>
        /// <param name="biggrid"></param>
        /// <param name="Motha"></param>
        public static void PaintGrid(Grid biggrid, Mothaclass[,] Motha)
        {
            int brow;
            int bcol;

            foreach (var child in biggrid.Children)
            {
                if (child is Button button)
                {
                    brow = biggrid.GetRow(button);
                    bcol = biggrid.GetColumn(button);

                    if (Motha[brow, bcol] is Pawn)
                    {
                        if (Motha[brow, bcol].colour == Colour.White)
                        {
                            button.ImageSource = wpawn;
                        }
                        else if (Motha[brow, bcol].colour == Colour.Black)
                        {
                            button.ImageSource = bpawn;
                        }
                    }
                    else if (Motha[brow, bcol] is Knight)
                    {
                        if (Motha[brow, bcol].colour == Colour.White)
                        {
                            button.ImageSource = wknight;
                        }
                        else if (Motha[brow, bcol].colour == Colour.Black)
                        {
                            button.ImageSource = bknight;
                        }
                    }
                    else if (Motha[brow, bcol] is King)
                    {
                        if (Motha[brow, bcol].colour == Colour.White)
                        {
                            button.ImageSource = wking;
                        }
                        else if (Motha[brow, bcol].colour == Colour.Black)
                        {
                            button.ImageSource = bking;
                        }
                    }
                    else if (Motha[brow, bcol] is Bishop)
                    {
                        if (Motha[brow, bcol].colour == Colour.White)
                        {
                            button.ImageSource = wbishop;
                        }
                        else if (Motha[brow, bcol].colour == Colour.Black)
                        {
                            button.ImageSource = bbishop;
                        }
                    }
                    else if (Motha[brow, bcol] is Rook)
                    {
                        if (Motha[brow, bcol].colour == Colour.White)
                        {
                            button.ImageSource = wrook;
                        }
                        else if (Motha[brow, bcol].colour == Colour.Black)
                        {
                            button.ImageSource = brook;
                        }
                    }
                    else if (Motha[brow, bcol] is Queen)
                    {
                        if (Motha[brow, bcol].colour == Colour.White)
                        {
                            button.ImageSource = wqueen;
                        }
                        else if (Motha[brow, bcol].colour == Colour.Black)
                        {
                            button.ImageSource = bqueen;
                        }
                    }
                    else
                    {
                        button.ImageSource = "";
                    }
                }
            }
        }

        /// <summary>
        /// Paints the possible moves on the Grid
        /// </summary>
        /// <param name="Moves"></param>
        /// <param name="biggrid"></param>
        public static void PaintPossibleMoves(List<Movess> Moves, Grid biggrid)
        {
            int row;
            int col;

            foreach (Movess Move in Moves)
            {
                foreach (var child in biggrid.Children)
                {
                    if (child is Button button)
                    {
                        row = biggrid.GetRow(button);
                        col = biggrid.GetColumn(button);

                        if (Move.endPosition.x == row && Move.endPosition.y == col)
                        {
                            if (Move.thing == Mtype.Regular)
                            {

                                button.Background = new SolidColorBrush(Colors.LightGreen);
                            }
                            else
                            {

                                button.Background = new SolidColorBrush(Colors.LightSalmon);
                            }
                        }
                        else
                        {
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Removes the possible moves from Grid
        /// </summary>
        /// <param name="Moves"></param>
        /// <param name="biggrid"></param>
        public static void UnPaintPossibleMoves(List<Movess> Moves, Grid biggrid)
        {
            int row;
            int col;

            foreach (Movess Move in Moves)
            {
                foreach (var child in biggrid.Children)
                {
                    if (child is Button button)
                    {
                        row = biggrid.GetRow(button);
                        col = biggrid.GetColumn(button);

                        if (Move.endPosition.x == row && Move.endPosition.y == col)
                        {
                            Squares(biggrid);
                        }
                        else
                        {
                        }
                    }
                }
            }
        }

        /// <summary>
        /// paints the floor 
        /// </summary>
        /// <param name="biggrid"></param>
        public static void Squares(Grid biggrid)
        {
            int brow;
            int bcol;

            foreach (var child in biggrid.Children)
            {
                if (child is Button button)
                {
                    brow = biggrid.GetRow(button);
                    bcol = biggrid.GetColumn(button);

                    if (brow % 2 == 0)
                    {
                        if (bcol % 2 == 1)
                        {
                            button.Background = new SolidColorBrush(Colors.Green);
                        }
                        else
                        {
                            button.Background = new SolidColorBrush(Colors.White);

                        }
                    }
                    else
                    {
                        if (bcol % 2 == 1)
                        {
                            button.Background = new SolidColorBrush(Colors.White);
                        }
                        else
                        {
                            button.Background = new SolidColorBrush(Colors.Green);

                        }
                    }
                }
            }
        }

        /// <summary>
        /// FUCK YOU FOR CHOOSING THIS NAME, is in charge of adding the click method on every button of the Grid
        /// </summary>
        /// <param name="biggrid"></param>
        /// <param name="grid_layout1"></param>
        public static void Wenumuchuinsama(Grid biggrid, Layout grid_layout1)
        {
            foreach (var child in biggrid.Children)
            {
                if (child is Button button)
                {
                    button.Clicked += Gaming.GridButton_Click;
                }
            }
            grid_layout1.Children.Add(biggrid);
        }
    }
}
