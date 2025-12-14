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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Books_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new BooksView();
        }

        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new CustomersView();
        }

        private void Loans_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new LoanView();
        }
    }
}
