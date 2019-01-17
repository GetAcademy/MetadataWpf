using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var metadata = new Metadata()
            {
                EntityType = typeof(Person),
                DisplayNameFromPropertyName = new Dictionary<string, string>
                {
                    {"Name", "Navn"},
                    {"Email", "E-post"},
                    {"City", "By"},
                },
                Operations = new[] { "Lagre", "Avbryt" }
            };
            var form = new SuperFormUserControl<Person>(metadata);
            var grid = (Grid)Content;
            grid.Children.Add(form);
            Grid.SetColumn(form, 0);
            Grid.SetRow(form, 0);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
