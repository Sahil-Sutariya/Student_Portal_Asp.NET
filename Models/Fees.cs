using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortalFinal.Models
{
    public class Fees
    {
        [Key]
        public int FeesId { get; set; }
        public int StudentId { get; set; }
        public Decimal TotalAmount { get; set; }
        public Student Student { get; set; }

    }
}
