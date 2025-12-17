using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using BookRentalApp.Data;
using BookRentalApp.Models;

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
            // áměrně prázdné – selection nám stačí pro vrácení
        }

        //VRÁCENÍ KNIHY
        private void ReturnLoan_Click(object sender, RoutedEventArgs e)
        {
            if (LoansGrid.SelectedItem is not Loan loan)
            {
                MessageBox.Show("Vyber výpůjčku, kterou chceš vrátit.");
                return;
            }

            using var db = new AppDbContext();

            var dbLoan = db.Loans
                .Include(l => l.Book)
                .FirstOrDefault(l => l.Id == loan.Id);

            if (dbLoan == null)
                return;

            //kniha je znovu dostupná
            dbLoan.Book.IsAvailable = true;

            //smažeme výpůjčku
            db.Loans.Remove(dbLoan);
            db.SaveChanges();

            LoadLoans();
        }
    }
}
