using System.Windows;
using BookRentalApp.Data;
using BookRentalApp.Models;

namespace BookRentalApp.Views
{
    public partial class CustomerDialog : Window
    {
        private readonly Customer? _customer;

        //ADD
        public CustomerDialog()
        {
            InitializeComponent();
        }

        //EDIT
        public CustomerDialog(Customer customer) : this()
        {
            _customer = customer;

            FirstNameBox.Text = customer.FirstName;
            LastNameBox.Text = customer.LastName;
            EmailBox.Text = customer.Email;
            PhoneBox.Text = customer.Phone;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameBox.Text))
            {
                MessageBox.Show("Vyplň jméno a příjmení.");
                return;
            }

            using var db = new AppDbContext();

            if (_customer == null)
            {
                //ADD
                var customer = new Customer
                {
                    FirstName = FirstNameBox.Text,
                    LastName = LastNameBox.Text,
                    Email = EmailBox.Text,
                    Phone = PhoneBox.Text
                };
                db.Customers.Add(customer);
            }
            else
            {
                //EDIT
                var existing = db.Customers.Find(_customer.Id)!;
                existing.FirstName = FirstNameBox.Text;
                existing.LastName = LastNameBox.Text;
                existing.Email = EmailBox.Text;
                existing.Phone = PhoneBox.Text;
            }

            db.SaveChanges();
            DialogResult = true;
            Close();
        }
    }
}
