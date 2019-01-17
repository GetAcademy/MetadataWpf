using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Operations;

namespace WpfApp1
{
    public class SuperFormUserControl<T> : UserControl
        where T : new()
    {
        protected internal Metadata<T> _metadata;
        private Dictionary<string, TextBox> _textBoxes;
        private Dictionary<Button, Operation<T>> _operations;

        public SuperFormUserControl(Metadata<T> metadata)
        {
            _textBoxes = new Dictionary<string, TextBox>();
            _operations = new Dictionary<Button, Operation<T>>();
            _metadata = metadata;
            var grid = CreateGrid();
            var row = 0;
            foreach (var dataPropertyName in metadata.Fields)
            {
                CreateFieldRow(metadata, dataPropertyName, grid, row);
                row++;
            }
            CreateButtonPanel(metadata, grid, row);
            Content = grid;
        }

        private T GetValues()
        {
            var obj = new T();
            var type = typeof(T);
            foreach (var field in _metadata.Fields)
            {
                var value = _textBoxes[field].Text;
                var propertyInfo = type.GetProperty(field);
                propertyInfo.SetValue(obj, value);
            }
            return obj;
        }

        private void CreateButtonPanel(Metadata<T> metadata, Grid grid, int row)
        {
            var buttonPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            foreach (var operation in metadata.Operations)
            {
                var button = new Button()
                {
                    Content = operation.Name,
                    Width = 70,
                };
                buttonPanel.Children.Add(button);
                _operations.Add(button, operation);
                button.Click += ButtonClick;
            }

            AddComponent(grid, row, 0, buttonPanel);
            Grid.SetColumnSpan(buttonPanel, 2);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var operation = _operations[(Button)sender];
            operation.Do(GetValues());
        }

        private void CreateFieldRow(Metadata<T> metadata, string dataPropertyName, Grid grid, int row)
        {
            var textBox = new TextBox() { Width = 200 };
            _textBoxes.Add(dataPropertyName, textBox);
            var displayName = metadata.DisplayNameFromPropertyName[dataPropertyName];
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            AddComponent(grid, row, 0, new Label { Content = displayName });
            AddComponent(grid, row, 1, textBox);
        }

        private static Grid CreateGrid()
        {
            var grid = new Grid()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = GridLength.Auto},
                    new ColumnDefinition {Width = GridLength.Auto},
                }
            };
            return grid;
        }

        private static void AddComponent(Grid grid, int row, int col, FrameworkElement control)
        {
            grid.Children.Add(control);
            Grid.SetRow(control, row);
            Grid.SetColumn(control, col);
        }
    }
}
