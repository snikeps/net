using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        public string Date { get; set; }
    }
}
