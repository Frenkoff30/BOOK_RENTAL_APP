using System;
using System.Linq;
using System.Windows;
using BookRentalApp.Data;
using BookRentalApp.Models;

namespace BookRentalApp.Views
{
    public partial class RentDialog : Window
    {
        private readonly Book _book;

        public RentDialog(Book book)
        {
            InitializeComponent();
            _book = book;

            BookTitle.Text = $"Půjčit: {book.Title}";

            using var db = new AppDbContext();
            CustomerBox.ItemsSource = db.Customers.ToList();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerBox.SelectedItem is not Customer customer)
            {
                MessageBox.Show("Vyber zákazníka.");
                return;
            }

            using var db = new AppDbContext();

            // vytvoření půjčky
            var loan = new Loan
            {
                BookId = _book.Id,
                CustomerId = customer.Id,
                LoanDate = DateTime.Now
            };

            db.Loans.Add(loan);

            // označení knihy jako půjčené
            var book = db.Books.Find(_book.Id)!;
            book.IsAvailable = false;

            db.SaveChanges();

            DialogResult = true;
            Close();
        }
    }
}
