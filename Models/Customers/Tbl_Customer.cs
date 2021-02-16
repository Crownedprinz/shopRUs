using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace shopRUs.Models.Customers
{

    /// <summary>
    /// ***Create table script***
    /// CREATE TABLE Tbl_copy (
    ///id INTEGER       PRIMARY KEY
    ///                 NOT NULL,
    ///fullName VARCHAR(100),
    ///address VARCHAR(100)
    ///);

    /// </summary>
    [Table("Tbl_Customer")]
    public class Tbl_Customer
    {
        [Key]
        [Required]
        public int id { get; set; }
        [StringLength(100)]
        public String fullName { get; set; }
        [StringLength(100)]
        public String address { get; set; }
        public bool isAffiliate { get; set; }
        public bool isEmployee { get; set; }
        [JsonIgnore]
        public DateTime timestamp { get; set; }

        //Check if customer has stayed with shopRUs for over 2 years
        public bool isCustomerLoyal()
        {
            DateTime zeroTime = new DateTime(1, 1, 1);

            DateTime dateCreated = timestamp.Date;
            DateTime current = DateTime.Now.Date;

            TimeSpan span = current - dateCreated;
            // Because we start at year 1 for the Gregorian
            // calendar, we must subtract a year here.
            int years = (zeroTime + span).Year - 1;

            // 1, where my other algorithm resulted in 0.
            if (years >= 2) return true;
            else
            return false;
        }
    }
}
