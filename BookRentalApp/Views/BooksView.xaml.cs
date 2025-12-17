using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BookRentalApp.Data;
using BookRentalApp.Models;

namespace BookRentalApp.Views
{
    public partial class BooksView : UserControl
    {
        public BooksView()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            using var db = new AppDbContext();
            BooksGrid.ItemsSource = db.Books.ToList();
        }

        //ADD
        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new BookDialog
            {
                Owner = Window.GetWindow(this)
            };

            if (dialog.ShowDialog() == true)
                LoadBooks();
        }

        //EDIT
        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            if (BooksGrid.SelectedItem is not Book book)
            {
                MessageBox.Show("Vyber knihu.");
                return;
            }

            var dialog = new BookDialog(book)
            {
                Owner = Window.GetWindow(this)
            };

            if (dialog.ShowDialog() == true)
                LoadBooks();
        }

        //DELETE
        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (BooksGrid.SelectedItem is not Book book)
            {
                MessageBox.Show("Vyber knihu.");
                return;
            }

            if (MessageBox.Show(
                $"Smazat knihu '{book.Title}'?",
                "Potvrzení",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning) != MessageBoxResult.Yes)
                return;

            using var db = new AppDbContext();
            var toDelete = db.Books.First(b => b.Id == book.Id);
            db.Books.Remove(toDelete);
            db.SaveChanges();

            LoadBooks();
        }

        //RENT
        private void RentBook_Click(object sender, RoutedEventArgs e)
        {
            if (BooksGrid.SelectedItem is not Book book)
            {
                MessageBox.Show("Vyber knihu.");
                return;
            }

            if (!book.IsAvailable)
            {
                MessageBox.Show("Kniha už je půjčená.");
                return;
            }

            var dialog = new RentDialog(book)
            {
                Owner = Window.GetWindow(this)
            };

            if (dialog.ShowDialog() == true)
                LoadBooks();
        }

        private void BooksGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
