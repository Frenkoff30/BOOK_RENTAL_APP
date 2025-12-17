using System;

namespace BookRentalApp.Models
{
    public class Loan
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public DateTime LoanDate { get; set; }
    }
}