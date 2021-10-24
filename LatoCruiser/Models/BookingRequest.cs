using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LatoCruiser.Models
{
    public class BookingRequest
    {   
        [Key]
        public int Id { get; set; }
        public string BookerName { get; set; }
        public string BookerEmail { get; set; }
        public string BookerPhone { get; set; }
        public DateTime BookStart { get; set; }
        public DateTime BookEnd { get; set; }
        public string BookDescription { get; set; }
    }
}
