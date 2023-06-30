using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(256)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;
        public ICollection<Attendance> Attendances { get; set; } = default!;
        public ICollection<Booking> Bookings { get; set; } = default!;
        public ICollection<Subscription> Subscriptions { get; set; } = default!;
    }
}
