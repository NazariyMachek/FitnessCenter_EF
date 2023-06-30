using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Models
{
    [Table("Bookings")]
    public class Booking
    {
        [Key]
        public Guid BookingId { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public Guid ClassId { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        public Customer Customer { get; set; } = null!;
        public Class Class { get; set; } = null!;
    }
}
