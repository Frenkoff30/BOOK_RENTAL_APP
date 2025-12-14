using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Models
{
    public class Loan
    {

        //trida pro pujcku, ma svoje id a vazby na customera a knihu 

        public int Id { get; set; }

        //FK na BOOK
        public int BookId { get; set; }
        public Book Book { get; set; }

        //FK na CUSTOMER
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime LoanData { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; } //null nevraceno
    }
}
