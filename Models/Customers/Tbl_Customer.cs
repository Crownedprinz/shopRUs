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
        public bool isCustomerLoyal()
        {
            return true;
        }
    }
}
