using grid_8x8_3.Piece_classes;

namespace grid_8x8_3;

public partial class MainPage : ContentPage
{
	public Grid biggrid { get; set; }

	public Button button1;

    public Mothaclass[,] Motha { get; set; }

    ImageSource wpawn = new FileImageSource { File = "../Resources/Images/wpawn.png" };
    ImageSource bpawn = new FileImageSource { File = "../Resources/Images/bpawn.png" };

    ImageSource wknight = new FileImageSource { File = "../Resources/Images/wknight.png" };
    ImageSource bknight = new FileImageSource { File = "../Resources/Images/bknight.png" };

    ImageSource wbishop = new FileImageSource { File = "../Resources/Images/wbishop.png" };
    ImageSource bbishop = new FileImageSource { File = "../Resources/Images/bbishop.png" };

    ImageSource wrook = new FileImageSource { File = "../Resources/Images/wrook.png" };
    ImageSource brook = new FileImageSource { File = "../Resources/Images/brook.png" };

    ImageSource wqueen = new FileImageSource { File = "../Resources/Images/wqueen.png" };
    ImageSource bqueen = new FileImageSource { File = "../Resources/Images/bqueen.png" };

    ImageSource wking = new FileImageSource { File = "../Resources/Images/wking.png" };
    ImageSource bking = new FileImageSource { File = "../Resources/Images/bking.png" };

    public List<Movess> CurrentListOfMoves {  get; set; }
    public MainPage()
	{
		InitializeComponent();

        Array();

        Wenumuchuinsama();
        
        PaintGrid();
	}

	private void Wenumuchuinsama()
	{
		biggrid = turipipip.CGrid(8, 8);
		
		
		foreach (var child in biggrid.Children)
		{
			if (child is Button button)
			{
				button.Clicked += GridButton_Click;
			}
		}
        
		grid_layout1.Children.Add(biggrid);
	}

    public void Array()
    {
        Motha = new Mothaclass[8, 8];

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
        Motha[7, 3] = new Queen(Colour.White, new Position(0, 3));


    }

    public void PaintGrid()
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
                    button.Background = new SolidColorBrush(Colors.White);

                }
            } 
        }
    }
    /*
    public void Array(int[,] ints)
    {
        Random rnd = new Random();


        for (int i = 0; i < ints.GetLength(0); i++)
        {
            for (int j = 0; j < ints.GetLength(1); j++)
            {
                ints[i, j] = rnd.Next(0, 2);
            }
        }
    }
    */

    private void GridButton_Click(object sender, EventArgs e)
    {
        Button clickedbutton = (Button)sender;
        int row = biggrid.GetRow(clickedbutton);
        int col = biggrid.GetColumn(clickedbutton);

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
            UnPaintPossibleMoves(CurrentListOfMoves);
            PaintGrid();
        }
        else
        {
            if (Motha[row, col] != null)
            {
                CurrentListOfMoves = Motha[row, col].Move(Motha);
                PaintPossibleMoves(CurrentListOfMoves);
                button1 = clickedbutton;
            }
        }
    }
    private void PaintPossibleMoves(List <Movess> Moves)
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
    private void UnPaintPossibleMoves(List<Movess> Moves)
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
                            
                            button.Background = new SolidColorBrush(Colors.White);
                        }
                        else
                        {
                            
                            button.Background = new SolidColorBrush(Colors.White);
                        }
                    }
                    else
                    {
                    }
                }
            }
        }
    }
    /*
    private void Button_Clicked(object sender, EventArgs e)
    {
        int[,] array = new int[8, 8];
        Array(array);
        Random rnd = new Random();
        int row;
        int col;

        int arow;
        int acol;


        do
        {
            arow = rnd.Next(0, array.GetLength(0) + 1);
            acol = rnd.Next(0, array.GetLength(1) + 1);
        }
        while (array[arow, acol] != 1);


        foreach (var child in biggrid.Children)
        {
            if (child is Button button)
            {
                row = biggrid.GetRow(button);
                col = biggrid.GetColumn(button);
                
                if ((row == arow) && (col == acol))
                {
                    button.Text = "Hello";
                    button.Background = new SolidColorBrush(Colors.Red);
                }                  
            }
        }
    }
    */
}
