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
using System.Windows.Shapes;

using BookRentalApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Controls;

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
    }
}
