using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Models
{
    public class Book
    {
        //trida pro knihu, ma id, titul autora rok vydani a zanr
        public int Id { get; set; }

        public string Title { get; set; }= string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Genre { get; set; } = string.Empty;


        //Je dostupna ?
        public bool IsAvailable { get; set; } = true;

        //Navigacni vlastnosti
        public List <Loan> Loans { get; set; } = new ();

    }
}
