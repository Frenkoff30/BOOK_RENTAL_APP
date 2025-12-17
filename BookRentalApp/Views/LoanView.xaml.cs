using System.Linq;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using BookRentalApp.Data;

namespace BookRentalApp.Views
{
    public partial class LoanView : UserControl
    {
        public LoanView()
        {
            InitializeComponent();
            LoadLoans();
        }

        private void LoadLoans()
        {
            using var db = new AppDbContext();
            LoansGrid.ItemsSource = db.Loans
                .Include(l => l.Book)
                .Include(l => l.Customer)
                .ToList();
        }

        private void LoansGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
