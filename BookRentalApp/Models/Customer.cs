using System.Collections.Generic;

namespace BookRentalApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        public List<Loan> Loans { get; set; } = new();
    }
}