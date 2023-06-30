using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.BLL.DTOs.Booking
{
    public class UpdateBookingDTO
    {
        public Guid BookingId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ClassId { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
