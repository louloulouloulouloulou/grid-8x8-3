using grid_8x8_3.Piece_classes;
using Microsoft.Maui.Controls;

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
        public static List<Movess> NotCurrentListOfMoves { get; set; }
        public static List<Movess> BigAssList { get; set; }

        public static List<Movess> KingList { get; set; }


        public static List<Mothaclass> PiecesB = new List<Mothaclass>();
        public static List<Mothaclass> PiecesW = new List<Mothaclass>();
        /// <summary>
        /// Inits the game
        /// </summary>
        /// <param name="grid_layout1"></param>
        public static void InitGame(Layout grid_layout1) 
        {
            Biggrid = turipipip.CGrid(8, 8);
            Motha = new Mothaclass[8, 8];
            
            InitArray(Motha);
            Refresh();

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

            for (int i = 0; i < Motha.GetLength(0); i++)
            {
                for (int j = 0; j < Motha.GetLength(1); j++)
                {
                    Motha[1, j] = new Pawn(Colour.Black, new Position(1, j));
                    Motha[6, j] = new Pawn(Colour.White, new Position(6, j));
                } 
            }
            Refresh();
                    
        }
        public static void Refresh()
        {
            PiecesW.Clear();
            PiecesB.Clear();

            for (int i = 0; i < Motha.GetLength(0); i++)
            {
                for (int j = 0; j < Motha.GetLength(1); j++)
                {
                    if (Motha[i, j] != null)
                    {
                        if (Motha[i, j].colour == Colour.White)
                        {
                            PiecesW.Add(Motha[i, j]);
                        }
                        else
                        {
                            PiecesB.Add(Motha[i, j]);
                        }
                    }
                }
            }
        }
        
        public static Player playerW = new Player(Colour.White, PiecesW, false);
        public static Player playerB = new Player(Colour.Black, PiecesB, true);

        public static string ColorOfKing;

        public static Colour aaaa = Colour.White;
        /// <summary>
        ///  Game's heart whre the real business happens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static async void GridButton_Click(object sender, EventArgs e)
        {
            Button clickedbutton = (Button)sender;
            Refresh();

            int row = Biggrid.GetRow(clickedbutton);
            int col = Biggrid.GetColumn(clickedbutton);

            
            if (button1 != null)
            {
                foreach (Movess move in CurrentListOfMoves)
                {

                    if (move.endPosition.x == row && move.endPosition.y == col)
                    {
                        Movee(move);
                        /*
                        if (CheckMated(move) == true)
                        {
                            await Application.Current.MainPage.DisplayAlert($"{ColorOfKing}!!!", $"{ColorOfKing} is bad af!!!!", "XD");
                            break;
                        }*/
                        //if (IsCheck(move) == true)
                        //{
                        //    await Application.Current.MainPage.DisplayAlert("Check Alert", $"{ColorOfKing} king is in check!", "OK");
                        //}

                        if (aaaa == Colour.White)
                        {
                            ColorOfKing = "White";
                            playerW.HasPlayed = true;
                            aaaa = Colour.Black;
                        } 
                        else if (aaaa == Colour.Black)
                        {
                            ColorOfKing = "Black";
                            playerB.HasPlayed = true;
                            aaaa = Colour.White;
                        }
                        break;

                    }
                    
                }
                
                button1 = null;
                ControlHelper.UnPaintPossibleMoves(CurrentListOfMoves, Biggrid);
                CurrentListOfMoves.Clear();
                
                if (NotCurrentListOfMoves != null)
                {
                    NotCurrentListOfMoves.Clear();
                }/*
                if (BigAssList != null)
                {
                    BigAssList.Clear();
                }*/
                ControlHelper.PaintGrid(Biggrid, Motha);
            }
            else 
            {
                if (Motha[row, col] != null)
                {
                    if (Motha[row, col].colour == aaaa)
                    {
                        CurrentListOfMoves = Motha[row, col].Move(Motha);
                        ControlHelper.PaintPossibleMoves(CurrentListOfMoves, Biggrid);
                        
                        button1 = clickedbutton;

                        
                    }
                }
                
            }
            
        }
        public static async void Movee(Movess move)
        {
            

            // 1- move the pawn to new position
            Motha[move.endPosition.x, move.endPosition.y] = Motha[move.startPosition.x, move.startPosition.y];



            // 2- update the pawn's position
            Motha[move.endPosition.x, move.endPosition.y].position.x = move.endPosition.x;
            Motha[move.endPosition.x, move.endPosition.y].position.y = move.endPosition.y;

            //2.5- TURI IP IP IP

            //aaaa = Motha[move.endPosition.x, move.endPosition.y].colour;

            // 3- remove the pawn at old position
            Motha[move.startPosition.x, move.startPosition.y] = null;
            button1.ImageSource = null;

            
            

        }
        
        public static bool IsCheck(Movess move)
        {

            List<Mothaclass> Pieces = new List<Mothaclass>();
            if (aaaa == Colour.White)
            {
                Pieces = PiecesW;
            }
            if (aaaa == Colour.Black)
            {
                Pieces = PiecesB;
            }
            foreach (Mothaclass piece in Pieces)
            {
                BigAssList = piece.Move(Motha);
            }

            if (Motha[move.endPosition.x, move.endPosition.y] is King)
            {
                KingList = Motha[move.endPosition.x, move.endPosition.y].Moves;

                foreach (Movess bmove in BigAssList)
                {
                    foreach (Movess kmove in KingList)
                    {
                        if (Motha[bmove.endPosition.x, bmove.endPosition.y] == Motha[kmove.endPosition.x, kmove.endPosition.y])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;

        }
        /*
        public static bool CheckMated(Movess move)
        {
            List<Mothaclass> Pieces = new List<Mothaclass>();
            if (aaaa == Colour.White)
            {
                Pieces = PiecesW;
            }
            if (aaaa == Colour.Black)
            {
                Pieces = PiecesB;
            }
            foreach (Mothaclass piece in Pieces)
            {
                BigAssList = piece.Move(Motha);
            }

            if (Motha[move.endPosition.x, move.endPosition.y] is King)
            {
                KingList = Motha[move.endPosition.x, move.endPosition.y].Moves;

                foreach (Movess bmove in BigAssList)
                {
                    foreach(Movess kmove in KingList)
                    {
                        if (Motha[bmove.endPosition.x, bmove.endPosition.y] == Motha[kmove.endPosition.x, kmove.endPosition.y])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;


        
        }*/

    }
}
