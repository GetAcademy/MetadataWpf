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
using WpfApp1.Operations;

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

            var emitEventOperation = new EmitEventOperation<Person> {Name = "Lagre"};
            var metadata = new Metadata<Person>()
            {
                DisplayNameFromPropertyName = new Dictionary<string, string>
                {
                    {"Name", "Navn"},
                    {"Email", "E-post"},
                    {"City", "By"},
                },
                Operations = new Operation<Person>[]
                {
                    emitEventOperation, 
                    new ResetSuperFormOperation<Person> {Name = "Avbryt"}, 
                }
            };
            var form = new SuperFormUserControl<Person>(metadata);
            emitEventOperation.ActionDone += FormActionDone;
            var grid = (Grid)Content;
            grid.Children.Add(form);
            Grid.SetColumn(form, 0);
            Grid.SetRow(form, 0);

        }

        private void FormActionDone(object sender, SuperFormEventArgs<Person> e)
        {
            MessageBox.Show(e.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
