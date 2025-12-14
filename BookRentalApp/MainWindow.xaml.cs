using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookRentalApp.Views;

namespace BookRentalApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    //Main okno aplikace kod pro navigaci
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainContent.Content = new BooksView();
        }

        private void BooksBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new BooksView();
        }

        private void CustomersBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CustomersView();
        }

        private void LoansBtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new LoanView();
        }
    }
}