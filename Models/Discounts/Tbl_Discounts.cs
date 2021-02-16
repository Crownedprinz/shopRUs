using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shopRUs.Models.Discounts
{
    /// <summary>
    /// *** Create table Script***
    /// CREATE TABLE Tbl_Discounts (
    ///id INTEGER      PRIMARY KEY
    ///                    NOT NULL,
    ///type   VARCHAR(30) UNIQUE
    ///                    NOT NULL,
    ///percentage DECIMAL
    ///);

    /// </summary>
    [Table("Tbl_Discounts")]
    public class Tbl_Discounts
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(30)]
        public String type { get; set; }
        [Required]
        public decimal percentage { get; set; }
    }
}
