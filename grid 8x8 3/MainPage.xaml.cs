namespace grid_8x8_3;

public partial class MainPage : ContentPage
{
	public Grid biggrid { get; set; }

	public Button button1;

    public Pawn[,] Pawns { get; set; }

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
        Pawns = new Pawn[8, 8];

        for (int i = 0; i < Pawns.GetLength(0); i++)
        {
            for (int j = 0; j < Pawns.GetLength(1); j++)
            {
                Pawns[1, j] = new Pawn(Colour.Black, new Position(1, j));
                Pawns[6, j] = new Pawn(Colour.White, new Position(6, j));
            }
        }
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

                if (Pawns[brow, bcol] != null)
                {
                    button.Background = new SolidColorBrush(Colors.Red);
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
        int row;
        int col;
        int xrow;
        int xcol;

        row = biggrid.GetRow(clickedbutton);
        col = biggrid.GetColumn(clickedbutton);

        List<Movess> Moves = Pawns[row, col].Move(Pawns);

        if (button1 != null)
        {
            xrow = Grid.GetRow(button1);
            xcol = Grid.GetColumn(button1);

            foreach (Movess move in Moves)
            {
                if ((move.startPosition == new Position(row, col)) && (move.endPosition == new Position(xrow, xcol)))
                {
                    button1.Background = new SolidColorBrush(Colors.Gray);

                    clickedbutton.Background = new SolidColorBrush(Colors.Red);
                    button1 = null;
                }
            }         
                 
        }
        else
        {
            if (clickedbutton != null)
            {
                PaintPossibleMoves(Moves);
            }
            else
            {
                return;
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
