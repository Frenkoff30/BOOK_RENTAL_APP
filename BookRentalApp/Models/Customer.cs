using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Models
{

    //trida zakaznik, ma jmeno prijmeni email a tel. cislo
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }= string.Empty;
        public string Email { get; set; }= string.Empty;
        public string Phone { get; set; } = string.Empty;

        //Navigace
        public List <Loan> Loans { get; set; } = new ();


    }
}
