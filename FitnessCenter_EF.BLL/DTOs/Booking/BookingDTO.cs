using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.BLL.DTOs.Booking
{
    public class BookingDTO
    {
        public Guid BookingId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
    }
}
