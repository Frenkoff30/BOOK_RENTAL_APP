using System.Windows;
using BookRentalApp.Data;
using BookRentalApp.Models;

namespace BookRentalApp.Views
{
    public partial class BookDialog : Window
    {
        private readonly Book? _book;

        //ADD
        public BookDialog()
        {
            InitializeComponent();
        }

        //EDIT
        public BookDialog(Book book) : this()
        {
            _book = book;
            TitleBox.Text = book.Title;
            AuthorBox.Text = book.Author;
            YearBox.Text = book.Year.ToString();
            GenreBox.Text = book.Genre;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using var db = new AppDbContext();

            if (_book == null)
            {
                db.Books.Add(new Book
                {
                    Title = TitleBox.Text,
                    Author = AuthorBox.Text,
                    Year = int.TryParse(YearBox.Text, out var y) ? y : 0,
                    Genre = GenreBox.Text,
                    IsAvailable = true
                });
            }
            else
            {
                var existing = db.Books.Find(_book.Id)!;
                existing.Title = TitleBox.Text;
                existing.Author = AuthorBox.Text;
                existing.Year = int.TryParse(YearBox.Text, out var y) ? y : 0;
                existing.Genre = GenreBox.Text;
            }

            db.SaveChanges();
            DialogResult = true;
            Close();
        }
    }
}
