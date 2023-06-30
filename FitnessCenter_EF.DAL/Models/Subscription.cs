using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Models
{
    [Table("Subscriptions")]
    public class Subscription
    {
        [Key]
        public Guid SubscriptionId { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
