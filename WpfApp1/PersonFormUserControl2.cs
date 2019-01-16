using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public class PersonFormUserControl2 : UserControl
    {
        public PersonFormUserControl2()
        {
            var grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width = GridLength.Auto},
                    new ColumnDefinition{Width = GridLength.Auto},
                },
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                },
            };

            AddComponent(grid, 0, 0, new Label { Content = "Navn" });
            AddComponent(grid, 0, 1, new TextBox());
            AddComponent(grid, 1, 0, new Label { Content = "E-post" });
            AddComponent(grid, 1, 1, new TextBox());
            AddComponent(grid, 2, 0, new Button { Content = "Lagre" });
            AddComponent(grid, 2, 1, new Button { Content = "Avbryt" });
            Content = grid;
        }

        private static void AddComponent(Grid grid, int row, int col, Control control)
        {
            grid.Children.Add(control);
            Grid.SetRow(control, row);
            Grid.SetColumn(control, col);
        }
    }
}
