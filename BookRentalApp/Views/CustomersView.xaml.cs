using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BookRentalApp.Data;
using BookRentalApp.Models;

namespace BookRentalApp.Views
{
    public partial class CustomersView : UserControl
    {
        public CustomersView()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            using var db = new AppDbContext();
            CustomersGrid.ItemsSource = db.Customers.ToList();
        }

        // ➕ ADD
        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CustomerDialog
            {
                Owner = Window.GetWindow(this)
            };

            if (dialog.ShowDialog() == true)
            {
                LoadCustomers();
            }
        }

        // ✏ EDIT
        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersGrid.SelectedItem is not Customer customer)
            {
                MessageBox.Show("Vyber zákazníka.");
                return;
            }

            var dialog = new CustomerDialog(customer)
            {
                Owner = Window.GetWindow(this)
            };

            if (dialog.ShowDialog() == true)
            {
                LoadCustomers();
            }
        }

        // 🗑 DELETE
        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersGrid.SelectedItem is not Customer customer)
            {
                MessageBox.Show("Vyber zákazníka.");
                return;
            }

            if (MessageBox.Show(
                $"Opravdu smazat zákazníka {customer.FirstName} {customer.LastName}?",
                "Potvrzení",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning) != MessageBoxResult.Yes)
                return;

            using var db = new AppDbContext();
            var toDelete = db.Customers.First(c => c.Id == customer.Id);
            db.Customers.Remove(toDelete);
            db.SaveChanges();

            LoadCustomers();
        }

        private void CustomersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
