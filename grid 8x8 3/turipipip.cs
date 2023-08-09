using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grid_8x8_3
{
    internal class turipipip
    {
        public static Grid CGrid(int rows, int columns)
        {
            Grid grid = new Grid();

            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50, GridUnitType.Auto)});
            }

            for (int j = 0; j < columns; j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Auto) });
            }

            for (int k = 0; k < rows; k++)
            {
                for (int l =0; l< columns; l++)
                {
                    Button button = new Button();

                    button.Text = "";
                    button.WidthRequest = 80;
                    button.HeightRequest = 80;

                    grid.SetRow(button, k);
                    grid.SetColumn(button, l);

                    button.Background = new SolidColorBrush(Colors.Gray);

                    grid.Children.Add(button);
                    
                }
            }

            return grid;
        }
    }
}
